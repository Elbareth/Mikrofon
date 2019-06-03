using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutkiForm
{
    public partial class Form1 : Form
        
    {
        private ImageList listaNutek;
        protected Graphics myGraphics;
        private Panel panel;
        private IContainer contener;
        private static int x = 0;
        private static int index = 0;
        private List<String> listaPolozenieNaPieciolinii;
        private List<float> listaWartosciPeak;
        private List<String> listaNazwNutek;
        private static int counter = new int();
        public Form1()
        {
            InitializeComponent();
            listaNutek = new ImageList();
            listaNutek.ImageSize = new Size(60, 120);
            listaNutek.TransparentColor = Color.White;
            panel = new Panel();
            myGraphics = Graphics.FromHwnd(panel.Handle);
            listaPolozenieNaPieciolinii = new List<String>();
            listaWartosciPeak = new List<float>();
            listaNazwNutek = new List<String>();
            counter = 0;
        }
        public void addImage(string nazwa)
        {
            if (nazwa != null)
            {
                listaNutek.Images.Add(Image.FromFile(nazwa));
                listaNutek.Draw(myGraphics, x,1,index);
                x = x + 60;
                index++;
            }
        }
        public void setListaPolozenieNaPieciolinii(String pieciolinia)
        {
            listaPolozenieNaPieciolinii.Add(pieciolinia);
        }
        public void setListaWartosciPeak(float wartosc)
        {
            listaWartosciPeak.Add(wartosc);      
            
        }
        public List<String> jakaToNuta(Object obiekt, Object cout)
        {   
            float [] tak = (float []) obiekt;
            List<float> listaWartosciPeak = tak.ToList();
            int counter = (int)cout;
            float[] tmp = new float[8];
            for (int i = 0; i < 8; i++)
            {
                tmp[i] = listaWartosciPeak.ElementAt(i+counter);
                if (tmp[i] == 0) tmp[i] = 1;

            }
            float min = tmp.Min();
            for (int i = 0; i < 8; i++)
            {
                float schowek = min / tmp[i];
                if (schowek == 1) listaNazwNutek.Add("calanuta");
                if (schowek > 0.75 && schowek < 1) listaNazwNutek.Add("polnuta");
                if (schowek > 0.5 && schowek < 0.75) listaNazwNutek.Add("cwiercnuta");
                if (schowek > 0.25 && schowek < 0.5) listaNazwNutek.Add("osemka");
                if (schowek < 0.25) listaNazwNutek.Add("szesnastka");
            }            
            return listaNazwNutek;
        }
        public void dodajObraz(Object obiekt, List<String> listaNazwNutekk, object cout)
        {
            String[] tak = (String[])obiekt;
            List<String> listaPolozenieNaPieciolinii = tak.ToList();
            List<String> listaNazwNutek = listaNazwNutekk;
            int counter = (int)cout;        
            for (int i = 0; i < 8; i++)
            {
                String tmp = "C:\\Users\\lenovo\\Source\\Repos\\NutkiForm\\NutkiForm\\Nutki\\" + listaPolozenieNaPieciolinii.ElementAt(i+counter).ToString() 
                    + listaNazwNutek.ElementAt(i).ToString() + ".jpg";                
                MessageBox.Show(listaNazwNutek.ElementAt(i) + " na linii " + listaPolozenieNaPieciolinii.ElementAt(i+counter));                               
                listaNutek.Images.Add(Image.FromFile(tmp));
                listaNutek.Draw(myGraphics, x, 1, index);
                x = x + 60;
                index++;               
            }
            //counter = counter + 8;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(19, 369);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(616, 17);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBar1_Scroll);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(644, 412);
            this.Controls.Add(this.hScrollBar1);
            this.Name = "Form1";
            this.ResumeLayout(true);

        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int x;
            int y;
            x = e.NewValue;
            y = hScrollBar1.Value;
        }
    }
}
