using UIFrameworkCSharp.magentodemo;
using UIFrameworkCSharp.magentodemo.components;
using UIFrameworkCSharp.magentodemo.data;
using UIFrameworkCSharp.magentodemo.pages.homePage;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public class HomePageTests : TestBase
{

    [TestMethod]
    public void TestHomePage()
    {
        MagentoSite site = new MagentoSite();
        site.HomePage().Open();
        site.HomePage().AssertIsOpen();

        site.HomePage().Navigation.WhatsNew.Click();
        site.WhatIsNewPage().AssertIsOpen();

        site.WhatIsNewPage().Navigation.Logo.Click();
        site.HomePage().AssertIsOpen();
    }

    [TestMethod]
    public void TestSearch()
    {
        MagentoSite site = new MagentoSite();
        site.HomePage().Open();
        site.HomePage().AssertIsOpen();

        site.HomePage().Navigation.TextBoxSearch.SetText("shirt");
        site.HomePage().Navigation.ButtonSearch.Click();
        site.SearchResultsPage().LabelResults.AssertText("Search results for: 'shirt'");
        site.SearchResultsPage().ListProductItems.AssertRowCount(5);
    }

    [TestMethod]
    public void TestAddToCart()
    {
        HomePage homePage = new MagentoSite().HomePage().Open();
        ListProductItems listProductItems = homePage.ListProductItems;
        List<Product> products = GetAllVisibleProducts(listProductItems);

        AddProductToCart(listProductItems, products[0], 0, 0);
        AddProductToCart(listProductItems, products[1], 0, 0);

        homePage.Navigation.LabelCartCount.AssertText("2");
    }

    [TestMethod]
    public void TestProducts()
    {
        HomePage homePage = new MagentoSite().HomePage().Open();
        ListProductItems listProductItems = homePage.ListProductItems;

        List<Product> products = GetAllVisibleProducts(listProductItems);
        Assert.AreEqual(5, products.Count);
    }

}
