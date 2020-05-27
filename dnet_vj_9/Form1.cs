using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace dnet_vj_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            webBrowser1.DocumentCompleted += (o, e) =>
            {
                label1.Text = "Stranica prikazana!";
                label1.ForeColor = Color.Blue;
                progressBar1.Value = 100;
            };

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Uri adresa;

            if (Uri.TryCreate(textBox1.Text, UriKind.Absolute, out adresa))
            {
                webBrowser1.Navigate(adresa);
                textBox1.Text = "https://www.";

            }
            else
            {
                label1.Text = "Krivo upisan URL!";
                label1.ForeColor = Color.Red;
                progressBar1.Value = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("https://www.google.hr");
                textBox1.Text = "https://www.";


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
            textBox1.Text = "https://www.";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            textBox1.Text = "https://www.";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            textBox1.Text = "https://www.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //niti
            ThreadStart delegat = new ThreadStart(printaj);
            for (int i = 1; i < 6; i++)
            {
                Thread thread = new Thread(delegat);
                thread.Name = "nit broj: " + i.ToString();
                thread.Start();
                Thread.Sleep(2000);

            }
            void printaj()
            {
                Debug.WriteLine(Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    Debug.WriteLine(i + "\n");
                }
            }
        }
    }
}
