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
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;
using System.Drawing.Printing;

namespace Proiect_PAW
{
    public partial class Form2 : Form
    {
        float[] vect = new float[20];
        int nrElem = 0;
        bool vb = false;
        List<Rezervare> lista2;
        List<Camere> lista2c;
        Graphics gr;
        const int marg = 10;
        Color culoare = Color.Azure;


        public Form2(List<Rezervare> lista, List<Camere> listaCam)
        {
            InitializeComponent();
            lista2 = lista;
            foreach (Rezervare r in lista)
                textBox1.Text += r.ToString() + Environment.NewLine;
            lista2c = listaCam;
            panel1.Visible = false;
            foreach (Camere c in lista2c)
            {
                vect[nrElem] = c.PretNoapte;
                nrElem++;
                vb = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void salveaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "(*.txt) |*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, append:true);
                string scris = "";
                foreach (Rezervare r in lista2)
                {
                    scris += r.ScrieFisier() + Environment.NewLine;
                }
                sw.WriteLine(scris);
                // sw.WriteLine(textBox1.Text);
                sw.Close();
                textBox1.Clear();
            }
            panel1.Visible = false;
            MessageBox.Show("Date salvate!");

        }

        private void citesteFisierTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string line;
                StreamReader sr = new StreamReader(openFileDialog1.FileName);

                // citire fisier linie cu linie si adaugare rezerv in lista
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');
                    int etaj = Convert.ToInt32(words[5]);
                    int numar = Convert.ToInt32(words[4]);
                    float pret = float.Parse(words[7], CultureInfo.InvariantCulture.NumberFormat);

                    Camere c = new Camere(etaj, numar, pret, words[6]);
                    Rezervare r = new Rezervare(Convert.ToInt32(words[2]), words[0], words[1], words[3], Convert.ToInt32(words[8]), c);

                    lista2.Add(r);
                }

                sr.Close();

                foreach (Rezervare r in lista2)
                {
                    textBox1.Text += r.ToString() + Environment.NewLine;
                }
            }
            panel1.Visible = false;
            MessageBox.Show("Date citite!");
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("serializare.dat", FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, lista2);
            fs.Close();
            textBox1.Clear();
            panel1.Visible = false;
            MessageBox.Show("Date serializate!");
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("serializare.dat", FileMode.Open, FileAccess.Read);
            List<Rezervare> lista3 = (List<Rezervare>)bf.Deserialize(fs);
            foreach (Rezervare r in lista3)
                textBox1.Text += r.ToString() + Environment.NewLine;
            fs.Close();
            panel1.Visible = false;
            MessageBox.Show("Date deserializate!");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void graficPretToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (vb == true)
            {
                panel1.Visible = true;
                Rectangle rec = new Rectangle(panel1.ClientRectangle.X + marg,
                    panel1.ClientRectangle.Y + 2 * marg,
                    panel1.ClientRectangle.Width - 2 * marg,
                    panel1.ClientRectangle.Height - 3 * marg);
                Pen pen = new Pen(Color.Red, 3);
                gr.DrawRectangle(pen, rec);

                double latime = rec.Width / nrElem / 2;
                double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
                double vMax = vect.Max();

                Brush br = new SolidBrush(culoare);

                Rectangle[] recs = new Rectangle[nrElem];
                for (int i = 0; i < nrElem; i++)
                {
                    recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                        (int)(rec.Location.Y + rec.Height - vect[i] / vMax * rec.Height),
                        (int)latime,
                        (int)(vect[i] / vMax * rec.Height));
                    //gr.FillRectangle(br, recs[i]);
                    //gr.FillEllipse(br, recs[i]);
                    //gr.DrawRectangle(pen, recs[i]);
                    gr.DrawString(vect[i].ToString(), this.Font,
                        new SolidBrush(Color.Black), (int)(recs[i].Location.X + latime / 2 - 5),
                        (int)(recs[i].Location.Y + recs[i].Height / 2 - this.Font.Height));
                    gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2), recs[i].Location.Y),
                            new Point((int)(recs[i].Location.X + latime / 2), recs[i].Location.Y + recs[i].Height));
                }

            }
        }
        private void printareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            if (vb == true)
            {
                gr = e.Graphics;
                Rectangle rec = new Rectangle(e.PageBounds.X + marg,
                    e.PageBounds.Y + 2 * marg,
                    e.PageBounds.Width - 2 * marg,
                    e.PageBounds.Height - 3 * marg);
                Pen pen = new Pen(Color.Red, 3);
                gr.DrawRectangle(pen, rec);

                double latime = rec.Width / nrElem / 2;
                double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
                double vMax = vect.Max();

                Brush br = new SolidBrush(culoare);

                Rectangle[] recs = new Rectangle[nrElem];
                for (int i = 0; i < nrElem; i++)
                {
                    recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                        (int)(rec.Location.Y + rec.Height - vect[i] / vMax * rec.Height),
                        (int)latime,
                        (int)(vect[i] / vMax * rec.Height));
                    //gr.FillRectangle(br, recs[i]);
                    //gr.FillEllipse(br, recs[i]);
                    //gr.DrawRectangle(pen, recs[i]);
                    gr.DrawString(vect[i].ToString(), this.Font,
                        new SolidBrush(Color.Black), (int)(recs[i].Location.X + latime / 2 - 5),
                        (int)(recs[i].Location.Y + recs[i].Height / 2 - this.Font.Height));

                }
                //gr.FillRectangles(br, recs);
                for (int i = 0; i < nrElem - 1; i++)
                    gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2),
                        recs[i].Location.Y),
                        new Point((int)(recs[i + 1].Location.X + latime / 2),
                        recs[i + 1].Location.Y));
            }
        }

        private void previzualizeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
