using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Proiect_PAW
{
    [Serializable]
    public class Camere : ICloneable, IComparable
    {
        private int etaj;
        private int numar;
        private float pretNoapte;
        private string tip;
        private bool ocupat;

        public Camere()
        {
            etaj = 0;
            numar = 0;
            pretNoapte = 0;
            tip = "Fara";
            Ocupat = false;
        }
        public Camere(int etaj, int numar, float pretNoapte, string tip, bool ocupat)
        {
            this.etaj = etaj;
            this.numar = numar;
            this.pretNoapte = pretNoapte;
            this.tip = tip;
            this.Ocupat = ocupat;
        }

        public Camere(int etaj, int numar, float pretNoapte, string tip)
        {
            this.etaj = etaj;
            this.numar = numar;
            this.pretNoapte = pretNoapte;
            this.tip = tip;
        }

        public int Etaj { get => etaj; set => etaj = value; }
        public int Numar { get => numar; set => numar = value; }
        public float PretNoapte { get => pretNoapte; set => pretNoapte = value; }
        public string Tip { get => tip; set => tip = value; }
        public bool Ocupat { get => ocupat; set => ocupat = value; }

        public object Clone()
        {
            Camere c = (Camere)this.MemberwiseClone();
            return c;

        }

        public int CompareTo(object obj)
        {
            Camere a = (Camere)obj;
            if (this.pretNoapte < a.pretNoapte)
                return -1;
            else
                if (this.pretNoapte > a.pretNoapte)
                return 1;
            else
                return string.Compare(this.tip, a.tip);
        }

        public override string ToString()
        {
            string s = "Camera " + numar + " se afla la etajul " + etaj + " si e de tipul " + tip + " si costa: " + pretNoapte + " lei/noapte" + " si e ";
            s += ocupat == true ? "ocupat" : "liber";
            return s;

        }

        public string ScrieFisier()
        {
            return numar + ";" + etaj + ";" + tip + ";" + pretNoapte;
        }

    }
}
