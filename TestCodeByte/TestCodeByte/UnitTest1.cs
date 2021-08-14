using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace TestCodeByte
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckFacebook()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.crawco.co.uk";
            var element = driver.FindElement(By.CssSelector(".c-footer__branding a[title='Crawford on Facebook']"));
            Assert.AreEqual("https://www.facebook.com/crawfordandco", element.GetAttribute("href"));
            driver.Quit();
        }
        [TestMethod]
        public void CheckUser4()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://reqres.in/api/users/4";
            var text = driver.FindElement(By.CssSelector("pre")).Text;
            JObject json = JObject.Parse(text);
            JObject data = (JObject)json["data"];
            Assert.AreEqual("Eve", data["first_name"]);
            Assert.AreEqual("Holt", data["last_name"]);
            driver.Quit();
        }
        [TestMethod]
        public void CheckUser6()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://reqres.in/api/users/6";
            var text = driver.FindElement(By.CssSelector("pre")).Text;
            JObject json = JObject.Parse(text);
            JObject data = (JObject)json["data"];
            Assert.AreEqual("Ramos", data["last_name"]);
            // Fails because the actual input for first name is Tracey
            // The instructions said to search for Sergio
            Assert.AreEqual("Sergio", data["first_name"]);
            driver.Quit();
        }
        [TestMethod]
        public void CheckUser23()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://reqres.in/api/users/23";
            var text = driver.FindElement(By.CssSelector("pre")).Text;
            JObject json = JObject.Parse(text);
            JObject data = (JObject)json["data"];
            // If this is null this means the value does not exist
            Assert.IsNull(data);
            driver.Quit();
        }
    }
}
