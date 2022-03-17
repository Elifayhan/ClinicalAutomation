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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglan=new SqlConnection("Data Source=ELIF\\SQLEXPRESS;Initial Catalog=Klinik;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 yeni = new Form2();
            yeni.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string tarih = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string randevutarih = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string sorgu = "Insert into BasvuruTablosu (HastaID,Tarih,KlinikID,DoktorID,RandevuTarihi,RandevuSaati) values (@HastaID,@Tarih,@KlinikID,@DoktorID,@RandevuTarihi,@RandevuSaati)";
            SqlCommand komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@HastaID", comboBox2.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@Tarih", tarih );
            komut.Parameters.AddWithValue("@KlinikID", comboBox3.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@DoktorID", comboBox1.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@RandevuTarihi", randevutarih);
            komut.Parameters.AddWithValue("@RandevuSaati", comboBox4.SelectedItem.ToString());
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Randevunuz Kaydedilmiştir.");
            verilerigoster("select *from BasvuruTablosu");
        }
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void hasta()
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select *from HastaKayıt";
            komut.Connection = baglan;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["HastaID"]);
            }
            baglan.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select *from Doktorlar";
            komut.Connection = baglan;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr["DoktorID"]);
            }
            baglan.Close();
            hasta();
            verilerigoster("Select * from BasvuruTablosu");

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form7 yeni = new Form7();
            yeni.Show();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            yeni.Show();
            
        }
    }
}
