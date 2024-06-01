namespace UIFrameworkCSharp.core.controls;

public interface ComboBox
{
    void SetValue(string value);
    void SetText(string option);
    void SetText(int textIndex);
    string GetText();
    string GetValue();
    List<string> GetOptions();
    bool OptionExists(string targetText);
    void AssertText(string expectedText);
    void AssertValue(string expectedValue);
    void AssertIsEnabled();
    void AssertIsNotEnabled();
    void AssertIsVisible();
    void AssertOptions(List<string> expectedOptions);
}