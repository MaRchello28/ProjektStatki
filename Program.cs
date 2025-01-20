using ProjektStatki.Models.Data;
using System.Windows.Forms;

namespace ProjektStatki
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MyDbContext db = new MyDbContext();

            MainMenu menu = new MainMenu(db);

            menu.Run();
        }
    }
}