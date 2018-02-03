using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections; 

namespace PastaKulesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList PASTALAR = new ArrayList();
        ArrayList ALTINLAR = new ArrayList();

        int Sıra = 0, Hız = 3, Puan = 0, AltınSıra = 0, AltınPuan = 0; 
        private void Form1_Load(object sender, EventArgs e)
        {
            PastalarıOlustur();
            AltınlarıOlustur(); 
            SıradakiPasta();
            GetirGotur();
            labelYuksekPuan.Text = Settings1.Default.sddsdsdsd.ToString();
           
        }

        void AltınlarıOlustur()
        {

            for (int i = 0; i < 100; i++)
            {
                PictureBox altın = new PictureBox();
                altın.Size = new Size(46, 39);
                altın.BackColor = Color.Transparent;
                altın.SizeMode = PictureBoxSizeMode.StretchImage;
                altın.ImageLocation = "altin.png";
                altın.Location = new Point(173, 36);
                altın.Visible = false; 

                this.Controls.Add(altın);
                ALTINLAR.Add(altın); 
            }

        }

        void PastalarıOlustur()
        {
            for (int i = 0; i < 500; i++)
            {
                PictureBox pasta = new PictureBox();
                pasta.Size = new Size(193, 54);
                pasta.Location = new Point(107, 274);
                pasta.SizeMode = PictureBoxSizeMode.StretchImage; 
                pasta.ImageLocation = "ortu.png";

                pasta.Visible = false; 

                
                this.Controls.Add(pasta);
                PASTALAR.Add(pasta); 
            }
        }

        void SıradakiPasta()
        {
            PictureBox pasta = ((PictureBox)PASTALAR[Sıra]);
            pasta.Visible = true;

            if (Sıra > 0)
                pasta.Width = Boyut;  
        }

        void GetirGotur()
        {
            timerSol.Enabled = true; 
        }

        private void timerSol_Tick(object sender, EventArgs e)
        {

             PictureBox pasta = ((PictureBox)PASTALAR[Sıra]);

             if (pasta.Left > 0)
             {
                 pasta.Left -= Hız;
             }
             else
             {
                 timerSol.Enabled = false;
                 timerSAG.Enabled = true; 
             }

             AltınlarıTopla(); 
        }

        private void timerSAG_Tick(object sender, EventArgs e)
        {
            PictureBox pasta = ((PictureBox)PASTALAR[Sıra]);

            if (pasta.Right < this.ClientSize.Width)
            {
                pasta.Left += Hız;
            }
            else
            {
                timerSAG.Enabled = false;
                timerSol.Enabled = true; 
            }


            AltınlarıTopla(); 
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            PictureBox pasta = ((PictureBox)PASTALAR[Sıra]);

            timerSAG.Enabled = false;
            timerSol.Enabled = false;

            pasta.ImageLocation = "pasta.png";
            KesmeIslemi();
            YanmaOlayı(); 
            timerDusus.Enabled = true; 
        }

        int Sayac = 0, Pixel = 54;
        private void timerDusus_Tick(object sender, EventArgs e)
        {
            PictureBox pasta = ((PictureBox)PASTALAR[Sıra]);
            PictureBox altın = ((PictureBox)ALTINLAR[AltınSıra]); 

            if (Sayac < Pixel)
            {
                Sayac += Hız;

                altın.Top += Hız;
                altın.Visible = true; 

                if (Sıra == 0)
                {
                    pasta.Top += Hız;
                    pictureBoxPasta.Top += Hız;
                    pictureBoxTabak.Top += Hız;
                }

                if (Sıra == 1)
                {
                    PictureBox pasta1 = ((PictureBox)PASTALAR[Sıra -1]);

                    pasta.Top += Hız;
                    pasta1.Top += Hız; 
                    pictureBoxPasta.Top += Hız;
                    pictureBoxTabak.Top += Hız;
                }

                if (Sıra == 2)
                {
                    PictureBox pasta1 = ((PictureBox)PASTALAR[Sıra - 1]);
                    PictureBox pasta2 = ((PictureBox)PASTALAR[Sıra - 2]);

                    pasta.Top += Hız;
                    pasta1.Top += Hız;
                    pasta2.Top += Hız;
                    pictureBoxPasta.Top += Hız;
                    pictureBoxTabak.Top += Hız;
                }

                if (Sıra == 3)
                {
                    PictureBox pasta1 = ((PictureBox)PASTALAR[Sıra - 1]);
                    PictureBox pasta2 = ((PictureBox)PASTALAR[Sıra - 2]);
                    PictureBox pasta3 = ((PictureBox)PASTALAR[Sıra - 3]);

                    pasta.Top += Hız;
                    pasta1.Top += Hız;
                    pasta2.Top += Hız;
                    pasta3.Top += Hız;
                    pictureBoxPasta.Top += Hız;
                    pictureBoxTabak.Top += Hız;
                }

                if (Sıra >= 4)
                {
                    PictureBox pasta1 = ((PictureBox)PASTALAR[Sıra - 1]);
                    PictureBox pasta2 = ((PictureBox)PASTALAR[Sıra - 2]);
                    PictureBox pasta3 = ((PictureBox)PASTALAR[Sıra - 3]);
                    PictureBox pasta4 = ((PictureBox)PASTALAR[Sıra - 4]);

                    pasta.Top += Hız;
                    pasta1.Top += Hız;
                    pasta2.Top += Hız;
                    pasta3.Top += Hız;
                    pasta4.Top += Hız;
                }


            }
            else
            {
                timerDusus.Stop();
                Sayac = 0;
                Sıra++;
                SıradakiPasta();
                GetirGotur(); 
            }
        }

        int Fazlalık = 0, Boyut = 0, EklenenPuan = 0, PixelAralık = 8; 
        void KesmeIslemi()
        {
            PictureBox pasta = ((PictureBox)PASTALAR[Sıra]);

            if (Sıra == 0)
            {
                // Sagda Kalma Durumu 
                if (pictureBoxPasta.Left < pasta.Left)
                {
                    Fazlalık = pasta.Left - pictureBoxPasta.Left;
                    //Perfect Durumu
                    if (Fazlalık <= PixelAralık)
                    {
                        timerBildiri.Start();
                        Puan += 10;
                        EklenenPuan = 10; 
                        pasta.Left = pictureBoxPasta.Left;
                       
                    }
                    else
                    {
                        pasta.Width -= Fazlalık;
                        Puan += 5;
                        EklenenPuan = 5; 
                    }
                }
                //Solda Kalma Durumu
                else
                {
                    Fazlalık = pictureBoxPasta.Left - pasta.Left;
                    //Perfect Durumu
                    if (Fazlalık <= PixelAralık)
                    {
                        timerBildiri.Start();
                        Puan += 10;
                        EklenenPuan = 10; 
                        pasta.Left = pictureBoxPasta.Left;
                    }
                    else
                    {
                        pasta.Width -= Fazlalık;
                        pasta.Left = pictureBoxPasta.Left;
                        Puan += 5;
                        EklenenPuan = 5; 
                    }
                }
            }
            else
            {
                PictureBox pasta1 = ((PictureBox)PASTALAR[Sıra -1]);

                // Sagda Kalma Durumu 
                if (pasta1.Left < pasta.Left)
                {
                    Fazlalık = pasta.Left - pasta1.Left;
                     //Perfect Durumu
                    if (Fazlalık <= PixelAralık)
                    {
                        timerBildiri.Start();
                        Puan += 10;
                        EklenenPuan = 10; 
                        pasta.Left = pasta1.Left;
                    }
                    else
                    {
                        pasta.Width -= Fazlalık;
                        Puan += 5;
                        EklenenPuan = 5; 
                    }
                }
                //Solda Kalma Durumu
                else
                {
                    Fazlalık = pasta1.Left - pasta.Left;
                      //Perfect Durumu
                    if (Fazlalık <= PixelAralık)
                    {
                        timerBildiri.Start();
                        Puan += 10;
                        EklenenPuan = 10; 
                        pasta.Left = pasta1.Left;
                    }
                    else
                    {
                        pasta.Width -= Fazlalık;
                        pasta.Left = pasta1.Left;
                        Puan += 5;
                        EklenenPuan = 5; 
                    }
                }
            }

            Boyut = pasta.Width;

            labelPuan.Text = Puan.ToString(); 
        }


        int sn = 0; 
        private void timerBildiri_Tick(object sender, EventArgs e)
        {
            sn++;
            labelBildiri.Visible = true; 
            if (sn >= 10)
            {
                timerBildiri.Stop();
                sn = 0;
                labelBildiri.Visible = false; 
            }
        }

        private void pictureBoxRestart_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Oyun Yeniden Başlatılack , Devam Edilsin mi ? ", "Pasta Kulesi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == System.Windows.Forms.DialogResult.Yes)
                Application.Restart();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Oyun' dan Çıkılacak , Devam Edilsin mi ? ", "Pasta Kulesi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (dr == System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
        }

        void YanmaOlayı()
        {

            PictureBox pasta = ((PictureBox)PASTALAR[Sıra]);

            if (pasta.Width < 5)
            {
                Puan -= EklenenPuan;
                labelPuan.Text = Puan.ToString(); 

                DialogResult dr = MessageBox.Show("Yandınız , Yeniden Oynamak İstermisiniz ?", "Pasta Kulesi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit(); 
                }
            }

            EnYuksekSkor(); 

        }

        void EnYuksekSkor()
        {
            int YuksekPuan = Settings1.Default.sddsdsdsd;
            if (Puan > YuksekPuan)
            {
                Settings1.Default.sddsdsdsd = Puan;
                Settings1.Default.Save(); 
            }
        }

        void AltınlarıTopla()
        {
            PictureBox pasta = ((PictureBox)PASTALAR[Sıra]);
            PictureBox altın = ((PictureBox)ALTINLAR[AltınSıra]);

            if (pasta.Top < altın.Bottom)
            {
                AltınPuan++;
                AltınSıra++; 
                altın.Visible = false; 
            }

            labelAltın.Text = AltınPuan.ToString(); 
        }

        private void labelPuan_TextChanged(object sender, EventArgs e)
        {

            int puan = Convert.ToInt32(labelPuan.Text);

            if (puan > 100)
            {
                Hız = 4;
                Pixel = 52;
                PixelAralık = 7; 
            }

            else if (puan > 200)
            {
                Hız = 5;
                Pixel = 52;
                PixelAralık = 6;
            }
           else  if (puan > 300)
            {
                Hız = 6;
                Pixel = 52;
                PixelAralık = 5;
            }
            else if (puan > 350)
            {
                Hız = 7;
                Pixel = 52;
                PixelAralık = 2;
            }

        }

    }
}
