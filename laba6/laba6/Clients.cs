using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public class Clients
    {
        public int id { get; }

        public string name { get; set; }

        public string surname { get; set; }

        public string middlename { get; set; }

        public string phoneNumber { get; set; }

        public string passportDate { get; set; }

        public Clients(int id, string name, string surname, string middlename, string phoneNumber, string passportDate)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.middlename = middlename;
            this.phoneNumber = phoneNumber;
            this.passportDate = passportDate;
        }

        public override string ToString()
        {
            return $"{id},ФИО: {name} {surname} {middlename}, Номер телефона:{phoneNumber}, Паспортные данные:{passportDate}";
        }
    }
}
