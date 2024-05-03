using OpenQA.Selenium;
using UIFrameworkCSharp.core.enums;
using System.Reflection;

namespace UIFrameworkCSharp.core.controls;

public class RepeatingControl<T> : BaseControl
{
    private string controlId;
    private string controlId2;
    private string controlId3;
    private LocatorMethod locatorMethod;
    protected string rowLocatorPattern;
    protected bool hasHeader;

    public RepeatingControl(
        Locator locator,
        string controlId,
        LocatorMethod locatorMethod,
        string rowLocatorPattern,
        bool hasHeader) : base(locator)
    {
        this.controlId = controlId;
        this.controlId2 = null;
        this.controlId3 = null;
        this.locatorMethod = locatorMethod;
        this.rowLocatorPattern = rowLocatorPattern;
        this.hasHeader = hasHeader;
    }

    public RepeatingControl(
        Locator locator,
        string controlId1,
        string controlId2,
        string controlId3,
        LocatorMethod locatorMethod,
        string rowLocatorPattern,
        bool hasHeader) : base(locator)
    {
        this.controlId = controlId1;
        this.controlId2 = controlId2;
        this.controlId3 = controlId3;
        this.locatorMethod = locatorMethod;
        this.rowLocatorPattern = rowLocatorPattern;
        this.hasHeader = hasHeader;
    }

    public T Get(int row)
   {
        /*
         * The following code was an old approach to handling the different types of controls that could be passed in.
         * We need to update this to handle the new approach of passing in the control type if we need to start handling
         * custom controls (those that take more than one Locator parameter).
         */

        //if (getControl == null)
        //{
        //    return GetCustom(row);
        //}

        if (controlId == null)
        {
            return getControl(GetRowLocator(row));
        }
        else
        {
            switch (locatorMethod)
            {
                case LocatorMethod.DATA_TEST_ID:
                    return getControl(GetRowLocator(row).WithNext(ExtendedBy.RelativeTestId(controlId)));
                case LocatorMethod.TEXT:
                    return getControl(GetRowLocator(row).WithNext(By.XPath($".//*[text()='{controlId}']")));
                case LocatorMethod.XPATH:
                    return getControl(GetRowLocator(row).WithNext(By.XPath(controlId)));
            }
        }
        return default(T);
    }

    private T getControl(Locator locator)
    {
        Type controlType = typeof(T);
        ConstructorInfo constructor = controlType.GetConstructor([typeof(Locator)]);
        return (T)constructor.Invoke(new object[] { locator });
    }

    public T GetCustom(int row)
    {
        return default(T);
    }

    public T Get(string text)
    {
        int? index = GetIndex(text);
        if (index == null)
        {
            throw new Exception($"Could not find {text} in the repeating control");
        }
        return Get((int) index);
    }

    public int? GetIndex(string targetText)
    {
        int startingIndex = hasHeader ? 2 : 1;
        int rowCount = GetRowCount();
        for (int i = startingIndex; i <= rowCount; i++)
        {
            TextControl textControl = (TextControl)Get(i);
            if (textControl.GetText().Contains(targetText))
            {
                return i;
            }
        }
        return null;
    }

    private int GetAdjustedRow(int row)
    {
        return hasHeader ? row + 1 : row;
    }

    private Locator GetRowLocator(int row)
    {
        row = GetAdjustedRow(row);
        Locator newLocator = locator.GetWithNextLocator(By.XPath(String.Format("{0}[{1}]", rowLocatorPattern, row)));
        return newLocator;
    }

    private int GetRowCount()
    {
        return locator.GetWithNextLocator(By.XPath(rowLocatorPattern)).All().Count;
    }
}