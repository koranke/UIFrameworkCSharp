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
        homePage.Navigation.ButtonCart.Click();
        ListCartPreview listCartPreview = homePage.Navigation.PanelCartPreview.ListCartPreviewItems;
        listCartPreview.UsingLabelName().WithRow(products[0].Name).LabelItemName.AssertIsVisible();
        listCartPreview.LabelSize.AssertIsNotVisible();
        listCartPreview.LabelColor.AssertIsNotVisible();
        listCartPreview.LabelDetails.Click();
        listCartPreview.LabelSize.AssertIsVisible();
        listCartPreview.LabelColor.AssertIsVisible();
        listCartPreview.LabelSize.AssertText(products[0].Sizes[0]);
        listCartPreview.LabelColor.AssertText(products[0].Colors[0]);
        listCartPreview.LabelItemPrice.AssertText(products[0].Price);
    }

    [TestMethod]
    public void TestViewCartPreviewDetailsWithMultipleProducts()
    {
        HomePage homePage = new MagentoSite().HomePage.Open();

        homePage.AddProductToCart(products[0], 0, 0);
        homePage.AddProductToCart(products[1], 1, 1);

        homePage.Navigation.ButtonCart.Click();
        homePage.Navigation.PanelCartPreview.verifySubTotal(products.Slice(0, 2));

        ListCartPreview listCartPreview = homePage.Navigation.PanelCartPreview.ListCartPreviewItems;
        listCartPreview
            .VerifyItem(products[0], 0, 0)
            .VerifyItem(products[1], 1, 1);
    }

}
