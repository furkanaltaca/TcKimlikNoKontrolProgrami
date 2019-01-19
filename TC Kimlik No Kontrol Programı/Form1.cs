using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TC_Kimlik_No_Kontrol_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 11)
                MessageBox.Show("Geçerli TC kimlik numarası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(Convert.ToInt32(textBox1.Text[0].ToString())==0)
                MessageBox.Show("Geçerli TC kimlik numarası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int toplam1 = 0, toplam2 = 0, toplam3 = 0 ;
                for (int i = 0; i < 11; i++)
                {
                    if (i < 9)
                    {
                        if (i % 2 == 0) toplam1 += Convert.ToInt32(textBox1.Text[i].ToString());
                        else toplam2 += Convert.ToInt32(textBox1.Text[i].ToString());
                    }
                    if (i <= 9) toplam3 += Convert.ToInt32(textBox1.Text[i].ToString());
                }
                int a = ((toplam1 * 7) - toplam2)%10;
                int b = toplam3 % 10;
                if (a != Convert.ToInt32(textBox1.Text[9].ToString()))
                    MessageBox.Show("TC KİMLİK NUMARASI GEÇERSİZDİR.", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                else if (b != Convert.ToInt32(textBox1.Text[10].ToString()))
                    MessageBox.Show("TC KİMLİK NUMARASI GEÇERSİZDİR.", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                else
                    MessageBox.Show("TC KİMLİK NUMARASI GEÇERLİ","Geçerli",MessageBoxButtons.OK,MessageBoxIcon.None);
            }
        }
    }
}
