using ProjektStatki.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Controllers
{
    public class MainController
    {
        MainMenu menu; 
        MyDbContext db;
        PlayerController playerController;
        protected string LoggedUserId ="";
        public MainController(MyDbContext db)
        {
            this.db = db;
            menu = new MainMenu(db);
        }

        public void Run()
        {
            LoggedUserId = "";
            InitElements();
            LoggedUserId = menu.Run();
            if(!(string.IsNullOrEmpty(LoggedUserId)))
            {
                //Loguje użytkownika
                playerController = new PlayerController(db, LoggedUserId);
                playerController.RunController();
            }
        }

        public void InitElements()
        {

        }
    }
}
