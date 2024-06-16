using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using System.Text;
using UIFrameworkCSharp.core.enums;

namespace UIFrameworkCSharp.core.api;

public abstract class ApiBase<T> where T : ApiBase<T>
{
    protected static Logger log = LogManager.GetCurrentClassLogger();

    public HttpClient Client { get; set; }
    public string BaseUrl { get; set; }
    public string ContentType { get; set; }
    public string Accept { get; set; }
    public string Authorization { get; set; }
    public AuthType AuthType { get; set; }

    public Dictionary<string, string> Headers { get; set; }
    public Dictionary<string, string> QueryParameters { get; set; }
    private string formattedQueryParameters = "";

    public T WithQueryParameter(string key, string value)
    {
        if (QueryParameters == null)
        {
            QueryParameters = new();
        }
        QueryParameters.Add(key, value);
        return (T)this;
    }

    public T WithHeader(string key, string value)
    {
        if (Headers == null)
        {
            Headers = new();
        }
        Headers.Add(key, value);
        return (T)this;
    }

    public T WithAuthorization(string authorization)
    {
        Authorization = authorization;
        return (T)this;
    }

    public T WithAuthType(AuthType authType)
    {
        AuthType = authType;
        return (T)this;
    }

    public HttpResponseMessage Get(string path)
    {
        ConfigureClient();
        return Client.GetAsync(path + formattedQueryParameters).Result;
    }

    public HttpResponseMessage Post(string path, Object body)
    {
        ConfigureClient();
        return Client.PostAsync(path, GetAsHttpContent(body)).Result;
    }

    public HttpResponseMessage Put(string path, Object body)
    {
        ConfigureClient();
        return Client.PutAsync(path, GetAsHttpContent(body)).Result;
    }

    public HttpResponseMessage Delete(string path)
    {
        ConfigureClient();
        return Client.DeleteAsync(path).Result;
    }

    private JsonSerializerSettings GetJsonSerializerSettings()
    {
        return new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
    }

    private HttpContent GetAsHttpContent(Object body)
    {
        return new StringContent(
            JsonConvert.SerializeObject(body, GetJsonSerializerSettings()), 
            Encoding.UTF8, "application/json"
        );
    }

    private void ConfigureClient()
    {
        Client = new(new LoggingHandler(new HttpClientHandler()));
        Client.BaseAddress = new Uri(BaseUrl);
        if (Authorization != null)
        {
            ConfigureAuthorization();
        }
        if (ContentType != null)
        {
            Client.DefaultRequestHeaders.Add("Content-Type", ContentType);
        }
        if (Accept != null)
        {
            Client.DefaultRequestHeaders.Add("Accept", Accept);
        }
        if (Headers != null)
        {
            foreach (var header in Headers)
            {
                Client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
        if (QueryParameters != null)
        {
            formattedQueryParameters = "?";
            foreach (var queryParameter in QueryParameters)
            {
                formattedQueryParameters += $"{queryParameter.Key}={queryParameter.Value}&";
            }
            formattedQueryParameters = formattedQueryParameters.TrimEnd('&');
        }
    }

    private void ConfigureAuthorization()
    {
        if (AuthType == AuthType.BEARER)
        {
            WithHeader("Authorization", $"Bearer {Authorization}");
        }
        else
        {
            throw new Exception("Unsupported authorization type.");
        }
    }

}