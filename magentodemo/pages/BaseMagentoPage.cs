using UIFrameworkCSharp.core;
using UIFrameworkCSharp.saucedemo;

namespace UIFrameworkCSharp.magentodemo.pages;

public abstract class BaseMagentoPage<T> : BasePage<T>
{
    protected MagentoSite Site { get; set; }
    private string Path;

    public BaseMagentoPage(MagentoSite site, string path) : base(site.WebDriver, site.BaseUrl, path)
    {
        this.Site = site;
    }

    public T Open()
    {
        return GoTo();
    }

}
