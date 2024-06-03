using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1
{
    
    public partial class EkleSil : Form
    {
        List<fakulte> fakultelist = new List<fakulte>();
        List<bolum> bolumlist = new List<bolum>();

        class Fakulte
        {
            public Fakulte( int _id, string _name, string _email , string _telefon)
            {
                name = _name;
                id = _id;
                email = _email;
                telefon = _telefon;

            }
            public string name { get; set; }
            public int id { get; set; }
            public string email { get; set; }
            public string telefon { get; set; }

                

        }

        class MYO
        {
            public MYO(string _name, int _id)
            {
                name = _name;
                id = _id;
            }
            public string name { get; set; }
            public int id { get; set; }
        }

        class Bolum
        {
            public Bolum(int _fid,string _name, int _id, int _parentId, string _email, string _telefon)
            {
                name = _name;
                fid = _fid;
                id = _id;
                parentId = _parentId;
                email = _email;
                telefon = _telefon;
            }
            public string name { get; set; }
            public int id { get; set; }

            public int fid { get; set; }
            public int parentId { get; set; }
            public string email { get; set; }
            public string telefon { get; set; }
        }

        class Akademisyen
        {
            public Akademisyen(string name, int id, int bolumId, string email)
            {
                this.name = name;
                this.id = id;
                this.bolumId = bolumId;
                this.email = email;
            }

            public string name { get; set; }
            public int id { get; set; }
            public int bolumId { get; set; }

            public string email { get; set; }
        }

        class Ogrenci
        {
            public Ogrenci(string name, int id, int bolumId, string email)
            {
                this.name = name;
                this.id = id;
                this.bolumId = bolumId;
                this.email = email;
            }

            public string name { get; set; }
            public int id { get; set; }
            public int bolumId { get; set; }
            public string email { get; set; }
        }



        
        List<Fakulte> Fakulteler = new List<Fakulte>();
        List<Bolum> Bolumler = new List<Bolum>();
        List<MYO> MYOlar = new List<MYO>();
        List<Ogrenci> ogrenciler = new List<Ogrenci>();
        List<Akademisyen> Akademisyenler = new List<Akademisyen>();


        Fakulte muhendislik = new Fakulte(1, "muhendislik", "21","majd");
        Fakulte FenEdebiyat = new Fakulte(2, "FenEdebiyat",  "21", "majd");

        MYO TBMYO = new MYO("TBMYO", 3);
        MYO SBMYO = new MYO("SBMYO", 4);

       
        Bolum Bil = new Bolum(3,"Bil", 1, 1,"21", "majd");
        Bolum elk = new Bolum(3,"elk", 2, 1, "21", "majd");

        Bolum fizik = new Bolum(3, "fizik", 3, 2, "21", "majd");
        Bolum edebiyat = new Bolum(3, "edebiyat", 4, 2, "21", "majd");

        Bolum mekatronik = new Bolum(2,"mekatronik", 5, 3, "21", "majd");
        Bolum otomotiv = new Bolum(3, "otomotiv", 6, 3, "21", "majd");

        Bolum sosyoloji = new Bolum(3, "sosyoloji", 7, 4, "21", "majd");
        Bolum psikoloji = new Bolum(3, "psikoloji", 8, 4, "21", "majd");

        Ogrenci irem = new Ogrenci("irem", 1, 1, "irem@gmail.com");
       
        Akademisyen kubilay = new Akademisyen("kubilay", 1, 1, "kubidem@gmail.com");
        //
    


        public EkleSil()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fakulteler.Add(muhendislik);
            Fakulteler.Add(FenEdebiyat);
            
            MYOlar.Add(TBMYO);
            MYOlar.Add(SBMYO);

            Bolumler.Add(Bil);
            Bolumler.Add(elk);
            Bolumler.Add(fizik);
            Bolumler.Add(edebiyat);
            Bolumler.Add(mekatronik);
            Bolumler.Add(otomotiv);
            Bolumler.Add(sosyoloji);

            ogrenciler.Add(irem);
            Akademisyenler.Add(kubilay);


        }
        class fakulte
        {
            public int Id { get; set; }


            public string Name { get; set; }
            public string telefon { get; set; }

            public string email { get; set; }
            public fakulte(int Id, string Name, string telefon, string email) {
                this.Id = Id;
                this.Name = Name;
                this.telefon = telefon;
                this.email = email;


            }
              
        }
        class bolum
        {
            public int Id { get; set; }


            public string Name { get; set; }
            public string telefon { get; set; }

            public string email { get; set; }
            public bolum(int Id, string Name, string telefon, string email)
            {
                this.Id = Id;
                this.Name = Name;
                this.telefon = telefon;
                this.email = email;


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var item in Fakulteler)
            {
                comboBox1.Items.Add(item.name);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var item in MYOlar)
            {
                comboBox1.Items.Add(item.name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FakulteVeyaMYOid = 0;
            foreach (var item in Fakulteler)
            {
                if (item.name == comboBox1.SelectedItem)
                {
                    FakulteVeyaMYOid = item.id;
                }
            }

            foreach (var item in MYOlar)
            {
                if (item.name == comboBox1.SelectedItem)
                {
                    FakulteVeyaMYOid = item.id;
                }
            }

            foreach (var item in Bolumler)
            {
                if (item.parentId == FakulteVeyaMYOid)
                {
                    comboBox2.Items.Add(item.name);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bolumId = 0;

            foreach (var item in Bolumler)
            {
                if (item.name == comboBox2.SelectedItem)
                {
                    bolumId = item.id;
                }
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            foreach (var item in ogrenciler)
                if (item.bolumId == bolumId)
                    listBox2.Items.Add(item.name);


            foreach (var item in Akademisyenler)
                if (item.bolumId == bolumId)
                    listBox1.Items.Add(item.name);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string SirName = textBox2.Text;
            string email = textBox3.Text;
            int id = 0;
            bool isOgrenci = false;

            int bolumId = 0;

            foreach (var item in Bolumler)
            {
                if (item.name == comboBox2.GetItemText(comboBox2.SelectedItem))
                {
                    bolumId = item.id;
                }
            }

            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {


                if (radioButton1.Checked == true)
                {
                    isOgrenci = true;
                }
                if (radioButton2.Checked == true)
                {
                    isOgrenci = false;
                }

                if (isOgrenci == true)
                {
                    Ogrenci ogr = new Ogrenci(name, id, bolumId, email);

                    ogrenciler.Add(ogr);
                }
                if (!isOgrenci)
                {
                    Akademisyen akad = new Akademisyen(name, id, bolumId, email);

                    Akademisyenler.Add(akad);
                }

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (var item in ogrenciler)
                    if (item.bolumId == bolumId)
                        listBox2.Items.Add(item.name);


                foreach (var item in Akademisyenler)
                    if (item.bolumId == bolumId)
                        listBox1.Items.Add(item.name);

            }
            else
            {
                // uyarı
            }
        }
        
            
        private void button5_Click(object sender, EventArgs e)
        {

            fakulte newfakulte = new fakulte( Int32.Parse(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text);

            fakultelist.Add(newfakulte);

            listBox4.Items.Clear();
            foreach (fakulte majd in fakultelist)
            {
                listBox4.Items.Add(majd.Name);
                listBox4.Items.Add((int)majd.Id);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string SirName = textBox2.Text;
            string email = textBox3.Text;
            int id = 0;
            bool isOgrenci = false;

            int bolumId = 0;

            foreach (var item in Bolumler)
            {
                if (item.name == comboBox2.GetItemText(comboBox2.SelectedItem))
                {
                    bolumId = item.id;
                }
            }

            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {


                if (radioButton1.Checked == true)
                {
                    isOgrenci = true;
                }
                if (radioButton2.Checked == true)
                {
                    isOgrenci = false;
                }

                if (isOgrenci == true)
                {
                    Ogrenci ogr = new Ogrenci(name, id, bolumId, email);

                    // aşağıyı düzelt
                    int RemoveId = -1;
                    foreach (var item in ogrenciler)
                    {
                        RemoveId = RemoveId + 1;
                        if (item.id == ogr.id)
                        {
                            break;
                        }
                    }
                    if(RemoveId > -1)
                        ogrenciler.Remove(ogrenciler[RemoveId]);
                }
                if (!isOgrenci)
                {
                    Akademisyen akad = new Akademisyen(name, id, bolumId, email);


                    // aşağıyı düzelt
                    int RemoveId = -1;
                    foreach (var item in Akademisyenler)
                    {
                        RemoveId = RemoveId + 1;
                        if (item.id == akad.id)
                        {
                            break;
                        }
                    }
                    if (RemoveId > -1)
                        Akademisyenler.Remove(Akademisyenler[RemoveId]);
                }

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (var item in ogrenciler)
                    if (item.bolumId == bolumId)
                        listBox2.Items.Add(item.name);


                foreach (var item in Akademisyenler)
                    if (item.bolumId == bolumId)
                        listBox1.Items.Add(item.name);

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bolum newbolum = new bolum(  Int32.Parse(textBox11.Text), Int32.Parse(textBox5.Text), textBox12.Text, textBox10.Text, textBox9.Text);

            bolumlist.Add(newbolum);

            listBox4.Items.Clear();
            foreach (bolum majd in bolumlist)
            {
                listBox3.Items.Add(majd.Name);
                listBox3.Items.Add((int)majd.Id);
            }
        }
    }
}
