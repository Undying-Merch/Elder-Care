using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elder_Care.Classes
{
    public class institution
    {
        public int id { get; set; }
        public string navn { get; set; }
        public float telefon { get; set; }
        public string adresse { get; set; }
        public int postnummer { get; set; }

        public institution() { }
        public institution(int id, string navn, float telefon, string adresse, int postnummer)
        {
            this.id = id;
            this.navn = navn;
            this.adresse = adresse;
            this.telefon = telefon;
            this.postnummer = postnummer;
        }
    }

    public class allInstitutions
    {
        List<institution> institutions { get; set; }
    }
}
