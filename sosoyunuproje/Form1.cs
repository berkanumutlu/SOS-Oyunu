using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sosoyunuproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TextBox[,] alanlar;
        int satir_sayisi = 0, sutun_sayisi = 0;
        int oyunsayac = 1, sayac2 = 0, oyunbitimi = 0;
        TextBox box = new TextBox();

        private void button1_Click(object sender, EventArgs e)
        {
            if(sayac2<1)
            {
                satir_sayisi = Convert.ToInt32(textBox1.Text);
                sutun_sayisi = Convert.ToInt32(textBox2.Text);

                if (sutun_sayisi >= 3 && satir_sayisi >= 3)
                {
                    alanlar = new TextBox[satir_sayisi, sutun_sayisi];

                    for (int i = 0; i < satir_sayisi; i++)
                    {
                        for (int j = 0; j < sutun_sayisi; j++)
                        {
                            TextBox yenitextBox = new TextBox();
                            yenitextBox.Location = new System.Drawing.Point(25 + j * 25, i * 25 + 90);
                            yenitextBox.Name = i + " * " + j;
                            yenitextBox.Size = new System.Drawing.Size(20, 20);
                            yenitextBox.TabIndex = 1;
                            yenitextBox.BorderStyle = BorderStyle.FixedSingle;
                            yenitextBox.KeyUp += new KeyEventHandler(yenitextBox_KeyUp);
                            this.Controls.Add(yenitextBox);
                            alanlar[i, j] = yenitextBox;
                            sayac2++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sütun ve satır sayısı en az 3 olabilir!", "Hata!", MessageBoxButtons.OK);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < satir_sayisi; i++)
            {
                for (int j = 0; j < sutun_sayisi; j++)
                {
                    alanlar[i, j].Text = "";
                }
            }

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            oyunsayac = 1;
            oyunbitimi = 0;
            sayac2 = 0;

            for (int i=0;i<satir_sayisi;i++)
            {
                for (int j = 0; j < sutun_sayisi; j++)
                {
                    alanlar[i, j].BackColor = Color.White;
                }
            }

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Yeniden Matris Oluşturmak ister misiniz?", "Oyun Bitti", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                for (int i = 0; i < satir_sayisi; i++)
                {
                    for (int j = 0; j < sutun_sayisi; j++)
                    {
                        this.Controls.Remove(alanlar[i, j]);
                    }
                }
            }
            else
            {
                sayac2 = 1;
            }
        }

        private void yenitextBox_KeyUp(object sender, KeyEventArgs e)
        {
            oyunbitimi++;
            
            TextBox text = sender as TextBox;
            satir.Focus();
            int d1 =text.Name[0]-48;
            int d2=text.Name[4]-48;


            if (alanlar[d1, d2].Text == "o")
                alanlar[d1, d2].Text = "O";
            if (alanlar[d1, d2].Text == "s")
                alanlar[d1, d2].Text = "S";


            if (text.Text == "S" || text.Text == "O")
            {
                if (oyunsayac % 2 == 0)
                {
                    label2.Text = "Sıra 1.Oyuncuda";
                }
                else
                {
                    label2.Text = "Sıra 2.Oyuncuda";
                }
            }

            alanlar[d1, d2].BackColor = Color.Red;

            if (text.Text=="S")
             {
                if(d1>=2)
                    if (alanlar[d1-1, d2].Text=="O"&& alanlar[d1-2, d2].Text == "S")
                 {
                        if (oyunsayac % 2 != 0) {                     
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else { 
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                    alanlar[d1, d2].BackColor = Color.Lime;
                    alanlar[d1 - 1, d2].BackColor = Color.Lime;
                    alanlar[d1 - 2, d2].BackColor = Color.Lime;
                }
                 if(satir_sayisi-2>d1)
                    if (alanlar[d1 + 1, d2].Text == "O" && alanlar[d1 + 2, d2].Text == "S")
                 {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                    alanlar[d1, d2].BackColor = Color.Lime;
                    alanlar[d1 + 1, d2].BackColor = Color.Lime;
                    alanlar[d1 + 2, d2].BackColor = Color.Lime;
                }
                 if(sutun_sayisi-2>d2)
                    if (alanlar[d1 , d2+1].Text == "O" && alanlar[d1 , d2+2].Text == "S")
                 {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                    alanlar[d1, d2].BackColor = Color.Lime;
                    alanlar[d1 , d2+ 1].BackColor = Color.Lime;
                    alanlar[d1 , d2+ 2].BackColor = Color.Lime;
                }
                 if(d2>=2)
                 if (alanlar[d1, d2 - 1].Text == "O" && alanlar[d1, d2 - 2].Text == "S")
                 {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                    alanlar[d1, d2].BackColor = Color.Lime;
                    alanlar[d1, d2 - 1].BackColor = Color.Lime;
                    alanlar[d1, d2 - 2].BackColor = Color.Lime;
                }
                if (satir_sayisi - 2 > d1&& 2<= d2)
                    if (alanlar[d1+1, d2 - 1].Text == "O" && alanlar[d1+2, d2 - 2].Text == "S")
                    {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                        alanlar[d1, d2].BackColor = Color.Lime;
                        alanlar[d1+1, d2 - 1].BackColor = Color.Lime;
                        alanlar[d1+2, d2 - 2].BackColor = Color.Lime;
                    }
                if (satir_sayisi - 2 > d2 && 2 <= d1)
                    if (alanlar[d1 - 1, d2 + 1].Text == "O" && alanlar[d1 - 2, d2 + 2].Text == "S")
                    {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                        alanlar[d1, d2].BackColor = Color.Lime;
                        alanlar[d1 - 1, d2 + 1].BackColor = Color.Lime;
                        alanlar[d1 - 2, d2 + 2].BackColor = Color.Lime;
                    }
                if (satir_sayisi - 2 > d2&&sutun_sayisi - 2 > d1)
                    if (alanlar[d1 + 1, d2 + 1].Text == "O" && alanlar[d1 + 2, d2 + 2].Text == "S")
                    {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                        alanlar[d1, d2].BackColor = Color.Lime;
                        alanlar[d1 + 1, d2 + 1].BackColor = Color.Lime;
                        alanlar[d1 + 2, d2 + 2].BackColor = Color.Lime;
                    }
                if (2 <= d2 && 2 <= d1)
                    if (alanlar[d1 - 1, d2 - 1].Text == "O" && alanlar[d1 - 2, d2 - 2].Text == "S")
                    {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                        alanlar[d1, d2].BackColor = Color.Lime;
                        alanlar[d1 - 1, d2 - 1].BackColor = Color.Lime;
                        alanlar[d1 - 2, d2 - 2].BackColor = Color.Lime;
                    }
            }

            if (text.Text == "O")
            {
                if(d1>0&&satir_sayisi-1>d1)
                if (alanlar[d1 - 1, d2].Text == "S" && alanlar[d1 +1, d2].Text == "S")
                {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                    alanlar[d1-1, d2].BackColor = Color.Lime;
                    alanlar[d1+1, d2].BackColor = Color.Lime;
                    alanlar[d1, d2].BackColor = Color.Lime;
                }
                if(d2!=0&&sutun_sayisi-1>d2)
                if (alanlar[d1 , d2- 1].Text == "S" && alanlar[d1 , d2+ 1].Text == "S")
                {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                    alanlar[d1 , d2- 1].BackColor = Color.Lime;
                    alanlar[d1, d2 + 1].BackColor = Color.Lime;
                    alanlar[d1, d2].BackColor = Color.Lime;
                }
                
                if (d1 >= 1 && d2 >= 1 && sutun_sayisi - 1 > d2 && sutun_sayisi - 1 > d1)
                    if (alanlar[d1-1, d2 - 1].Text == "S" && alanlar[d1+1, d2 + 1].Text == "S")
                        
                    {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                        alanlar[d1-1, d2 - 1].BackColor = Color.Lime;
                        alanlar[d1+1, d2 + 1].BackColor = Color.Lime;
                        alanlar[d1, d2].BackColor = Color.Lime;
                    }
                if (d1 >= 1 && d2 >= 1 && sutun_sayisi - 1 > d2 && sutun_sayisi - 1 > d1)
                    if (alanlar[d1 - 1, d2 + 1].Text == "S" && alanlar[d1 + 1, d2 - 1].Text == "S")

                    {
                        if (oyunsayac % 2 != 0)
                        {
                            numericUpDown1.Value++;
                            label2.Text = "Sıra 1.Oyuncuda";
                        }
                        else
                        {
                            numericUpDown2.Value++;
                            label2.Text = "Sıra 2.Oyuncuda";
                        }
                        oyunsayac--;
                        alanlar[d1 - 1, d2 + 1].BackColor = Color.Lime;
                        alanlar[d1 + 1, d2 - 1].BackColor = Color.Lime;
                        alanlar[d1, d2].BackColor = Color.Lime;
                    }
            }
            oyunsayac++;
            if(oyunbitimi>=sutun_sayisi*satir_sayisi)
            {
                if (numericUpDown1.Value < numericUpDown2.Value)
                    MessageBox.Show("Oyunu 2.oyuncu kazandı..");
                if (numericUpDown1.Value > numericUpDown2.Value)
                    MessageBox.Show("Oyunu 1.oyuncu kazandı..");
                if (numericUpDown1.Value == numericUpDown2.Value)
                    MessageBox.Show("Berabere..");
            }

            ///Eğer textbox kutucuguna birden fazla karakter girilmiş ise sadece ilk karakteri dikkate alalım
            if (text.TextLength > 1)
            {
                text.Text = text.Text.Substring(0, 1);
            }

            text.Text = text.Text.ToUpper();

            ///Eğergirilen karakter S veya o değilse textbox kutucuğunu temizleyelim
            if (text.Text != "S" && text.Text != "O")
            {
                text.Text = "";
                text.BackColor = Color.White;
                MessageBox.Show("Lütfen S veya O giriniz.", "Hatalı Giriş", MessageBoxButtons.OK);
                oyunsayac--;
            }
        }
    }
}