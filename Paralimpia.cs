using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalimpiaGUI
{
    class Paralimpia
    {
        public int Id { get; set; }
        public string Orszag { get; set; }
        public string Varos { get; set; }
        public int Ev { get; set; }
        public int Arany { get; set; }
        public int Ezust { get; set; }
        public int Bronz { get; set; }

        public Paralimpia(string sor)
        {
            var temp = sor.Split('\t');
            Id = int.Parse(temp[0]);
            Orszag = temp[1];
            Varos = temp[2];
            Ev = int.Parse(temp[3]);
            Arany = int.Parse(temp[4]);
            Ezust = int.Parse(temp[5]);
            Bronz = int.Parse(temp[6]);
        }
    }
}
