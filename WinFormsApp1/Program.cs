using System.Threading;
using System.Windows.Forms;
using WinFormsApp1;

namespace WinFormsApp1
{
    internal static class ApplicationEntry
    {
        private static Mutex appMutex = new Mutex(true, "UniqueAppMutex");

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
