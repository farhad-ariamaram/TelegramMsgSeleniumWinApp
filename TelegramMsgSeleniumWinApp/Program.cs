using System;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TelegramMsgSeleniumWinApp.Models;

namespace TelegramMsgSeleniumWinApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TelegramBulkMsgDBContext _db = new TelegramBulkMsgDBContext();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument(@"user-data-dir=C:\Users\ym\AppData\Local\Google\Chrome\User Data\Default");

            string lastseen = "";

            var msg =
                "مشتریان عزیز" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "درود بر شما " +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "با احترام ضمن آرزوی سلامتی و بهروزی " +
                "بدینوسیله به اطلاع میرساند که شرکت پرنده باران پارس" +
                "با نام تجاری ABAone" +
                "فروشگاه اینترنتی خود را در لینک زیر فعال نموده است." +
                "موفق و پیروز باشید" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "انصاری" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "تلفن واحد فروش :" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift +
                "02191013200" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "موبایل واحد فروش :" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "09199122519" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "https://abaone.ir/shop/" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "اینستاگرام:" +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter +
                "instagram: https://www.instagram.com/abaone.ir";

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
                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[1]/div[2]/div/div[2]/div[3]/div/div[3]/div[2]/div/div/div/form/div[2]/div[5]")).SendKeys(msg);

                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[1]/div[2]/div/div[2]/div[3]/div/div[3]/div[2]/div/div/div/form/div[3]/button/span[1]")).Click();

                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[1]/div[1]/div/div/div[2]/div/div[2]/a/div/span[1]")).Click();

                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[6]/div[2]/div/div/div[3]/div/div[3]/div[2]/a")).Click();

                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[6]/div[2]/div/div/div[3]/div/div[3]/div[2]/a")).Click();

                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[6]/div[2]/div/div/div[1]/div[1]/div[1]/a")).Click();

                        await Task.Delay(2000);

                        try
                        {
                            lastseen = driver.FindElement(By.XPath(@"/html/body/div[1]/div[1]/div/div/div[2]/div/div[2]/a/div/span[2]/span")).Text;
                        }
                        catch (Exception)
                        {
                            lastseen = "";
                        }

                    }
                    else
                    {
                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[7]/div[2]/div/div/div[2]/button/span")).Click();

                        await Task.Delay(2000);

                        driver.FindElement(By.XPath(@"/html/body/div[6]/div[2]/div/div/div[1]/div[1]/div/a[1]")).Click();

                    }

                    Person person = new Person
                    {
                        Phone = line,
                        SendDate = DateTime.Now,
                        HasTelegram = lastseen == "" ? false : true,
                        LastSeen = lastseen
                    };

                    await _db.Persons.AddAsync(person);
                    await _db.SaveChangesAsync();
            }
        }

    }

}
}
