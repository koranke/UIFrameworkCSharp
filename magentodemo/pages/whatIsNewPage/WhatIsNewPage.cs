using UIFrameworkCSharp.magentodemo.components;

namespace UIFrameworkCSharp.magentodemo.pages.whatIsNewPage;

public class WhatIsNewPage : BaseMagentoPage<WhatIsNewPage>
{
    public NavigationPanel Navigation { get; }

    public WhatIsNewPage(MagentoSite site) : base(site, "what-is-new.html")
    {
        this.Navigation = new NavigationPanel(site.WebDriver);
    }

    //public WhatIsNewPage Open()
    //{
    //    Site.homePage.Open();
    //    Site.homePage.Menu.WhatsNew.Click();
    //    return this;
    //}


}
