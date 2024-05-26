using UIFrameworkCSharp.saucedemo.domain;
using UIFrameworkCSharp.saucedemo.enums;
using UIFrameworkCSharp.saucedemo.pages.productsPage;
using UIFrameworkCSharp.saucedemo;
using UIFrameworkCSharp.saucedemo.utilities;

namespace UIFrameworkCSharp.tests.saucedemoTests;

[TestClass]
public class ProductsTests
{

    [TestMethod]
    public void TestViewAllProducts()
    {
        ProductsPage productsPage = new SauceDemoSite().ProductsPage().Open();
        List<Product> products = productsPage.GetAllProducts();
        ProductsHelper.VerifyProductsSortOrder(products, "Name", SortingDirection.ASCENDING);
    }

    public static IEnumerable<object[]> GetSortScenarios()
    {
        yield return new object[] { "Name", SortingDirection.ASCENDING };
        yield return new object[] { "Name", SortingDirection.DESCENDING };
        yield return new object[] { "Price", SortingDirection.ASCENDING };
        yield return new object[] { "Price", SortingDirection.DESCENDING };
    }

    [DataTestMethod]
    [DynamicData(nameof(GetSortScenarios), DynamicDataSourceType.Method)]
    public void TestSortProducts(string sortingField, SortingDirection sortingDirection)
    {
        ProductsPage productsPage = new SauceDemoSite().ProductsPage().Open();
        productsPage.SetSortingOption(sortingField, sortingDirection);
        List<Product> products = productsPage.GetAllProducts();
        ProductsHelper.VerifyProductsSortOrder(products, sortingField, sortingDirection);
    }

    [TestMethod]
    public void TestAddProductToCart()
    {
        ProductsPage productsPage = new SauceDemoSite().ProductsPage().Open();
        productsPage.ListProducts.WithRow(1).ButtonAddToCart().Click();
        Assert.AreEqual("1", productsPage.LabelCartCount.GetText());
    }

    [TestMethod]
    public void TestAddAnotherProductToCart()
    {
        ProductsPage productsPage = new SauceDemoSite().ProductsPage().Open();
        productsPage.ListProducts.WithRow(1).ButtonAddToCart().Click();
        productsPage.ListProducts.WithRow(2).ButtonAddToCart().Click();
        Assert.AreEqual("2", productsPage.LabelCartCount.GetText());
    }

    [TestMethod]
    public void TestRemoveProductFromCart()
    {
        ProductsPage productsPage = new SauceDemoSite().ProductsPage().Open();
        productsPage.ListProducts.WithRow(1).ButtonAddToCart().Click();
        productsPage.ListProducts.ButtonRemoveFromCart().Click();
        Assert.IsFalse(productsPage.LabelCartCount.IsVisible());
    }
}