using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Proiect_PAW
{
    public partial class Form1 : Form
    {
        List<Rezervare> listaRezervari = new List<Rezervare>();
        List<Camere> listaCam = new List<Camere>();
        Rezervare r = new Rezervare();
        string connString;
        public Form1()
        {
            InitializeComponent();
            incarcaDate();
            connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DatabaseAlina.accdb";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            conexiune.Open();
            OleDbCommand comanda = new OleDbCommand();
            comanda.Connection = conexiune;
            try
                {
                    listaRezervari.Add(r);
                    salvRezerv();
                    salvCam();
                    //MessageBox.Show(r.ToString());

                //salv in baza de date un client nou 

                comanda.CommandText = "INSERT INTO rezervari VALUES(?,?,?,?,?,?)";
                comanda.Parameters.Add("ID", OleDbType.Integer).Value = tbID.Text;
                comanda.Parameters.Add("Nume", OleDbType.Char, 30).Value = tbNume.Text;
                comanda.Parameters.Add("Prenume", OleDbType.Char, 30).Value = tbPrenume.Text;
                comanda.Parameters.Add("Telefon", OleDbType.Char, 30).Value = tbTelefon.Text;
                comanda.Parameters.Add("Camera", OleDbType. Integer).Value = tbNumarCam.Text;
                comanda.Parameters.Add("Numar Nopti", OleDbType.Integer).Value = tbNrNopti.Text;

                comanda.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                    tbEtaj.Clear();
                    tbNumarCam.Clear();
                    tbPretNoapte.Clear();
                    cbTip.Text = "";

                    tbNrNopti.Clear();

                    tbTelefon.Clear();
                    tbNume.Clear();
                    tbPrenume.Clear();
                    tbID.Clear();
                    r = new Rezervare();
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(listaRezervari, listaCam);
            frm.ShowDialog();
        }

        private void incarcaDate()
        {
            StreamReader sr = new StreamReader("Camere.txt");
            string linie = null;
            while ((linie = sr.ReadLine()) != null)
            {
                string[] words = linie.Split(';');
                int etaj = Convert.ToInt32(words[1]);
                int numar = Convert.ToInt32(words[0]);
                float pret = float.Parse(words[3], CultureInfo.InvariantCulture.NumberFormat);
                Camere c = new Camere(etaj, numar, pret, words[2]);
                listaCam.Add(c);
            }
            sr.Close();
        }

        private void salvRezerv()
        {
            StreamWriter sr = new StreamWriter("Rezervari.txt", append: true);
            sr.WriteLine(r.ScrieFisier());
            sr.Close();
        }

        private void salvCam()
        {
            StreamWriter sw = new StreamWriter("Camere.txt");
            foreach(Camere c in listaCam)
            {
                sw.WriteLine(c.ScrieFisier());
            }
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //verifica datele clientului
            if (tbID.Text == "")
                errorProvider1.SetError(tbID, "Introduceti id!");
            else if (tbNume.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti numele!");
            else if (tbPrenume.Text == "")
                errorProvider1.SetError(tbPrenume, "Introduceti prenumele!");
            else if (tbTelefon.Text == "")
                errorProvider1.SetError(tbTelefon, "Introduceti numarul de telefon!");
            else if (cbTip.Text == "")
                errorProvider1.SetError(cbTip, "Alegeti tip camera!");
            else
            {
                try
                {
                    //citire client
                    int cod = Convert.ToInt32(tbID.Text);
                    string nume = tbNume.Text;
                    string prenume = tbPrenume.Text;
                    string telefon = tbTelefon.Text;

                    //citire inf dorite despre camera
                    string tip = cbTip.Text;

                    Camere ca = new Camere();
                    //cautare camera 
                    int ok = 0; 
                    foreach (Camere cam in listaCam)
                    {
                        if (string.Equals(cam.Tip, tip, StringComparison.OrdinalIgnoreCase))
                        {
                            ca.Tip = cam.Tip;
                            ca.Etaj = cam.Etaj;
                            ca.Numar = cam.Numar;
                            ca.PretNoapte = cam.PretNoapte;
                            ca.Ocupat = true;
                            cam.Ocupat = true;
                            ok = 1;
                            break;
                        }
                    }
                    if (ok == 0)
                    {
                        MessageBox.Show("Nu avem camere din acest tip disponibile!");
                    }
                    else
                    {
                        tbEtaj.Text = ca.Etaj.ToString();
                        tbNumarCam.Text = ca.Numar.ToString();
                        tbPretNoapte.Text = ca.PretNoapte.ToString();

                        //citire rezervare
                        int nrNopti = Convert.ToInt32(tbNrNopti.Text);
                        //creeaza rezervarea posibila
                        r = new Rezervare(cod, nume, prenume, telefon, nrNopti, ca);                
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


