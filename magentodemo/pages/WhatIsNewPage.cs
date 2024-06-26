﻿using UIFrameworkCSharp.magentodemo.components;

namespace UIFrameworkCSharp.magentodemo.pages;

public class WhatIsNewPage : BaseMagentoPage<WhatIsNewPage>
{
    public PanelNavigation Navigation { get; }

    public WhatIsNewPage(MagentoSite site) : base(site, "what-is-new.html")
    {
        Navigation = new PanelNavigation(site.WebDriver);
    }

    //public WhatIsNewPage Open()
    //{
    //    Site.homePage.Open();
    //    Site.homePage.Menu.WhatsNew.Click();
    //    return this;
    //}


}
