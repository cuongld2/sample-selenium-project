using OpenQA.Selenium;
using SeleniumLearning.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning.pages
{
    public class HomePage
    {

        readonly By SignInMenuButton = By.CssSelector("div[role=\"presentation\"]");

        readonly By PhoneNumberTextBox = By.Id("ga_SignUp_Phone");
        readonly By NextButton = By.CssSelector("#basic > button");

        readonly By PasswordTextBox = By.CssSelector("input[type=\"tel\"]");

        readonly By CartMenuButton = By.CssSelector("div[class=\"cart__my-cart\"]");

        readonly By ProductMenuButton = By.Id("ga_Header_Product");
        readonly By LoadingIcon = By.CssSelector("div[class=\"backdrop\"]");

        public void Login(IWebDriver driver, String phoneNumber, String password)
        {
            ElementInteractions elementInteractions = new ElementInteractions();
            driver.FindElement(SignInMenuButton).Click();

            elementInteractions.FillInElement(driver, PhoneNumberTextBox, phoneNumber);

            elementInteractions.ClickOnElement(driver, NextButton);

            elementInteractions.FillInElement(driver, PasswordTextBox, password);

            elementInteractions.ClickOnElement(driver, NextButton);
        }

        public void VerifyLoginSuccess(IWebDriver driver, String cartDisplayedName)
        {
            String text = driver.FindElement(CartMenuButton).Text;
            StringAssert.Contains(cartDisplayedName, text);
        }

        public void ClickOnProductMenuButton(IWebDriver driver)
        {
            ElementInteractions elementInteractions = new();
            elementInteractions.ClickOnElement(driver, ProductMenuButton, LoadingIcon);
        }

    }
}
