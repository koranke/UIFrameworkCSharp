# Selenium Automation Framework in C#

This is a port of the Selenium Automation Framework from Java to C#.
For details on structure and usage, see the original project [here](https://github.com/koranke/UIFramework).

Here's a simple example of what a test might look like in this framework:

```csharp
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

```