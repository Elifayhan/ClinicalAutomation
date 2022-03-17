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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ELIF\\SQLEXPRESS; Initial Catalog=Klinik;Integrated Security=True");
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string guncelle= "Update BasvuruTablosu set KlinikID=@klinikid,DoktorID=@drid,RandevuTarihi=@randevutarihi,RandevuSaati=@saat where KlinikID=@klinikid";
            SqlCommand komut = new SqlCommand(guncelle, baglan);
            komut.Parameters.Add("@drid", SqlDbType.Int).Value = textBox1.Text;
            komut.Parameters.Add("@klinikid", SqlDbType.VarChar).Value = textBox2.Text;
            komut.Parameters.Add("@randevutarihi", SqlDbType.DateTime).Value = textBox3.Text;
            komut.Parameters.Add("@saat", SqlDbType.Time).Value = textBox4.Text;
            komut.ExecuteNonQuery();
            verilerigoster("select *from BasvuruTablosu");
            baglan.Close();
            MessageBox.Show("İşlem Başarılı.");
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            verilerigoster("select *from BasvuruTablosu");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from BasvuruTablosu where HastaID='" + dataGridView1.SelectedRows[i].Cells["HastaID"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                verilerigoster("Select *from BasvuruTablosu");
            }
            MessageBox.Show("Kayıtlar Silindi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 yeni = new Form5();
            yeni.Show();
            this.Hide();
        }
    }
}
