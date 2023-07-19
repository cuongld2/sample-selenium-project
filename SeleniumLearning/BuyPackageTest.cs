using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumLearning.pages;
using WebDriverManager.DriverConfigs.Impl;
using System.Text;

namespace SeleniumLearning
{
    internal class BuyPackageTest:BaseTest
    {

        [Test]
        public void AddPackageToCart()
        {
            HomePage homePage = new();

            String password = Encoding.UTF8.GetString(Convert.FromBase64String("MTEwMTkw"));
            homePage.Login(driver, "838069260", password);


            // assert that login successfully
            homePage.VerifyLoginSuccess(driver, "GIỎ HÀNG");

            driver.Manage().Window.Maximize();
            
            // Click on Product Menu button to go to Product page
            homePage.ClickOnProductMenuButton(driver);


            // Choose "GeneFuture Premium" to add to cart
            ProductPage productPage = new ();
            productPage.AddPackageToCart(driver, "GeneFuture Premium");

            // Verify the number of added item equals to 1
            Assert.That(productPage.GetNumberOfAddedItems(driver), Is.EqualTo(2));

        }


    }
}
