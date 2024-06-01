using UIFrameworkCSharp.magentodemo.pages.homePage;
using UIFrameworkCSharp.magentodemo;
using UIFrameworkCSharp.magentodemo.data;
using Newtonsoft.Json;
using UIFrameworkCSharp.magentodemo.components;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public class CartPreviewTests : TestBase
{
    private List<Product> products;

    public CartPreviewTests()
    {
        MagentoSite site = new MagentoSite();
        site.HomePage().Open();
        this.products = GetAllVisibleProducts(site.HomePage().ListProductItems);
    }

    [TestMethod]
    public void TestViewCartPreview()
    {
        HomePage homePage = new MagentoSite().HomePage().Open();

        AddProductToCart(homePage.ListProductItems, products[0], 0, 0);
        homePage.Navigation.LabelCartCount.AssertIsVisible(2);
        homePage.Navigation.ButtonCart.Click();

        PanelCartPreview panelCartPreview = homePage.Navigation.PanelCartPreview;
        panelCartPreview.ButtonCheckout.AssertIsVisible(2);
        panelCartPreview.LabelCartCount.AssertText("1");
        panelCartPreview.LabelSubTotal.AssertText(products[0].Price);
        panelCartPreview.ButtonClose.Click();
        panelCartPreview.ButtonCheckout.AssertIsNotVisible();
    }

    [TestMethod]
    public void TestViewCartPreviewDetails()
    {
        HomePage homePage = new MagentoSite().HomePage().Open();

        AddProductToCart(homePage.ListProductItems, products[0], 0, 0);
        homePage.Navigation.LabelCartCount.AssertIsVisible(2);
        homePage.Navigation.ButtonCart.Click();
        ListCartPreviewItems listCartPreviewItems = homePage.Navigation.PanelCartPreview.ListCartPreviewItems;
        listCartPreviewItems.UsingLabelName().WithRow(products[0].Name).LabelItemName().AssertIsVisible();
        listCartPreviewItems.LabelSize().AssertIsNotVisible();
        listCartPreviewItems.LabelColor().AssertIsNotVisible();
        listCartPreviewItems.LabelDetails().Click();
        listCartPreviewItems.LabelSize().AssertIsVisible();
        listCartPreviewItems.LabelColor().AssertIsVisible();
        listCartPreviewItems.LabelSize().AssertText(products[0].Sizes[0]);
        listCartPreviewItems.LabelColor().AssertText(products[0].Colors[0]);
        listCartPreviewItems.LabelItemPrice().AssertText(products[0].Price);
    }

    [TestMethod]
    public void TestViewCartPreviewDetailsWithMultipleProducts()
    {
        HomePage homePage = new MagentoSite().HomePage().Open();

        AddProductToCart(homePage.ListProductItems, products[0], 0, 0);
        AddProductToCart(homePage.ListProductItems, products[1], 0, 0);
        homePage.Navigation.LabelCartCount.AssertIsVisible(2);

        homePage.Navigation.ButtonCart.Click();
        homePage.Navigation.PanelCartPreview.verifySubTotal(products.Slice(0, 2));

        ListCartPreviewItems listCartPreviewItems = homePage.Navigation.PanelCartPreview.ListCartPreviewItems;
        listCartPreviewItems.VerifyItem(products[0], 0, 0);
        listCartPreviewItems.VerifyItem(products[1], 0, 0);
    }

    [TestMethod]
    public void dm()
    {
        //load json file into a list of Product objects
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("./magentodemo/data/products.json"));
        Console.WriteLine(products.Count);
    }

}
