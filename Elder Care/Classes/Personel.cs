using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elder_Care.Classes
{
    public class Personel
    {
        public int id { get; set; }
        public string navn { get; set; }
        public BigInteger telefon { get; set; }
        public string brugernavn { get; set; }
        public string password { get; set; }
        public int institution { get; set; }

        public Personel() { }
        public Personel(int id, string navn, BigInteger telefon, string brugernavn, string password, int institution)
        {
            this.id = id;
            this.navn = navn;
            this.telefon = telefon;
            this.brugernavn = brugernavn;
            this.password = password;
            this.institution = institution;
        }
    }
}
