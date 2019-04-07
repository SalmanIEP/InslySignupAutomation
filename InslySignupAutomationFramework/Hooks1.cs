using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace InslySignupAutomationFramework
{
    [Binding]
    public sealed class Hooks1
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly IObjectContainer _objectContainer;
        public Hooks1(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
          
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            outPutDirectory = outPutDirectory.Substring(0, outPutDirectory.IndexOf("bin"));
            
            outPutDirectory = outPutDirectory.Substring(outPutDirectory.IndexOf("\\")+1);
            String path =Path.Combine(outPutDirectory, "TestResults\\index.html");
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        [AfterStep]
        public void InsertReportingSteps()
        {
          

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);
            //Pass status
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            //Failure Staus
            if(ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    ScenarioContext.Current.Pending();
                else if (stepType == "When")
                    ScenarioContext.Current.Pending();
                else if (stepType == "Then")
                    ScenarioContext.Current.Pending();
                else if (stepType == "And")
                    ScenarioContext.Current.Pending();

            }
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }
        [BeforeScenario]
        public void Initialize()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            
        }
       
      

    }
}
