using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace SelfCareProj
{
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
            Application.VisualStyleState = VisualStyleState.NoneEnabled;
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

    }
}