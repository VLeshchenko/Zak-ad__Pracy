using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZakładPracy
{

    public class Pracownik
    {
        
        public int Id { get; set; }
        public string ImieNasw { get; set; }
        public DateTime DataUrodz { get; set; }
        public string Stanowisko { get; set; }
        public float StawkaGodz { get; set; }
        public float Pensja { get; set; }
    }
}
