using FluentAssertions;
using UIFrameworkCSharp.saucedemo.domain;
using UIFrameworkCSharp.saucedemo.enums;
using UIFrameworkCSharp.saucedemo.pages.cartPage;

namespace UIFrameworkCSharp.saucedemo.utilities;

public class ProductsHelper
{
    public static void VerifyProductsSortOrder(List<Product> products, string sortingField, SortingDirection sortingDirection)
    {
        switch (sortingField)
        {
            case "Name":
                var productNames = products.Select(p => p.Name).ToList();

                if (sortingDirection == SortingDirection.DESCENDING)
                {
                    productNames.Should().BeInDescendingOrder();
                }
                else
                {
                    productNames.Should().BeInAscendingOrder();
                }
                break;
            case "Price":
                var productPrices = products.Select(p => p.Price).ToList();

                if (sortingDirection == SortingDirection.DESCENDING)
                {
                    productPrices.Should().BeInDescendingOrder();
                }
                else
                {
                    productPrices.Should().BeInAscendingOrder();
                }
                break;
            default:
                throw new ArgumentException("Unknown sorting field: " + sortingField);
        }
    }

    public static void VerifyProductsInCart(List<Product> expectedProducts, CartPage cartPage)
    {
        if (expectedProducts == null || !expectedProducts.Any())
        {
            cartPage.ListCartItems.Should().BeNull();
        }
        else
        {
            foreach (var product in expectedProducts)
            {
                cartPage.ListCartItems.UsingLabelName().WithRow(product.Name).LabelName().AssertText(product.Name);
                cartPage.ListCartItems.LabelDescription().AssertText(product.Description);
                cartPage.ListCartItems.LabelPrice().AssertText(string.Format("${0:F2}", product.Price));
                cartPage.ListCartItems.LabelQuantity().AssertText("1");
            }
        }
    }
}
