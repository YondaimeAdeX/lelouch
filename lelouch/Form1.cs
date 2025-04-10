using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lelouch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Doldur() {
            var siniflist = db.tblSiniflar.Select(x => new
            {
                x.id,
                sinif = x.sinifAdi
            }).ToList();
            cmbsinifi.DataSource = siniflist;
            cmbsinifi.DisplayMember = "sinif";
            dataGridView1.DataSource = siniflist;

            var derslist = db.tblDers0.ToList();
            dataGridView2.DataSource = derslist;

            var oglist = db.tblOgrenciler.ToList();
            dataGridView3.DataSource = oglist;


        
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        dbOkulEntities2 db = new dbOkulEntities2();
        private void button1_Click(object sender, EventArgs e)
        {
            tblSiniflar sinif = new tblSiniflar();
            sinif.sinifAdi = txtsinifadi.Text;
            db.tblSiniflar.Add(sinif);
            db.SaveChanges();
            Doldur();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tblDers0 ders = new tblDers0();
            ders.dersAdi = txtdersadi.Text;
            db.tblDers0.Add(ders);
            db.SaveChanges();
            Doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tblOgrenciler og = new tblOgrenciler();
            og.ogAdi = txtAdi.Text;
            og.ogDurumu = chkDurum.Checked;
            og.ogNo = txtno.Text;
            og.ogSinifi = cmbsinifi.Text;
            og.ogTel = txttel.Text;
            db.tblOgrenciler.Add(og);
            db.SaveChanges();
            Doldur();
        }
    }
}
