using FluentAssertions;
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
        site.HomePage.Open();
        site.HomePage.AssertIsOpen();

        site.HomePage.Navigation.WhatsNew.Click();
        site.WhatIsNewPage.AssertIsOpen();

        site.WhatIsNewPage.Navigation.Logo.Click();
        site.HomePage.AssertIsOpen();
    }

    [TestMethod]
    public void TestSearch()
    {
        MagentoSite site = new MagentoSite();
        site.HomePage.Open();
        site.HomePage.Navigation.Search("shirt");
        site.SearchResultsPage.AssertIsOpen();
        site.SearchResultsPage.LabelResults.AssertText("Search results for: 'shirt'");
        site.SearchResultsPage.ListProductItems.AssertRowCount(5);
    }

    [TestMethod]
    public void TestSizesAndColors()
    {
        HomePage homePage = new MagentoSite().HomePage.Open();
        ListProducts listProductItems = homePage.ListProducts;
        listProductItems.UsingLabelName().WithRow("Hero Hoodie").LabelItemName.ScrollToElement();
        List<string> sizes = listProductItems.GetAllSizes();
        sizes.Should().BeEquivalentTo(new List<string> { "XS", "S", "M", "L", "XL" });
        List<string> colors = listProductItems.GetAllColors();
        colors.Should().BeEquivalentTo(new List<string> { "Black", "Green", "Gray" });
    }

    [TestMethod]
    public void TestAddToCart()
    {
        HomePage homePage = new MagentoSite().HomePage.Open();
        ListProducts listProducts = homePage.ListProducts;
        List<Product> products = listProducts.GetAllVisibleProducts();

        listProducts.AddProductToCart(products[0], 0, 0);
        listProducts.AddProductToCart(products[1], 1, 1);

        homePage.Navigation.LabelCartCount.AssertText("2");
    }

    [TestMethod]
    public void TestProducts()
    {
        HomePage homePage = new MagentoSite().HomePage.Open();
        ListProducts listProducts = homePage.ListProducts;

        List<Product> products = listProducts.GetAllVisibleProducts();
        Assert.AreEqual(6, products.Count, "Unexpected number of products.");
    }

}
