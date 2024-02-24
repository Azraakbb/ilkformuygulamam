using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_ilkodev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bildirims.BalloonTipText = "Nesne Yönelimli Programlama Ödev 1" ;
            bildirims.BalloonTipTitle = "Programa Hoş geldiniz!"; //bildirim balonunun başlık ve metinini belirledik
            bildirims.ShowBalloonTip(4000);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string paragraf = textBox1.Text;
            string arananifade = textBox2.Text;

            if (string.IsNullOrEmpty(paragraf) || string.IsNullOrEmpty(arananifade)) //aranan ifade kutusu boş mu kontrol eder
            {
                MessageBox.Show("Lütfen metin ve aranacak ifadeyi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!kontrol(arananifade,metinkutusu.Checked,sayikutusu.Checked,karakterkutusu.Checked))
            {
                return; 
            }

            int arananifadeninuzunluk = arananifade.Length;
            int girilenmetinuzunluk = textBox1.Text.Length;
            int ilkgecen = paragraf.IndexOf(arananifade); //IndexOf ile paragrafta ilk geçtiği yer bulunur

            analizsonuc.Text = "Girilen metnin uzunluğu:" + girilenmetinuzunluk + Environment.NewLine;
            analizsonuc.Text += "Aranan metnin uzunluğu:" + arananifadeninuzunluk + Environment.NewLine;

            if (ilkgecen != -1)
            {
                analizsonuc.Text += "Aranan ifade metinde bulunuyor. Geçtiği ilk indeks: " + ilkgecen + Environment.NewLine;

            }
            else
            {
                analizsonuc.Text = "Aranan ifade bulunamadı"; // eşitlememizin sebebi metinde bulunmuyorsa bilgileri ekrana yazmaz
            }

            int sayac = 0;
            int index = 0;

            while ((index = paragraf.IndexOf(arananifade, index + 1)) != -1)
            {
                sayac++;
            }
            analizsonuc.Text += "Metinde kaç adet bulunuyor:";
            analizsonuc.Text += sayac.ToString(); //string değerine çevirir

            string analizsonucuekle = $"{listekutusu.Items.Count +1}. Metinde '{arananifade}' ifadesi aranmış ve {sayac} defa bulunmuştur. Metnin uzunluğu {girilenmetinuzunluk}'dır.";

            listekutusu.Items.Add(analizsonucuekle); //listekutusuna analiz sonuçlarını ekledik Add ile

        }

        private void button4_Click(object sender, EventArgs e)
        {
            analizsonuc.Clear(); //kutuyu temizler
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5; //sayfalar arası geçişi sağlayan komut
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listekutusu.Clear();
        }

        private void listekutusu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private bool kontrol(string arananifade,bool metin,bool sayi,bool karakter)
        {
            bool sayivar = false;
            bool karakterVar = false;
            bool metinvar = false;


            if (sayi)
            {
                foreach (char karktr in arananifade)
                {
                    if (char.IsNumber(karktr))
                    {
                        sayivar = true;
                        break;
                    }
                }
                if (!sayivar) //false ise anlamına gelir
                {
                    MessageBox.Show("Aranan ifade sayı içermemektedir ");
                    return false;
                }
            }


            if (karakter)
            {
                foreach (char sembol in arananifade)
                {
                    if (!char.IsLetterOrDigit(sembol)) // her ikisi de değilse karakter olarak kabul eder
                    {
                        karakterVar = true;
                    }
                }
                if (!karakterVar)
                {
                    MessageBox.Show("Aranan ifade karakter değil.");
                    return false;
                }


            }


            if (metin)
            {
                foreach (char metinn in arananifade)
                {
                    if (char.IsLetter(metinn))
                    {
                        metinvar=true;
                    }
                }
                if (!metinvar)
                {
                    MessageBox.Show("Aranan ifade metin içermemektedir.");
                    return false;

                }

            }
            return true;

        }

        private void karakterkutusu_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
