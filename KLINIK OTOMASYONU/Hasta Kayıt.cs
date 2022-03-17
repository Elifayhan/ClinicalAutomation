using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KLINIK_OTOMASYONU
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ELIF\\SQLEXPRESS; Initial Catalog=Klinik;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select *from Doktorlar";
            komut.Connection = baglan;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox5.Items.Add(dr["DoktorID"]);
            }
            baglan.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            baglan.Open();
            string tarih = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string sorgu = "Insert into HastaKayıt (HastaID,Adı,Soyadı,TC,AnneAdı,BabaAdı,DoğumTarihi,DoğumYeri,Cinsiyet,CepTelefonu,Adres,SigortalıMı,SigortaDurumu,DrID) values (@HastaID,@Adı,@Soyadı,@TC,@AnneAdı,@BabaAdı,@DoğumTarihi,@DoğumYeri,@Cinsiyet,@CepTelefonu,@Adres,@SigortalıMı,@SigortaDurumu,@DrID)";
            SqlCommand komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@HastaID", textBox1.Text);
            komut.Parameters.AddWithValue("@Adı", textBox2.Text);
            komut.Parameters.AddWithValue("@Soyadı", textBox3.Text);
            komut.Parameters.AddWithValue("@TC", textBox4.Text);
            komut.Parameters.AddWithValue("@AnneAdı", textBox5.Text);
            komut.Parameters.AddWithValue("@BabaAdı", textBox6.Text);
            komut.Parameters.AddWithValue("@DoğumTarihi", tarih);
            komut.Parameters.AddWithValue("@DoğumYeri", comboBox1.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@Cinsiyet", comboBox2.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@CepTelefonu", textBox7.Text);
            komut.Parameters.AddWithValue("@Adres", textBox9.Text);
            komut.Parameters.AddWithValue("@SigortalıMı", comboBox3.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@SigortaDurumu", comboBox4.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@DrID", comboBox5.SelectedItem.ToString());   
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Veriler Kaydedildi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 islemsecim = new Form2();
            islemsecim.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 yeni = new Form6();
            yeni.Show();
            //this.Hide();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
