namespace ZarCare_Automation.Utilities
{
    public class Base : Generic_Utils
    {
        public string classname = TestContext.CurrentContext.Test.Name;

        [OneTimeSetUp]
        public void ReportInitilization()
        {
            Reports.extentReports = Reports.StartExtentReport(classname);
        }

        [SetUp]
        public void Setup()
        {
            Generic_Utils.Initilize_Browser(Properties.browser.ToLower());
            Generic_Utils.BrowserMaximize();

            Reports.parentLog = Reports.CreateTest(classname);
        }

        [TearDown]
        public void close()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    Reports.parentLog.Fail("Test Fail", MediaEntityBuilder.CreateScreenCaptureFromPath(Generic_Utils.CaptureFailScreenshot()).Build());
                    Reports.parentLog.Log(Status.Fail, "Test Fail with Log Trace " + TestContext.CurrentContext.Result.StackTrace);
                }
                else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    Reports.parentLog.Pass("Test Pass", MediaEntityBuilder.CreateScreenCaptureFromPath(Generic_Utils.CapturePassScreenshot()).Build());
                }
            }
            catch (Exception e)
            {
                Reports.parentLog.Fail("Test Fail reason due to " + e, MediaEntityBuilder.CreateScreenCaptureFromPath(Generic_Utils.CaptureFailScreenshot()).Build());
            }

            Wait.GenericWait(3000);
            Generic_Utils.CloseDriver();
        }

        [OneTimeTearDown]
        public void ReportClose()
        {
            Reports.StopExtendReport();
        }
    }
}
