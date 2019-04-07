using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;
using InslySignupAutomationFramework.Objects_Repo;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using InslySignupAutomationFramework.Helping_methods;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace InslySignupAutomationFramework.Steps
{
    [Binding]
    
    public sealed class Signup_Page_Steps
    {
        IWebDriver driver;
        Signup_Page action;
        Helper help;

        string CompanyName;
        string WorkEmail;
        string ManagerName;
        Actions act;

        [Given(@"Go to Sign Up page of Insly")]
        public void GivenGoToSignUpPageOfInsly()
        {
            driver = new ChromeDriver();
            help = new Helper(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            action = new Signup_Page(driver);
            help = new Helper(driver);
            driver.Navigate().GoToUrl("https://signup.insly.com/signup");
            
        }

        [Then(@"Sign up and start using- title is shown there")]
        public void ThenSignUpAndStartUsing_TitleIsShownThere()
        {
            string Title = action.heading_title.Text;
            Assert.AreEqual("Sign up and start using", Title);
        }

        [When(@"Fill some random unique name in Company name")]
        public void WhenFillSomeRandomUniqueNameInCompanyName()
        {
            CompanyName = "Company" + help.RandomString(4);
            action.txt_CompanyName.SendKeys(CompanyName);
        }

        [Then(@"All data filled in")]
        public void ThenAllDataFilledIn()
        {
            string insertedCompanyName = action.txt_CompanyName.GetAttribute("value");
            Assert.AreEqual(CompanyName, insertedCompanyName);
        }
        [Then(@"Chose any country")]
        public void ThenChoseAnyCountry()
        {
            action.option_Country.Click();
        }

        [Then(@"Check address e\.g\.yourname\.incly\.com")]
        public void ThenCheckAddressE_G_Yourname_Incly_Com()
        {
            Thread.Sleep(1000);
            string InslyAdress = action.Txt_YouInslyAdress.GetAttribute("value");
            Assert.That(InslyAdress, Does.Contain(CompanyName.ToLower()));
        }

        [Then(@"Select any Company profile")]
        public void ThenSelectAnyCompanyProfile()
        {
            action.option_CompanyProfile.Click();
        }

        [Then(@"Select any Number of Employees")]
        public void ThenSelectAnyNumberOfEmployees()
        {
            action.option_NumberOfEmployee.Click();
        }

        [Then(@"Select any HOW WOULD YOU DESCRIBE YOURSELF\?")]
        public void ThenSelectAnyHOWWOULDYOUDESCRIBEYOURSELF()
        {
            action.option_DescribeYourSelf.Click();
        }
        [Then(@"Move to Administrator account details block")]
        public void ThenMoveToAdministratorAccountDetailsBlock()
        {

            act = new Actions(driver);
            act.MoveToElement(action.ScrollTo_Administrator);
        }

        [Then(@"Fill in Work e-mail")]
        public void ThenFillInWorkE_Mail()
        {
            WorkEmail = help.RandomString(5) + "@gmail.com";
            action.txt_workEmail.SendKeys(WorkEmail);
        }

        [Then(@"Fill in Acount Mangaer")]
        public void ThenFillInAcountMangaer()
        {
            ManagerName = "Manager ("+ help.RandomString(5) +")";
            action.txt_AccountManagerName.SendKeys(ManagerName);
        }

        [Then(@"Press suggest a Secure password and remember it")]
        public void ThenPressSuggestASecurePasswordAndRememberIt()
        {
            action.link_SuggestaSecurePassword.Click();
            String GenratedPassword = action.Secure_Password.Text;
            Console.WriteLine("The Secure Password is successfully genrated and is "+GenratedPassword);
            action.Btn_ok.Click();
        }

        [Then(@"Enter your phone number")]
        public void ThenEnterYourPhoneNumber()
        {
            action.txt_Phone.SendKeys(help.RandomNumbers(7));
        }

        [Then(@"Move to Terms and Conditions Section and Tick all Terms and conditions")]
        public void ThenMoveToTermsAndConditionsSectionAndTickAllTermsAndConditions()
        {

            IWebElement elel = driver.FindElement(By.CssSelector("#field_terms > td:nth-child(2) > div > div > label:nth-child(4)>input"));
            IWebElement ele2 = driver.FindElement(By.CssSelector("#field_terms > td:nth-child(2) > div > div > label:nth-child(6)>input"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", elel);
            executor.ExecuteScript("arguments[0].click();", ele2);

        }
        [Then(@"Click on terms and conditions link and agree")]
        public void ThenClickOnTermsAndConditionsLinkAndAgree()
        {
            action.link_termsAndConditions.Click();
            action.link_BtnAccept.Click();
            

        }

        [Then(@"Click on privacy policy link and scroll down, close popup")]
        public void ThenClickOnPrivacyPolicyLinkAndScrollDownClosePopup()
        {
            action.link_PrivacyPolicy.Click();
            driver.FindElement(By.CssSelector("#document-content > p:nth-child(42)")).Click();
            IWebElement scroll = driver.FindElement(By.CssSelector("body > div:nth-child(6)"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView();", scroll);
            Thread.Sleep(1000);
            action.icon_ClosePopup.Click();
            IWebElement ele2 = driver.FindElement(By.CssSelector("#field_terms > td:nth-child(2) > div > div > label:nth-child(2)>input"));
            executor.ExecuteScript("arguments[0].click();", ele2);
        }

        [Then(@"Sign up button get Active")]
        public void ThenSignUpButtonGetActive()
        {
            Assert.That(!action.btn_SignUp.GetAttribute("class").Contains("disabled"));
        }


        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

    }
}
