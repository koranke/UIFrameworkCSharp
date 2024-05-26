using UIFrameworkCSharp.core;
using UIFrameworkCSharp.magentodemo.pages.homePage;
using UIFrameworkCSharp.magentodemo.pages.searchResultsPage;
using UIFrameworkCSharp.magentodemo.pages.whatIsNewPage;

namespace UIFrameworkCSharp.magentodemo;

public class MagentoSite : Site<MagentoSite>
{
    private HomePage homePage;
    private WhatIsNewPage whatIsNewPage;
    private SearchResultsPage searchResultsPage;

    public MagentoSite() : base()
    {
        Initialize();
    }

    private void Initialize()
    {
        this.BaseUrl = MagentoConstants.BaseUrl;
    }

    public HomePage HomePage()
    {
        if (homePage == null)
        {
            homePage = new HomePage(this);
        }
        return homePage;
    }

    public WhatIsNewPage WhatIsNewPage()
    {
        if (whatIsNewPage == null)
        {
            whatIsNewPage = new WhatIsNewPage(this);
        }
        return whatIsNewPage;
    }

    public SearchResultsPage SearchResultsPage()
    {
        if (searchResultsPage == null)
        {
            searchResultsPage = new SearchResultsPage(this);
        }
        return searchResultsPage;
    }
}
