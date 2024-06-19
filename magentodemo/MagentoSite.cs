using UIFrameworkCSharp.core;
using UIFrameworkCSharp.magentodemo.pages;

namespace UIFrameworkCSharp.magentodemo;

public class MagentoSite : Site<MagentoSite>
{
    private HomePage homePage;
    private WhatIsNewPage whatIsNewPage;
    private SearchResultsPage searchResultsPage;
    private LoginPage loginPage;
    private MyAccountPage myAccountPage;
    private NewCustomerPage newCustomerPage;
    private CategoryPage categoryPage;

    public MagentoSite() : base()
    {
        Initialize();
    }

    private void Initialize()
    {
        this.BaseUrl = MagentoConstants.BaseUrl;
    }

    public HomePage HomePage
    {
        get 
        {
            if (homePage == null)
            {
                homePage = new HomePage(this);
            }
            return homePage;
        }
    }

    public WhatIsNewPage WhatIsNewPage
    {
        get 
        {
            if (whatIsNewPage == null)
            {
                whatIsNewPage = new WhatIsNewPage(this);
            }
            return whatIsNewPage;
        }
    }

    public SearchResultsPage SearchResultsPage
    {
        get 
        {
            if (searchResultsPage == null)
            {
                searchResultsPage = new SearchResultsPage(this);
            }
            return searchResultsPage;
        }
    }

    public LoginPage LoginPage
    {
        get 
        {
            if (loginPage == null)
            {
                loginPage = new LoginPage(this);
            }
            return loginPage;
        }
    }

    public MyAccountPage MyAccountPage
    {
        get 
        {
            if (myAccountPage == null)
            {
                myAccountPage = new MyAccountPage(this);
            }
            return myAccountPage;
        }
    }

    public NewCustomerPage NewCustomerPage
    {
        get 
        {
            if (newCustomerPage == null)
            {
                newCustomerPage = new NewCustomerPage(this);
            }
            return newCustomerPage;
        }
    }

    public CategoryPage CategoryPage(string department, string category)
    {
        if (categoryPage == null)
        {
            categoryPage = new CategoryPage(this, department, category);
        }
        return categoryPage;
    }



}
