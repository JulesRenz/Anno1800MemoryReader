using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Anno1800MemoryReader
{
    class GithubCalculatorFirefox
    {
        IWebDriver driver = new FirefoxDriver();
        string url = "https://nihoel.github.io/Anno1800Calculator/";
        public GithubCalculatorFirefox()
        {
            
        }

        private void writeValueToElement(string xpath, int value)
        {
            var uiElement = this.driver.FindElement(By.XPath(xpath));
            var val = Convert.ToInt32(uiElement.GetAttribute("value"));
            if(val != value)
            {
                uiElement.Click();
                uiElement.Clear();
                uiElement.SendKeys(value.ToString());
                
                //click background to apply changes
                var background = this.driver.FindElement(By.XPath("//*[@id=\"inhabitants-view\"]"));
                background.Click();
            }
        }

        //*[@id="inhabitants-view"]

        public void Calculate(Population pop)
        {
            if (this.driver.Url != url) this.driver.Url = url;

            writeValueToElement("/html/body/div[4]/fieldset[1]/div/div/div/div[1]/div[3]/div/input", pop.Farmers);
            
            writeValueToElement("/html/body/div[4]/fieldset[1]/div/div/div/div[2]/div[3]/div/input", pop.Workers);
            writeValueToElement("/html/body/div[4]/fieldset[1]/div/div/div/div[3]/div[3]/div/input", pop.Artisans);
            writeValueToElement("/html/body/div[4]/fieldset[1]/div/div/div/div[4]/div[3]/div/input", pop.Engineers);
            writeValueToElement("/html/body/div[4]/fieldset[1]/div/div/div/div[5]/div[3]/div/input", pop.Investors);

            writeValueToElement("/html/body/div[4]/fieldset[1]/div/div/div/div[6]/div[3]/div/input", pop.Jornaleros);
            writeValueToElement("/html/body/div[4]/fieldset[1]/div/div/div/div[7]/div[3]/div/input", pop.Obreros);
        }
    }
}
