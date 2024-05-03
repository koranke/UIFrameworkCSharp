using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCSharp.core.controls;

public class TabGroup
{
    protected Locator Locator { get; }

    public TabGroup(Locator locator)
    {
        this.Locator = locator;
    }
}