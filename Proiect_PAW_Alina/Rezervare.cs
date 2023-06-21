using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proiect_PAW
{
    [Serializable]
    public class Rezervare : Client, ICloneable, IComparable, IEliberare
    {
        private int nrNopti;
        private float total;

        private Camere camera;

        public Rezervare() : base()
        {
            nrNopti = 0;
            total = 0;
            camera = new Camere();
            camera.Ocupat = true;
        }

        public Rezervare(int cod, string nume, string prenume, string telefon, int nrNopti, Camere camera) : base(cod, nume, prenume, telefon)
        {
            this.nrNopti = nrNopti;
            this.camera = camera;
            total = CalculTotal();
            camera.Ocupat = true;
        }


        public int NrNopti { get => nrNopti; set => nrNopti = value; }
        public float Total
        { get => total; 
          set => total = value; }

        public void Ocupat()
        {
            this.camera.Ocupat = true;
        }

        public float CalculTotal()
        {
            float rezultat = 0.0f;
            rezultat = this.camera.PretNoapte * nrNopti;
            return rezultat;
        }

        public override string ToString()
        {
            return base.ToString() + " sta " + nrNopti + " nopti in " + camera + " si are de achitat " + CalculTotal() + " lei"; 
        }

        public string ScrieFisier()
        {
            return base.ScrieFisiertxt() + ";" + camera.ScrieFisier() + ";" + nrNopti;
        }

        public object Clone()
        {
            Rezervare r = (Rezervare)MemberwiseClone();
            return r;
        }

        public int CompareTo(object obj)
        {
            Rezervare r = (Rezervare)obj;
            if ((float)this < (float)r)
                return -1;
            else if ((float)this > (float)r)
                return 1;
            else
                return 0;
        }

        public DateTime dataEliberare()
        {
            DateTime dateTime = DateTime.Now;
            return dateTime.AddDays(NrNopti);
        }

        public override string Mesaj()
        {
            string s = " trebuie sa elibereze camera pe data de: ";
            s += dataEliberare().ToString("dddd, dd MMMM yyyy");
            return s;
        }

        public static explicit operator float(Rezervare r)
        {
            return r.CalculTotal();
        }
    }
}
