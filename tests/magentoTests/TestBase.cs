using NLog;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.magentodemo.components;
using UIFrameworkCSharp.magentodemo.data;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public abstract class TestBase
{
    protected static Logger logger;
    public TestContext TestContext { get; set; }

    public TestBase()
    {
        logger = LogManager.GetLogger(GetType().Name);
    }

    [TestInitialize]
    public void Setup()
    {
        logger.Info($"Test Started: {TestContext.TestName}");
    }

    [TestCleanup]
    public void Cleanup()
    {
        switch(TestContext.CurrentTestOutcome)
        {
            case UnitTestOutcome.Passed:
                logger.Info($"Test Passed: {TestContext.TestName}");
                break;
            case UnitTestOutcome.Failed:
                logger.Error($"Test Failed: {TestContext.TestName}");
                SeleniumUtilities.TakeScreenshot(TestContext);
                break;
            default:
                logger.Warn($"Test Inconclusive: {TestContext.TestName}");
                break;
        }
        SeleniumManager.CloseCurrentDriver();
    }

    protected void AddProductToCart(ListProductItems listProductItems, Product product, int? sizeIndex, int? colorIndex)
    {
        AddProductToCart(listProductItems, product.Name, 
            sizeIndex != null ? product.Sizes[sizeIndex??0] : null, 
            colorIndex != null ? product.Colors[colorIndex??0] : null);
    }

    protected void AddProductToCart(ListProductItems listProductItems, string productName, string option, string color)
    {
        listProductItems.UsingLabelName().WithRow(productName).LabelItemName.ScrollToElement();
        listProductItems.LabelItemName.Hover();
        if (option != null) listProductItems.LabelOption(option).Click();
        if (color != null) listProductItems.LabelColor(color).Click();
        listProductItems.ButtonAddToCart.AssertIsVisible();
        listProductItems.ButtonAddToCart.Click();
    }

    protected Product GetProduct(ListProductItems listProductItems, int row)
    {
        listProductItems.WithRow(row);

        Product product = new Product();
        product.Name = listProductItems.LabelItemName.GetText();
        product.Price = listProductItems.LabelItemPrice.GetText();
        product.Sizes = listProductItems.GetAllSizes();
        product.Colors = listProductItems.GetAllColors();
        return product;
    }

    protected List<Product> GetAllVisibleProducts(ListProductItems listProductItems)
    {
        List<Product> products = new List<Product>();
        int rowCount = listProductItems.GetRowCount();
        for (int i = 1; i <= rowCount; i++)
        {
            products.Add(GetProduct(listProductItems, i));
        }
        return products;
    }
}
