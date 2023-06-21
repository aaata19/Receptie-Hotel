using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace Proiect_PAW
{
    public partial class Form4 : Form
    {
        List<Rezervare> rezervareList = new List<Rezervare>();

        public Form4(List<Camere> listaCam)
        {
            InitializeComponent();
            incarcaDate();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float plata = 0;
            //neok trb sa vad cum caut in baza de date si adaug
            try
            {

                int id = Convert.ToInt32(tbID.Text);
                Rezervare re = new Rezervare();
                int ok = 0;
                foreach (Rezervare rez in rezervareList)
                {
                    if (rez.Cod == id)
                    {
                        ok = 1;
                        MessageBox.Show(rez.ToString() + " " + rez.Mesaj());
                        re = (Rezervare)rez.Clone();
                        rez.Ocupat();
                        break;
                    }
                }
                if (ok == 0)
                {
                    MessageBox.Show("Clientul nu are rezervare!");
                }

                plata = re.CalculTotal();
                tbLei.Text = plata.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tbLei.Text = plata.ToString();
                //calcul plata in alta moneda

                //StreamReader sr = new StreamReader("nbrfxrates.xml");
                //string str = sr.ReadToEnd();
                //sr.Close();

                WebRequest r = WebRequest.Create("https://www.bnr.ro/nbrfxrates.xml");
                WebResponse res = r.GetResponse();
                using (StreamReader sr2 = new StreamReader(res.GetResponseStream()))
                {
                    XmlReader reader = XmlReader.Create(sr2);
                    while (reader.Read())
                    {
                        if (reader.Name == "Rate" && reader.NodeType ==
                            XmlNodeType.Element)
                        {
                            string atribut = reader["currency"];
                            if (atribut == "EUR")
                            {
                                reader.Read();
                                float curs = float.Parse(reader.Value, CultureInfo.InvariantCulture.NumberFormat);
                                tbEUR.Text = (plata / curs).ToString();
                            }
                            else
                                if (atribut == "USD")
                            {
                                reader.Read();
                                float curs = float.Parse(reader.Value, CultureInfo.InvariantCulture.NumberFormat);
                                tbUSD.Text = (plata / curs).ToString();
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
        }

        private void incarcaDate()
        {
            StreamReader sr = new StreamReader("Rezervari.txt");
            string linie = null;
            while ((linie = sr.ReadLine()) != null)
            {
                string[] words = linie.Split(';');
                int etaj = Convert.ToInt32(words[5]);
                int numar = Convert.ToInt32(words[4]);
                float pret = float.Parse(words[7], CultureInfo.InvariantCulture.NumberFormat);

                Camere c = new Camere(etaj, numar, pret, words[6]);
                Rezervare r = new Rezervare(Convert.ToInt32(words[2]), words[0], words[1], words[3], Convert.ToInt32(words[8]), c);

                rezervareList.Add(r);
            }
            sr.Close();
        }
    }
}
