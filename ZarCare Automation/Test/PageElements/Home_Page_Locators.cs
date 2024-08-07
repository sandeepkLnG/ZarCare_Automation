namespace ZarCare_Automation.Test.PageElements
{
    public class Home_Page_Locators : WebdriverSession
    {
        public By By_BannerText = By.XPath("//article[@class='hero-banner-txt']/h1/span");
        public IWebElement Web_BannerText => driver.FindElement(By_BannerText);

        public By By_ConsultNow_Button = By.XPath("//article[@class='hero-banner-txt']/a");
        public IWebElement Web_ConsultNow_Button => driver.FindElement(By_ConsultNow_Button);

        public By By_AboutUs_Link = By.LinkText("About Us");
        public IWebElement Web_AboutUs_Link => driver.FindElement(By_AboutUs_Link);
    }
}