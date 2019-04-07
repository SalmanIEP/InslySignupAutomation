using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
namespace InslySignupAutomationFramework.Objects_Repo
{
   public class Signup_Page
    {

        IWebDriver driver;
        public Signup_Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement heading_title
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("body > main > div > div > div > h1"));
            }
            
        }
        public IWebElement txt_CompanyName
        {
            get
            {
                return this.driver.FindElement(By.Id("broker_name"));
            }

        }

        public IWebElement option_Country
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='broker_address_country']/option[168]"));
            }

        }
        public IWebElement Txt_YouInslyAdress
        {
            get
            {
                return this.driver.FindElement(By.Id("broker_tag"));
            }

        }
        public IWebElement option_CompanyProfile
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='prop_company_profile']/option[3]"));
            }

        }
        public IWebElement option_NumberOfEmployee
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='prop_company_no_employees']/option[4]"));
            }

        }
        public IWebElement option_DescribeYourSelf
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='prop_company_person_description']/option[3]"));
            }

        }

        public IWebElement ScrollTo_Administrator
        {
            get
            {
                return this.driver.FindElement(By.Id("submit_save"));
            }

        }
        public IWebElement txt_workEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("broker_admin_email"));
            }

        }
        public IWebElement txt_AccountManagerName
        {
            get
            {
                return this.driver.FindElement(By.Id("broker_admin_name"));
            }

        }
        public IWebElement link_SuggestaSecurePassword
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("#field_broker_person_password > td:nth-child(2) > div > a"));
            }

        }
        public IWebElement Secure_Password
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("#insly_alert > b"));
            }

        }
        public IWebElement Btn_ok
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("body > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-draggable.ui-dialog-buttons > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button"));
            }

        }
        public IWebElement txt_Phone
        {
            get
            {
                return this.driver.FindElement(By.Id("broker_admin_phone"));
            }

        }
        public IWebElement link_termsAndConditions
        {
            get
            {
                return this.driver.FindElement(By.LinkText("terms and conditions"));
            }

        }
        public IWebElement link_BtnAccept
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("body > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-draggable.ui-dialog-buttons > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button.primary"));
            }

        }
      

        public IWebElement link_PrivacyPolicy
        {
            get
            {
                return this.driver.FindElement(By.LinkText("privacy policy"));
            }

        }
        public IWebElement icon_ClosePopup
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("body > div:nth-child(6) > div.ui-dialog-titlebar.ui-widget-header.ui-corner-all.ui-helper-clearfix > a"));
            }

        }
        public IWebElement btn_SignUp
        {
            get
            {
                return this.driver.FindElement(By.Id("submit_save"));
            }

        }

        public IWebElement Chk_PrivacyPolicy
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("#field_terms > td:nth-child(2) > div > div > label:nth-child(4)>input"));
            }

        }
        public IWebElement Chk_ProcessingAndStorage
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("#field_terms > td:nth-child(2) > div > div > label:nth-child(6)>input"));
            }

        }
        public IWebElement popup_Scroll
        {

            get
            {
                return this.driver.FindElement(By.CssSelector("body > div:nth-child(6)"));
            }


        }


    }

}


