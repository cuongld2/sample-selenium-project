using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumLearning.utils;

namespace SeleniumLearning.pages
{


    public class ProductPage

    {
       readonly By ProductCardElement = By.CssSelector("div[class='product-card']");
       readonly By NumberOfAddedItemsElement = By.CssSelector("div[class=\"cart__count\"] > span");

        public void AddPackageToCart(IWebDriver driver, String packageName)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(ProductCardElement));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ProductCardElement));
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(ProductCardElement);
            foreach (IWebElement element in elements)
            {
                String localpackageName = element.FindElement(By.CssSelector("div > div")).Text;
                if (localpackageName.Contains( packageName)) {

                    ElementInteractions elementInteractions = new();
                    elementInteractions.ClickOnElement(driver, By.CssSelector("div > div[class=\"product-card__button-area\"] > button[class=\"outline-button product-card__add-to-cart\"]"), By.CssSelector("div[class=\"backdrop\"]"));

                    /*element.FindElement(By.CssSelector("div > div[class=\"product-card__button-area\"] > button[class=\"outline-button product-card__add-to-cart\"]")).Click();*/

                }
            }

        }

        public int GetNumberOfAddedItems (IWebDriver driver)
        {

            ElementInteractions elementInteractions = new();
            String text = elementInteractions.GetTextOfElement(driver, NumberOfAddedItemsElement);
            return Convert.ToInt16 (text);
            
    }



    }
}
