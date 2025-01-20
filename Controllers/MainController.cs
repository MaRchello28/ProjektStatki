using ProjektStatki.Models.Data;
using ProjektStatki.Models.ElementsToUnlock;
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
        List<Element> elements;
        protected string LoggedUserId ="";
        public MainController(MyDbContext db)
        {
            this.db = db;
            menu = new MainMenu(db);
            elements = new List<Element>();
        }

        public void Run()
        {
            LoggedUserId = "";
            InitElements();
            LoggedUserId = menu.Run();
            if(!(string.IsNullOrEmpty(LoggedUserId)))
            {
                //Loguje użytkownika
                playerController = new PlayerController(db, LoggedUserId,elements);
                playerController.RunController();
            }
        }

        public void InitElements()
        {
            elements.Add(new SkinElement("Skin", 4, "Pink"));
            elements.Add(new GameModeElement("GameMode", 6, "Specjalne Statki"));
        }
    }
}
