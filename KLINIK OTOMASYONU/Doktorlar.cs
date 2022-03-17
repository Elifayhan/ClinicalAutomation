using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLINIK_OTOMASYONU
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ELIF\\SQLEXPRESS; Initial Catalog=Klinik;Integrated Security=True");
        private void Form6_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select DoktorID,DoktorAdı,DoktorSoyadı from Doktorlar",baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["DoktorID"].ToString();
                ekle.SubItems.Add(oku["DoktorAdı"].ToString());
                ekle.SubItems.Add(oku["DoktorSoyadı"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form3 yeni = new Form3();
            //yeni.Show();
            this.Close();
            
        }
    }
}
