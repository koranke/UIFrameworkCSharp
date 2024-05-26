using UIFrameworkCSharp.core;
using UIFrameworkCSharp.magentodemo;
using UIFrameworkCSharp.magentodemo.components;
using UIFrameworkCSharp.magentodemo.pages.homePage;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public class HomePageTests
{
    [TestCleanup]
    public void Cleanup()
    {
        SeleniumManager.CloseCurrentDriver();
    }

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

        site.HomePage().Navigation.SearchBox.SetText("shirt");
        site.HomePage().Navigation.SearchButton.Click();
        site.SearchResultsPage().LabelResults.AssertText("Search results for: 'shirt'");
        site.SearchResultsPage().ListProductItems.AssertRowCount(5);
    }

    [TestMethod]
    public void TestAddToCart()
    {
        HomePage homePage = new MagentoSite().HomePage().Open();
        ListProductItems listProductItems = homePage.ListProductItems;

        AddProductToCart(listProductItems, "Hero Hoodie", "L", "Green");
        AddProductToCart(listProductItems, "Radiant Tee", "M", "Orange");
    }

    private void AddProductToCart(ListProductItems listProductItems, string productName, string option, string color)
    {
        listProductItems.UsingLabelName().WithRow(productName).LabelItemName().ScrollToElement();
        listProductItems.LabelItemName().Hover();
        listProductItems.LabelOption(option).Click();
        listProductItems.LabelColor(color).Click();
        listProductItems.ButtonAddToCart().AssertIsVisible();
        listProductItems.ButtonAddToCart().Click();
    }
}
