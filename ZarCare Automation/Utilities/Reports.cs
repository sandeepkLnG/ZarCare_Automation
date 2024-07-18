namespace ZarCare_Automation.Utilities
{
    public class Reports
    {
        public static ExtentReports extent { get; set; }
        public static ExtentReports extentReports { get; set; }
        public static ExtentTest parentLog { get; set; }
        public static ExtentTest childLog { get; set; }
        public static string reportFilePath { get; set; }
        public static string reportFolderName { get; set; }
        public static string screenshotFolderName { get; set; }

        public static ExtentReports StartExtentReport(string classname)
        {
            reportFolderName = Properties.report + classname + " " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss").Trim();
            Directory.CreateDirectory(reportFolderName);

            reportFilePath = reportFolderName + @"\\ExtentReport.html";

            screenshotFolderName = Path.Combine(reportFolderName, "Screenshots");
            Directory.CreateDirectory(screenshotFolderName);

            //Creating an object for the ExtentHtmlReporter class that will store the report in the given file path
            var htmlreporter = new ExtentHtmlReporter(reportFilePath);

            //Creating an object of the Extend Report class
            extent = new ExtentReports();
            extent.AttachReporter(htmlreporter);
            extent.AddSystemInfo("Application", "ZarCare Automation");
            extent.AddSystemInfo("Browser", Properties.browser);
            extent.AddSystemInfo("Environment", Properties.environment);
            extent.AddSystemInfo("QA", Properties.QA);
            return extent;
        }

        public static void StopExtendReport()
        {
            extentReports.Flush();
        }

        public static ExtentTest CreateTest(string testname)
        {
            return extent.CreateTest(testname);
        }

        public static ExtentTest CreateNode(string node)
        {
            return parentLog.CreateNode(node);
        }

        public static void FlushNode(ExtentTest test)
        {
            parentLog.RemoveNode(test);
        }

    }
}
