using AdmissionComitteeDataGrid.Forms;
using Services;
using Services.Contracts;

namespace AdmissionComitteeDataGrid
{
    /// <summary>
    /// Класс запуска программы
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            IApplicantStorage applicantStorage = new InMemoryStorage();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(applicantStorage));
        }
    }
}
