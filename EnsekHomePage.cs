using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V108.Network;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace EnsekTest;
[Binding]
class EnsekHomePage
{
    private IWebDriver driver;

    [BeforeScenario]
    public void InstantiateDriver()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

    }
    [Given(@"I am on homepage")]
    public void GotoHome()
    {
        driver.Navigate().GoToUrl("https://ensekautomationcandidatetest.azurewebsites.net/");
        
        
    }

    [When(@"I click FindOutMore")]
    public void ClickFindOutMore()
    {
        
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        var element = wait.Until(d => d.FindElement(By.XPath("//a[@class='btn btn-primary btn-lg']")));
        //var element = driver.FindElements(By.XPath("//a[@class='btn btn-primary btn-lg']")).First(e =>e.Displayed);
        element!.Click();
    }

    [Then(@"I will be redirected to respective page")]

    public void PageLoaded()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        var button = wait.Until(d => d.FindElement(By.XPath("//h2[@class='mt-4 mb-10 h1 text-blue']")));
        
    }
    
[AfterScenario]

    public void TearDown()
    {
        driver.Quit();
    }



}

