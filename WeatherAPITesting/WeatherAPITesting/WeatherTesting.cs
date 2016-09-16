using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json.Linq;


namespace WeatherAPITesting
{
    [TestClass]
    public class WeatherTesting
    {
        //Initialize a the IWebdriver in static
        static IWebDriver dr;


        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            //Assign the Driver to Null on Start of Application
            dr = new FirefoxDriver();
        }

        [TestMethod]
        public void CityName()
        {
            //Open Url being tested
            dr.Navigate().GoToUrl("http://api.openweathermap.org/data/2.5/weather?q=Lagos,us&APPID=15bbc55515f9a14b1e1b097e6f918185");
            //Wait 90 seconds for the page to open
            dr.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            //Declare and Initalize the IWebElement and locate element
            IWebElement we = dr.FindElement(By.TagName("pre"));
            //Declare and assign element output to a variable
            var weat_da = we.Text;
            //Declare and initalize JSon object to parse the string
            JObject city = JObject.Parse(weat_da);
            //Declare and assign parse output to a variable and convert to string
            var name = city["name"].ToString();
            //Initalize a assert equal to ensure the output to the same text as the string
            Assert.AreEqual("Lagos", name);
        }
        [TestMethod]
        public void CityNameFail()
        {
            //Open Url being tested
            dr.Navigate().GoToUrl("http://api.openweathermap.org/data/2.5/weather?q=Chicago,us&APPID=15bbc55515f9a14b1e1b097e6f918185");
            //Wait 90 seconds for the page to open
            dr.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            //Declare and Initalize the IWebElement and locate element
            IWebElement we = dr.FindElement(By.TagName("pre"));
            //Declare and assign element output to a variable
            var weat_da = we.Text;
            //Declare and initalize JSon object to parse the string
            JObject city = JObject.Parse(weat_da);
            //Declare and assign parse output to a variable and convert to string
            var name = city["name"].ToString();
            //Initalize a assert equal to ensure the output to the same text as the string
            Assert.AreEqual("Atlanta", name);
        }
        [TestMethod]
        public void TCleanup()
        {
            //Verify testing complete with message
            MessageBox.Show("Testing Complete");

            //Quit all testing 
            dr.Quit();
        }



    }
}
