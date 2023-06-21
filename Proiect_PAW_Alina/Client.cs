using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PAW
{
    [Serializable]
    public abstract class Client : ICloneable
    {
        private int cod;
        private string nume;
        private string prenume;
        private string telefon;

        public Client()
        {
            cod = 0;
            nume = "Doe";
            prenume = "Jane";
            telefon = "0000000000";
        }

        public Client(int cod, string nume, string prenume, string telefon)
        {
            this.cod = cod;
            this.nume = nume;
            this.prenume = prenume;
            this.telefon = telefon;
        }

        public int Cod { get => cod; set => cod = value; }
        public string Nume { get => nume; set => nume = value; }
        public string Prenume { get => prenume; set => prenume = value; }
        public string Telefon { get => telefon; set => telefon = value; }

        public override string ToString()
        {
            return "Clientul " + nume + " " + prenume + " are id-ul " + cod + " si numarul de telefon " + telefon;
        }
        public string ScrieFisiertxt()
        {
            return nume + ";" + prenume + ";" + cod + ";" + telefon;
        }

        public object Clone()
        {
            Client c = (Client)this.MemberwiseClone();
            return c;
        }

        public abstract string Mesaj();

    }
}
