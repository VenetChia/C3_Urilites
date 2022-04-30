using System;
using System.Data.Entity;
using System.Linq;
using AdressDataBase;
namespace ConsoleTestDB
{
    class Program
    {

        static void Main()
        {
            UtilitesDB _utilitesDB = new UtilitesDB();
            _utilitesDB.Adresses.Load();
            _utilitesDB.Messages.Load();
            _utilitesDB.Adresses.Add(new Adress() { AdressText = "Main@mail.ru" });
            _utilitesDB.SaveChanges();
        }
    }
}
