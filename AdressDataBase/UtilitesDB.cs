using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AdressDataBase
{
    public class UtilitesDB : DbContext
    {
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Message> Messages { get; set; }
    }

    public class Adress
    {
        public int AdressID { get; set; }
        public string AdressText { get; set; }
    }
    public class Message
    {
        public int MessageID { get; set; }
        public int MessageType { get; set; }
        public DateTime dateTime { get; set; }
        public string MessageText { get; set; }
    }
}
