using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public abstract class ListControl<T> : BaseControl where T : ListControl<T>
{
    protected int currentRow;
    protected RepeatingControl<Label> searchLabel;
    public string RowLocatorPattern { get; set; }
    protected bool hasHeader;
    protected bool headerUsesRowLocatorPattern;
    protected string headerControlId;

    public ListControl(Locator locator) : base(locator)
    {
    }

    private int GetAdjustedRow(int row)
    {
        return hasHeader && headerUsesRowLocatorPattern ? row + 1 : row;
    }

    public int GetRowCount()
    {
        int rowCount = locator.GetWithNextLocator(By.XPath(RowLocatorPattern)).All().Count;
        return hasHeader && headerUsesRowLocatorPattern ? rowCount - 1 : rowCount;
    }

    public ListControl<T> AssertRowCount(int expectedRowCount)
    {
        expectedRowCount = GetAdjustedRow(expectedRowCount);
        Assert.AreEqual(expectedRowCount, GetRowCount(), "Unexpected row count");
        return this;
    }

    public Label GetHeader(int column)
    {
        if (hasHeader)
        {
            Locator combined = locator.Clone().WithNext(By.XPath(headerControlId), column - 1);
            return new Label(combined);
        }
        else
        {
            return null;
        }
    }

    public T WithRow(int row)
    {
        this.currentRow = row;
        return (T)this;
    }

    public T WithRow(string text)
    {
        this.currentRow = (int)searchLabel.GetIndex(text);
        return (T)this;
    }

    public List<string> GetAllLabels()
    {
        List<string> allLabels = new List<string>();
        for (int i = 1; i <= GetRowCount(); i++)
        {
            allLabels.Add(searchLabel.Get(i).GetText());
        }
        return allLabels;
    }

    public Locator getRowLocator(int row)
    {
        return locator.GetWithNextLocator(By.XPath(string.Format("{0}[{1}]", RowLocatorPattern, row)));
    }

    public IWebElement getRowAsElement(int row)
    {
        return getRowLocator(row).GetElement();
    }
}