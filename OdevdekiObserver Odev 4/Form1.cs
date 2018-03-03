using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        HisseSenedi h = new HisseSenedi();
        SonDegerGozlemcisi g1 = new SonDegerGozlemcisi();
        YuzdeFarkGozlemcisi g2 = new YuzdeFarkGozlemcisi();

        public Form1()
        {
            InitializeComponent();

            h.GozlemciEkle(g1);
            h.GozlemciEkle(g2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h.SetSonDeger(5); // Değer aslında ekrandan alınacak ama uğraşmak istemedim.
        }
    }

    // interface ISubject
    public interface IObserver
    {
        void Update(double yeniDeger);
    }

    class SonDegerGozlemcisi : IObserver
    {

        #region IObserver Members

        public void Update(double yeniDeger)
        {
            MessageBox.Show("Güncelleme oldu. Son deger: " + yeniDeger);
        }

        #endregion
    }

    class YuzdeFarkGozlemcisi : IObserver
    {
        double oncekiDeger = 0;

        #region IObserver Members

        public void Update(double yeniDeger)
        {
            double fark = 10;
            MessageBox.Show("Güncelleme oldu. Fark: " + fark);
        }

        #endregion
    }

    public class HisseSenedi
    {
        private double deger;
        List<IObserver> gozlemciler = new List<IObserver>();

        public void GozlemciEkle(IObserver g)
        {
            gozlemciler.Add(g);
        }

        public void SetSonDeger(double yeniDeger)
        {
            deger = yeniDeger;

            GozlemcileriBilgilendir(yeniDeger);
        }

        void GozlemcileriBilgilendir(double yeniDeger)
        {
            foreach (IObserver o in gozlemciler)
            {
                o.Update(yeniDeger);
            }
        }
    }

}
