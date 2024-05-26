namespace UIFrameworkCSharp.saucedemo.pages.productsPage;

using OpenQA.Selenium;
using System.Collections.Generic;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.saucedemo.domain;
using UIFrameworkCSharp.saucedemo.enums;

public class ProductsPage : BaseSauceDemoPage<ProductsPage>
{
    public Label LabelTitle { get; private set; }
    public ListProducts ListProducts { get; private set; }
    public Button ButtonCart { get; private set; }
    public Label LabelCartCount { get; private set; }
    public ComboBox ComboBoxSort { get; private set; }

    public ProductsPage(SauceDemoSite site) : base(site, "inventory.html")
    {
        LabelTitle = new Label(site.WebDriver, By.XPath("//span[@class='title']"));
        ButtonCart = new Button(site.WebDriver, By.ClassName("shopping_cart_link"));
        LabelCartCount = new Label(site.WebDriver, By.XPath("//span[@class='shopping_cart_badge']"));
        ListProducts = new ListProducts(new Locator(site.WebDriver, By.XPath("//div[@class='inventory_list']")));
        ComboBoxSort = new SelectComboBox(site.WebDriver, By.ClassName("product_sort_container"));
    }

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        for (int i = 1; i <= ListProducts.GetRowCount(); i++)
        {
            Site.ProductsPage().ListProducts.WithRow(i);
            products.Add(ListProducts.GetCurrentProduct());
        }
        return products;
    }

    public void SetSortingOption(string sortingField, SortingDirection sortingDirection)
    {
        string sortingOption = sortingField;
        if (sortingDirection == SortingDirection.ASCENDING)
        {
            sortingOption += sortingField.Equals("Name") ? " (A to Z)" : " (low to high)";
        }
        else
        {
            sortingOption += sortingField.Equals("Name") ? " (Z to A)" : " (high to low)";
        }

        Site.ProductsPage().ComboBoxSort.SetText(sortingOption);
    }
}