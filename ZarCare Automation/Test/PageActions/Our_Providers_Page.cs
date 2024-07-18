namespace ZarCare_Automation.Test.PageActions
{
    public class Our_Providers_Page : WebdriverSession
    {
        public static Our_Providers_Page_Locators OurProvidersPage = new Our_Providers_Page_Locators();

        public static void Validate_OurProviderPage()
        {
            Wait.WaitTillPageLoad();
            Generic_Utils.IsElementDisplayed(OurProvidersPage.By_SearchHeader);

            Reports.childLog.Log(Status.Info, "Our Providers page is displayed");
            Generic_Utils.GetScreenshot("Our Providers screenshot");

        }

        public static void Search_Doctor(string doctorName)
        {
            OurProvidersPage.Web_Doctor_SearchBox.SendKeys(doctorName);
            Wait.GenericWait(1000);
            OurProvidersPage.Web_Doctor_SearchButton.Click();
        }

        public static void FetchDoctorFromList(string doctorName)
        {
            int dr_list = driver.FindElements(OurProvidersPage.By_Doctor_List).Count;

            for (int a = 0; a < dr_list; a++)
            {
                string dr_name = driver.FindElements(OurProvidersPage.By_Doctor_Name)[a].Text;

                if (dr_name.Contains(doctorName))
                {
                    driver.FindElements(OurProvidersPage.By_Doctor_Name)[a].Click();
                    break;
                }
            }
        }

    }
}
