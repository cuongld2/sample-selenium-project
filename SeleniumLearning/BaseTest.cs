using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class BaseTest
    {

        ExtentReports extent;
        ExtentTest test;
/*        public ThreadLocal<ExtentReports> local;*/
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [SetUp]
        public void OpenBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            TestContext.Progress.WriteLine("Setup to open browser");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Url = "https://genestory.ai/home";
        }

        [TearDown]
        public void AfterTest()
        {
            TestContext.Progress.WriteLine("Setup to close browser");
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed) {

                test.Fail("The test is failed: ",captureScreenshot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace is: " + stackTrace);
            

            }else if(status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("The test is passed");

            }
            extent.Flush();
            driver.Close();

        }


        public MediaEntityModelProvider captureScreenshot(IWebDriver driver, String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            string screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }


    }
}
