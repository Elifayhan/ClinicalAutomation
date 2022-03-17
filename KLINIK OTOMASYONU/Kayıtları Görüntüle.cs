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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ELIF\\SQLEXPRESS;Initial Catalog=Klinik;Integrated Security=True");
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            verilerigoster("select *from HastaKayıt");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from HastaKayıt where HastaID='" + dataGridView1.SelectedRows[i].Cells["HastaID"].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoster("Select *from HastaKayıt");
            }
            MessageBox.Show("Kayıtlar Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
             {

                 string HastaID, Adı, Soyadı, TC, AnneAdı, BabaAdı, DoğumYeri, Cinsiyet, CepTelefonu, Adres, SigortalıMı, SigortaDurumu, DrID;
                 HastaID = dataGridView1.CurrentRow.Cells["HastaID"].Value.ToString();
                 Adı = dataGridView1.CurrentRow.Cells["Adı"].Value.ToString();
                 Soyadı = dataGridView1.CurrentRow.Cells["Soyadı"].Value.ToString();
                 TC = dataGridView1.CurrentRow.Cells["TC"].Value.ToString();
                 AnneAdı = dataGridView1.CurrentRow.Cells["AnneAdı"].Value.ToString();
                 BabaAdı = dataGridView1.CurrentRow.Cells["BabaAdı"].Value.ToString();
                 DoğumYeri = dataGridView1.CurrentRow.Cells["DoğumYeri"].Value.ToString();
                 Cinsiyet = dataGridView1.CurrentRow.Cells["Cinsiyet"].Value.ToString();
                 CepTelefonu = dataGridView1.CurrentRow.Cells["CepTelefonu"].Value.ToString();
                 Adres = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
                 SigortalıMı = dataGridView1.CurrentRow.Cells["SigortalıMı"].Value.ToString();
                 SigortaDurumu = dataGridView1.CurrentRow.Cells["SigortaDurumu"].Value.ToString();
                 DrID = dataGridView1.CurrentRow.Cells["DrID"].Value.ToString();
                 baglanti.Open();
                 SqlCommand komut = new SqlCommand("update HastaKayıt set HastaID='" + HastaID + "',Adı='" + Adı + "',Soyadı='" + Soyadı + "',TC='" + TC + "',AnneAdı='" + AnneAdı + "',BabaAdı='" + BabaAdı  + "',DoğumYeri='" + DoğumYeri + "',Cinsiyet='" + Cinsiyet + "',CepTelefonu='" + CepTelefonu + "',Adres='" + Adres + "',SigortalıMı='" + SigortalıMı + "',SigortaDurumu='" + SigortaDurumu + "',DrID='" + DrID + "' where HastaID=" + HastaID + " ", baglanti);
                 komut.ExecuteNonQuery();
                 baglanti.Close();
                 verilerigoster("select *from HastaKayıt");
                 MessageBox.Show("Veriler Güncellendi.");
             }
             catch (Exception ex)
             {

                 MessageBox.Show(ex.ToString());
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            verilerigoster("select * from HastaKayıt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from HastaKayıt where Adı like '%" + textBox1.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 yeni = new Form2();
            yeni.Show();
            this.Hide();
        }
    }
}
