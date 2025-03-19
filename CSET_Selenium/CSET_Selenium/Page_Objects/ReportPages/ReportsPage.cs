﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSET_Selenium.DriverConfiguration;

namespace CSET_Selenium.Page_Objects.ReportPages
{
    class ReportsPage : BasePage
    {
        private readonly IWebDriver driver;

        public ReportsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
    }
}
