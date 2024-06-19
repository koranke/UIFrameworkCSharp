using UIFrameworkCSharp.magentodemo;
using UIFrameworkCSharp.magentodemo.pages;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public class CategoryPageTests : TestBase
{

    [TestMethod]
    [DataRow("men", "tops-men", "Tops - Men")]
    [DataRow("women", "tops-women", "Tops - Women")]
    [DataRow("gear", "bags", "Bags - Gear")]
    public void TestOpenCategoryPage(string department, string category, string expectedTitle)
    {
        CategoryPage categoryPage = new MagentoSite().CategoryPage(department, category).Open();
        categoryPage.AssertIsOpen();
        categoryPage.AssertTitle(expectedTitle);
    }


    [TestMethod]
    public void TestAddSingleFilter()
    {
        CategoryPage categoryPage = new MagentoSite().CategoryPage("men", "tops-men").Open();
        categoryPage.Filters.SizeColorFilters.SelectItem("Size", "M");
        categoryPage.Filters.LabelFilterItem.AssertIsVisible("M");
    }

    [TestMethod]
    public void TestAddMultipleFilters()
    {
        CategoryPage categoryPage = new MagentoSite().CategoryPage("men", "tops-men").Open();
        categoryPage.Filters.SizeColorFilters.SelectItem("Size", "M");
        categoryPage.Filters.SizeColorFilters.SelectItem("Color", "Red");
        categoryPage.Filters.LabelFilterItem.AssertIsVisible("M");
        categoryPage.Filters.LabelFilterItem.AssertIsVisible("Red");
    }

    [TestMethod]
    public void TestClearAllFilters()
    {
        CategoryPage categoryPage = new MagentoSite().CategoryPage("men", "tops-men").Open();
        categoryPage.Filters.SizeColorFilters.SelectItem("Size", "M");
        categoryPage.Filters.SizeColorFilters.SelectItem("Color", "Red");

        categoryPage.Filters.ButtonClearAll.Click();
        categoryPage.Filters.LabelFilterItem.AssertIsNotVisible("M");
        categoryPage.Filters.LabelFilterItem.AssertIsNotVisible("Red");
    }
}
