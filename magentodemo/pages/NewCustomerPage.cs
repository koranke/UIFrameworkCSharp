using OpenQA.Selenium;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.magentodemo.domain;

namespace UIFrameworkCSharp.magentodemo.pages;

public class NewCustomerPage : BaseMagentoPage<NewCustomerPage>
{
    public TextBox TextBoxFirstName { get; }
    public TextBox TextBoxLastName { get; }
    public TextBox TextBoxEmail { get; }
    public TextBox TextBoxPassword { get; }
    public TextBox TextBoxConfirmPassword { get; }
    public Button ButtonCreateAccount { get; }
    public Label LabelFirstNameError { get; }

    public NewCustomerPage(MagentoSite site) : base(site, "customer/account/create/")
    {
        TextBoxFirstName = new TextBox(site.WebDriver, By.Id("firstname"));
        TextBoxLastName = new TextBox(site.WebDriver, By.Id("lastname"));
        TextBoxEmail = new TextBox(site.WebDriver, By.Id("email_address"));
        TextBoxPassword = new TextBox(site.WebDriver, By.Id("password"));
        TextBoxConfirmPassword = new TextBox(site.WebDriver, By.Id("password-confirmation"));
        ButtonCreateAccount = new Button(site.WebDriver, By.XPath("//button[@title='Create an Account']"));
        LabelFirstNameError = new Label(site.WebDriver, By.Id("firstname-error"));
    }

    public NewCustomerPage Open()
    {
        this.Site.HomePage.Open();
        this.Site.HomePage.Navigation.LinkCreateAccount.Click();
        return this;
    }

    public Account CreateRandomAccount()
    {
        Account account = new Account().withDefaults();
        TextBoxFirstName.SetText(account.Customer.Firstname);
        TextBoxLastName.SetText(account.Customer.Lastname);
        TextBoxEmail.SetText(account.Customer.Email);
        TextBoxPassword.SetText(account.Password);
        TextBoxConfirmPassword.SetText(account.Password);
        ButtonCreateAccount.Click();
        return account;
    }
}
