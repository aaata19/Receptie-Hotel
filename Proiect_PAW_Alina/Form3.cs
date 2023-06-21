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

namespace Proiect_PAW
{
    public partial class Form3 : Form
    {
        List<Camere> listaCam = new List<Camere>();

        public Form3()
        {
            InitializeComponent();
            incarcaDate();
            int liber = 0;
            foreach (Camere c in listaCam )
                if(c.Ocupat == false)
                    liber++;
            tbData.Text = liber + " camere libere";
        }

        private void tbData_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lbData_Click(object sender, EventArgs e)
        {
            //nimic
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lbData.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy, hh:mm tt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //trimitere alt form unde se cauta rezerv
            Form4 form4 = new Form4(listaCam);  
            form4.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void incarcaDate()
        {
            StreamReader sr = new StreamReader("Camere.txt");
            string linie = null;
            while((linie = sr.ReadLine()) != null)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.ShowDialog();
        }
    }
}
