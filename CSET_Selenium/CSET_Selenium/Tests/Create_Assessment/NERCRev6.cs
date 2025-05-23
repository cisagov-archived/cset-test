﻿using CSET_Selenium.Page_Objects.Maturity_Models;
using CSET_Selenium.Repository.Landing_Page;
using CSET_Selenium.Repository.Login_Page;
using Shared = CSET_Selenium.Repositories.Shared;
using NERC6 = CSET_Selenium.Repositories.NERC_Rev_6;
using NERC6DT = CSET_Selenium.Repositories.NERC_Rev_6.Data_Types;
using CSET_Selenium.Page_Objects.ReportPages;
using NERC6Pages = CSET_Selenium.Page_Objects.AssessmentQuesitons.NERCRev6;
using CSET_Selenium.DriverConfiguration;
using CSET_Selenium.Page_Objects.Assessment_Configuration;
using CSET_Selenium.Page_Objects.AssessmentInfo;
using NUnit.Framework;
using OpenQA.Selenium;
using FluentAssertions;
using CSET_Selenium.Page_Objects.Security_Assurance_Level;
using CSET_Selenium.Repositories.NERC_Rev_6.Data_Types;
using OpenQA.Selenium.DevTools.V130.Network;

namespace CSET_Selenium.Tests.Create_Assessment
{
    [TestFixture]
    class NERCRev6 : BaseTest
    {
        private IWebDriver driver;

        [Test]
        public void CreateAssessmentTest()
        {
            BaseConfiguration cf = new BaseConfiguration("http://csetac:5777");
            driver = BuildDriver(cf);
            Assert.That(driver.Title.Contains("CSET"));

            using (Shared.AssessmentRepository sharedRepo = new Shared.AssessmentRepository())
            {
                this.TestAssessmentLoginPage(driver, sharedRepo);

                this.TestAssessmentConfiguationPage(driver, sharedRepo);

                this.TestAssessmentInfoPage(driver, sharedRepo);

                this.TestAssessmentSecurityPage(driver, sharedRepo);                  

                using (NERC6.NERCRev6Repository nercRepo = new NERC6.NERCRev6Repository())
                {
                    // STANDARD QUESTIONS
                    this.TestStandardQuestionsPage(driver, nercRepo);

                    // move to analysis dashboard page
                    this.TestControlPrioritiesPage(driver, nercRepo);

                    // move to Standards Summary page
                    this.TestStandardsSummaryPage(driver, nercRepo);

                    // move to Ranked Categories page
                    this.TestRankedCategoriesPage(driver, nercRepo);

                    // move to Results by Category page
                    this.TestResultsByCategoryPage(driver, nercRepo);

                    // move to Hight Level Asessment page
                    this.TestHighLevelAssessmentPage(driver, nercRepo);

                    // move to Reports page
                    this.TestReportsPage(driver, nercRepo);

                    //Feedback Page
                    this.TestFeebackPage(driver, nercRepo);
                }
            }
        }

        private void TestAssessmentLoginPage(IWebDriver driver, Shared.AssessmentRepository sharedRepo)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToCSET("william.martin@inl.gov", "+L|=!yDx(`zU8|c=E:6*)?)S!k:XynL!5Vi39|:?8kp'uMB9X'");

            LandingPage nercRev6Assessment = new LandingPage(driver);
            nercRev6Assessment.OpenNewAssessment();
            nercRev6Assessment.NERCRev6CreateAssessment();
        }

        private void TestAssessmentConfiguationPage(IWebDriver driver, Shared.AssessmentRepository sharedRepo)
        {
            // access shared repository to set assessment configuation
            AssessmentConfiguration configurationPage = new AssessmentConfiguration(driver);
            configurationPage.CreateNERCRev6Assessment(sharedRepo.AssessmentConfig);

            configurationPage.ClickNext();
        }

        private void TestAssessmentInfoPage(IWebDriver driver, Shared.AssessmentRepository sharedRepo)
        {
            AssessmentInfo assessmentInfo = new AssessmentInfo(driver);
            assessmentInfo.SetAssessmentInformation(sharedRepo.AssessmentInfo);

            assessmentInfo.ClickNext();
        }

        private void TestAssessmentSecurityPage(IWebDriver driver, Shared.AssessmentRepository sharedRepo)
        { 
            SecurityAssuranceLevel securityPage = new SecurityAssuranceLevel(driver);
            securityPage.SetSecurityLevels(sharedRepo.SecurityAssuranceLevel());

            securityPage.ClickNext();
        }

        private void TestStandardQuestionsPage(IWebDriver driver, NERC6.NERCRev6Repository nercRepo)
        {
            // ARRANGE

            // STANDARD QUESTIONS
            // allocate Standard Questions Page
            NERC6Pages.StandardQuestions questionsPage = new NERC6Pages.StandardQuestions(driver);

            // get data from repository
            StandardQuestions questionsData = nercRepo.AccessStandardQuestionsData();

            // ACT

            // if instance is valid
            if (questionsData.IsValid())
            {
                // set question answers
                questionsPage.SetQuestionValues(questionsData);
            }

            // ASSERT

            questionsPage.ClickNext();
        }

        // move to analysis dashboard page
        private void TestControlPrioritiesPage(IWebDriver driver, NERC6.NERCRev6Repository nercRepo)
        {
            ControlPrioritiesPage controlPrioritiesPage = new ControlPrioritiesPage(driver);

            controlPrioritiesPage.ClickNext();
        }

        // move to Standards Summary page
        private void TestStandardsSummaryPage(IWebDriver driver, NERC6.NERCRev6Repository nercRepo)
        {
            StandardsSummaryPage standardsSummaryPage = new StandardsSummaryPage(driver);

            standardsSummaryPage.ClickNext();
        }

        // move to Ranked Categories page
        private void TestRankedCategoriesPage(IWebDriver driver, NERC6.NERCRev6Repository nercRepo)
        {
            RankedCategoriesPage rankedCategoriesPage = new RankedCategoriesPage(driver);

            rankedCategoriesPage.ClickNext();
        }

        // move to Results by Category page
       
        private void TestResultsByCategoryPage(IWebDriver driver, NERC6.NERCRev6Repository nercRepo)
        {
            ResultsByCategoryPage resultsByCategoryPage = new ResultsByCategoryPage(driver);

            resultsByCategoryPage.ClickNext();
        }

        // move to Hight Level Asessment page
        private void TestHighLevelAssessmentPage(IWebDriver driver, NERC6.NERCRev6Repository nercRepo)
        {
            HighLevelAssessmentPage highLevelAssessmentPage = new HighLevelAssessmentPage(driver);

            highLevelAssessmentPage.ClickNext();
        }

        // move to Reports page
        private void TestReportsPage(IWebDriver driver, NERC6.NERCRev6Repository nercRepo)
        {
            ReportsPage reportsPage = new ReportsPage(driver);

            reportsPage.ClickNext();
        }

        //Feedback Page
        private void TestFeebackPage(IWebDriver driver, NERC6.NERCRev6Repository nercRepo)
        {
            FeedbackPage feedbackPage = new FeedbackPage(driver);
        }
    }
}
