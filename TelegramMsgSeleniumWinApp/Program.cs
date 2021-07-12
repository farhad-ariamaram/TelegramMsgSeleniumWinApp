using System;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TelegramMsgSeleniumWinApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument(@"user-data-dir=C:\Users\ym\AppData\Local\Google\Chrome\User Data\Default");

            IWebDriver driver = new ChromeDriver(options);

            driver.Url = "https://web.telegram.org/?legacy=1#/im";

            await Task.Delay(5000);

            using (FileStream fs = File.Open("phones.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    line = "+98" + line.Substring(1);

                    driver.FindElement(By.XPath(@"/html/body/div[1]/div[1]/div/div/div[1]/div/a/div/span[2]")).Click();

                    await Task.Delay(2000);

                    driver.FindElement(By.XPath(@"/html/body/div[1]/div[1]/div/div/div[1]/div/ul/li[2]/a")).Click();

                    await Task.Delay(2000);

                    driver.FindElement(By.XPath(@"/html/body/div[6]/div[2]/div/div/div[3]/div/button")).Click();

                    await Task.Delay(2000);

                    driver.FindElement(By.XPath(@"/html/body/div[7]/div[2]/div/div/div[1]/form/div[1]/input")).SendKeys(line);

                    await Task.Delay(2000);

                    driver.FindElement(By.XPath(@"/html/body/div[7]/div[2]/div/div/div[1]/form/div[2]/input")).SendKeys(line);

                    await Task.Delay(2000);

                    driver.FindElement(By.XPath(@"/html/body/div[7]/div[2]/div/div/div[2]/button[2]")).Click();

                    await Task.Delay(2000);

                    bool found = false;

                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[7]/div[2]/div/div/div[1]/h4/span/span"));
                    }
                    catch (Exception)
                    {
                        found = true;
                    }

                    if (found)
                    {

                    }
                    else
                    {
                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[7]/div[2]/div/div/div[2]/button/span")).Click();

                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[6]/div[2]/div/div/div[1]/div[1]/div/a[1]")).Click();

                    }
                } 
            }

        }

    }
}
