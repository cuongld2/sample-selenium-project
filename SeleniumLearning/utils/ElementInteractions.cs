using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Extensions;
using System.Reflection.Metadata;

namespace SeleniumLearning.utils
{
    public class ElementInteractions
    {
        public void FillInElement(IWebDriver driver, By element, String content, Double waitTimeInSeconds=20)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
            driver.FindElement(element).SendKeys(content);
        }

        public  void ClickOnElement(IWebDriver driver, By element, By? elementInvisibility =null, Double waitTimeInSeconds = 20)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            if (elementInvisibility != null)
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(elementInvisibility));
                driver.FindElement(element).Click();
            }
            else
            {
                driver.FindElement(element).Click();
            }
        }

        public String GetTextOfElement(IWebDriver driver, By element, Double waitTimeInSeconds = 20)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
            return driver.FindElement(element).Text;
    }

    }
}
