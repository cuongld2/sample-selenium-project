using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumLearning.pages;
using System.Text;

namespace SeleniumLearning
{
    internal class LoginTest:BaseTest
    {

        [Test]
        public void LoginSuccess()
        {
            HomePage homePage = new();

            String password = Encoding.UTF8.GetString(Convert.FromBase64String("MTEwMTkw"));
            homePage.Login(driver,"838069260", password);
            // assert
            String text = driver.FindElement(By.CssSelector("div[class=\"cart__my-cart\"]")).Text;
            StringAssert.Contains("GIỎ HÀNG", text);
        }



    }
}
