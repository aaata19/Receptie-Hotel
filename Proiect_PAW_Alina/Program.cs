using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_PAW
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());

            //Camere c1 =  new Camere(1, 12, 250.3f, "Dubla");
            //Console.WriteLine(c1);
            //Camere c2 = new Camere();
            //Console.WriteLine(c2);



            //Client cl1 = new Client();
            //Client cl2 = new Client(123, "Murgu", "Vasile", "0728035216");
            //Console.WriteLine(cl1);
            //Console.WriteLine(cl2);

            //Rezervare r1 = new Rezervare(123, "Murgu", "Vasile", "0728035216", 2, c1);
            //Console.WriteLine(r1);

        }
    }
}
