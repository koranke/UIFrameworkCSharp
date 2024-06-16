using UIFrameworkCSharp.magentodemo.pages.homePage;
using UIFrameworkCSharp.magentodemo;
using UIFrameworkCSharp.magentodemo.data;
using UIFrameworkCSharp.magentodemo.components;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public class CartPreviewTests : TestBase
{
    private static List<Product> products;

    [ClassInitialize]
    public static void TestFixtureSetup(TestContext testContext)
    {
        products = new MagentoSite().HomePage.Open().ListProducts.GetAllVisibleProducts();
    }

    [TestMethod]
    public void TestViewCartPreview()
    {
        HomePage homePage = new MagentoSite().HomePage.Open();
        homePage.AddProductToCart(products[0], 0, 0);
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
        HomePage homePage = new MagentoSite().HomePage.Open();
        homePage.AddProductToCart(products[0], 0, 0);
        homePage.Navigation.LabelCartCount.AssertIsVisible(2);
        homePage.Navigation.ButtonCart.Click();
        ListCartPreviewItems listCartPreviewItems = homePage.Navigation.PanelCartPreview.ListCartPreviewItems;
        listCartPreviewItems.UsingLabelName().WithRow(products[0].Name).LabelItemName.AssertIsVisible();
        listCartPreviewItems.LabelSize.AssertIsNotVisible();
        listCartPreviewItems.LabelColor.AssertIsNotVisible();
        listCartPreviewItems.LabelDetails.Click();
        listCartPreviewItems.LabelSize.AssertIsVisible();
        listCartPreviewItems.LabelColor.AssertIsVisible();
        listCartPreviewItems.LabelSize.AssertText(products[0].Sizes[0]);
        listCartPreviewItems.LabelColor.AssertText(products[0].Colors[0]);
        listCartPreviewItems.LabelItemPrice.AssertText(products[0].Price);
    }

    [TestMethod]
    public void TestViewCartPreviewDetailsWithMultipleProducts()
    {
        HomePage homePage = new MagentoSite().HomePage.Open();

        homePage.AddProductToCart(products[0], 0, 0);
        homePage.AddProductToCart(products[1], 1, 1);
        homePage.Navigation.LabelCartCount.AssertIsVisible(2);

        homePage.Navigation.ButtonCart.Click();
        homePage.Navigation.PanelCartPreview.verifySubTotal(products.Slice(0, 2));

        ListCartPreviewItems listCartPreviewItems = homePage.Navigation.PanelCartPreview.ListCartPreviewItems;
        listCartPreviewItems.VerifyItem(products[0], 0, 0);
        listCartPreviewItems.VerifyItem(products[1], 1, 1);
    }

}
