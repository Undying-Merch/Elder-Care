using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.QrCode.Internal;

namespace Elder_Care.Classes
{
    public class Person
    {
        public int id { get; set; }
        public string navn { get; set; }
        public DateTime fodselsdag { get; set; }
        public string qr { get; set; }
        public int institutionId { get; set; }

        public Person() { }
        public Person(int id, string navn, DateTime fodselsdag, string qr, int institutionId)
        {
            this.id = id;
            this.navn = navn;
            this.fodselsdag = fodselsdag;
            this.qr = qr;
            this.institutionId = institutionId;
        }
    }
}
