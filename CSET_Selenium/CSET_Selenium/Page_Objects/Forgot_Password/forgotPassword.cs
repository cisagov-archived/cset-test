﻿using CSET_Selenium.DriverConfiguration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSET_Selenium.Repository.Forgot_Password
{
    class ForgotPassword : BasePage
    {
        private readonly IWebDriver driver;

        public ForgotPassword(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //Element Locators

        private IWebElement textboxEmail
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[@name='email']"));
            }
        }

        private IWebElement buttonNext
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[contains(text(),'Next')]"));
            }
        }


        private IWebElement textlinkLogin
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//a[contains(text(),'Login')]"));
            }
        }

        private IWebElement textboxSecurityQuestionAnswer
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[@name='questionAnswer']"));
            }
        }

        private IWebElement buttonResetPassword
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[contains(text(),'Reset Password')]"));
            }
        }
    }
}
