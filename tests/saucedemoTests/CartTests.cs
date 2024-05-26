using UIFrameworkCSharp.saucedemo;
using UIFrameworkCSharp.saucedemo.domain;
using UIFrameworkCSharp.saucedemo.utilities;

namespace UIFrameworkCSharp.tests.saucedemoTests;

[TestClass]
public class CartTests
{
    [TestMethod]
    public void TestViewCartWithNoProducts()
    {
        SauceDemoSite site = new SauceDemoSite();
        site.ProductsPage().Open();
        site.ProductsPage().ButtonCart.Click();
        site.CartPage().AssertIsOpen();
        site.CartPage().ListCartItems.AssertIsNotVisible();
    }

    [TestMethod]
    public void TestViewCartWithProduct()
    {
        SauceDemoSite site = new SauceDemoSite();
        site.ProductsPage().Open();
        site.ProductsPage().ListProducts.WithRow(1).ButtonAddToCart().Click();
        site.ProductsPage().ButtonCart.Click();
        site.CartPage().AssertIsOpen();
        site.CartPage().ListCartItems.AssertRowCount(1);
    }

    [TestMethod]
    public void TestViewCartWithMultipleProducts()
    {
        SauceDemoSite site = new SauceDemoSite();
        site.ProductsPage().Open();

        List<string> productNames = new List<string> { "Sauce Labs Onesie", "Sauce Labs Bike Light" };
        List<Product> products = new List<Product>();
        foreach (var productName in productNames)
        {
            site.ProductsPage().ListProducts.UsingLabelName().WithRow(productName).ButtonAddToCart().Click();
            products.Add(site.ProductsPage().ListProducts.GetCurrentProduct());
        }

        site.ProductsPage().ButtonCart.Click();
        site.CartPage().ListCartItems.AssertRowCount(productNames.Count);
        ProductsHelper.VerifyProductsInCart(products, site.CartPage());
    }
}