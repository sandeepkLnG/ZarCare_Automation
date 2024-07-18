namespace ZarCare_Automation.Test.PageActions
{
    public class Doctor_Profile_Page : WebdriverSession
    {
        public static Doctor_Profile_Page_Locators DoctorProfilePage = new Doctor_Profile_Page_Locators();

        public static void ValidateDoctorProfile()
        {
            Wait.WaitTillPageLoad();
            Generic_Utils.IsElementDisplayed(DoctorProfilePage.By_ProfileHeader);

            Reports.childLog.Log(Status.Info, "Doctor Profile page is displayed");
            Generic_Utils.GetScreenshot("Doctor Profile screenshot");
        }

        public static void BookAppointment(string appointmentDate, string appointmentTime)
        {
            //Select Appointment Date

            string Appointment_Currentdate = DoctorProfilePage.Web_BookingDateHeader_CurrentDate.Text;

            if (!Appointment_Currentdate.Equals(appointmentDate))
            {
                DoctorProfilePage.Web_BookingDate_ForwardButton.Click();
                Wait.GenericWait(1000);

                string Appointment_Nextdate = DoctorProfilePage.Web_BookingDateHeader_NextDate.Text;

                while (!Appointment_Nextdate.Equals(appointmentDate))
                {
                    DoctorProfilePage.Web_BookingDate_ForwardButton.Click();
                    Wait.GenericWait(1000);
                    Appointment_Nextdate = DoctorProfilePage.Web_BookingDateHeader_NextDate.Text;
                }
            }

            //Select Appointment Timeslot

            int slot_count = driver.FindElements(DoctorProfilePage.By_BookingSlot_Currentday).Count;

            for (int a = 0; a < slot_count; a++)
            {
                string slot_time = driver.FindElements(DoctorProfilePage.By_BookingSlot_Currentday)[a].Text;

                if(slot_time.Equals(appointmentTime))
                {
                    driver.FindElements(DoctorProfilePage.By_BookingSlot_Currentday)[a].Click();
                    break;
                }
            }

            Generic_Utils.GetScreenshot("Appointment Date and Time Selected");

        }
    }
}
