
using DataAccess;
using System.Data;
using System.Data.SqlClient;
namespace DemirbasKayit
{
    public partial class Form1 : Form
    {

        //SqlConnection conn = new SqlConnection("server=LAPTOP-HKPKJUC9; initial catalog=DemirbasKayýt; integrated security=sspi");
        //SqlCommand cmd;
        //SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }


        public void listele()
        {
            //da = new SqlDataAdapter("select * from urunler", conn);
            //DataTable tablo = new DataTable();
            //da.Fill(tablo);
            //dataGridView1.DataSource = tablo;

            DataAccess.DemirbasKayýtEntities entity = new DataAccess.DemirbasKayýtEntities();
            var urunlerListesi = entity.urunler.ToList();
            dataGridView1.DataSource = urunlerListesi;
        }
        public void temizle()
        {
            label10.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = "";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Tüm alanlarý doldurunuz.", "HATA");

                }
                else
                {
                    //cmd = new SqlCommand("insert into urunler (urunKodu,cinsi,urunAdý,marka,model,alanKisi,departman,alisTarihi ) values (@urunKodu,@cinsi,@urunAdý,@marka,@model,@alanKisi,@departman,@alisTarihi )", conn);
                    //cmd.Parameters.AddWithValue("@urunKodu", textBox1.Text);
                    //cmd.Parameters.AddWithValue("@cinsi", comboBox1.Text);
                    //cmd.Parameters.AddWithValue("@urunAdý", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@marka", textBox4.Text);
                    //cmd.Parameters.AddWithValue("@model", textBox5.Text);
                    //cmd.Parameters.AddWithValue("@alanKisi", textBox6.Text);
                    //cmd.Parameters.AddWithValue("@departman", comboBox2.Text);
                    //cmd.Parameters.AddWithValue("@alisTarihi", dateTimePicker1.Value);

                    //conn.Open();
                    //cmd.ExecuteNonQuery();

                    DataAccess.DemirbasKayýtEntities entity = new DataAccess.DemirbasKayýtEntities();
                    urunler urun = new urunler()
                    {
                        urunKodu = textBox1.Text,
                        cinsi = comboBox1.Text,
                        urunAdý = textBox3.Text,
                        marka = textBox4.Text,
                        model = textBox5.Text,
                        alanKisi = textBox6.Text,
                        departman = comboBox2.Text,
                        alisTarihi = dateTimePicker1.Value
                    };

                    entity.urunler.Add(urun);
                    entity.SaveChanges();


                    MessageBox.Show("Kayýt tamam");


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalý iþlem yaptýnýz", "HATA");
                temizle();
            }
            finally
            {
                //conn.Close();
                listele();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Güncellemek istediðiniz kaydý seçin.", "HATA");

                }
                else
                {
                    //cmd = new SqlCommand("UPDATE urunler set urunKodu=@urunKodu,cinsi=@cinsi,urunAdý=@urunAdý,marka=@marka,model=@model,alanKisi=@alanKisi,departman=@departman,alisTarihi=@alisTarihi where urunId=@urunId", conn);
                    //cmd.Parameters.AddWithValue("@urunId", label10.Text);
                    //cmd.Parameters.AddWithValue("@urunKodu", textBox1.Text);
                    //cmd.Parameters.AddWithValue("@cinsi", comboBox1.Text);
                    //cmd.Parameters.AddWithValue("@urunAdý", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@marka", textBox4.Text);
                    //cmd.Parameters.AddWithValue("@model", textBox5.Text);
                    //cmd.Parameters.AddWithValue("@alanKisi", textBox6.Text);
                    //cmd.Parameters.AddWithValue("@departman", comboBox2.Text);
                    //cmd.Parameters.AddWithValue("@alisTarihi", dateTimePicker1.Value);

                    //conn.Open();
                    //cmd.ExecuteNonQuery();

                    DataAccess.DemirbasKayýtEntities entity = new DataAccess.DemirbasKayýtEntities();
                    int selectedId = Int16.Parse(label10.Text);
                    var güncellenecekUrun = entity.urunler.FirstOrDefault(x => x.urunId == selectedId);
                    if (güncellenecekUrun != null)
                    {
                        güncellenecekUrun.urunKodu = textBox1.Text;
                        güncellenecekUrun.cinsi = comboBox1.Text;
                        güncellenecekUrun.urunAdý = textBox3.Text;
                        güncellenecekUrun.marka = textBox4.Text;
                        güncellenecekUrun.model = textBox5.Text;
                        güncellenecekUrun.alanKisi = textBox6.Text;
                        güncellenecekUrun.departman = comboBox2.Text;
                        güncellenecekUrun.alisTarihi = dateTimePicker1.Value;
                    }
                    entity.SaveChanges();

                    MessageBox.Show("Güncelleme tamam");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalý iþlem yaptýnýz", "HATA");
                temizle();
            }
            finally
            {
                //conn.Close();
                listele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Silmek istediðiniz kaydý seçin.", "HATA");

                }
                else
                {
                    //cmd = new SqlCommand("delete from urunler where urunId=@urunId", conn);
                    //cmd.Parameters.AddWithValue("@urunId", label10.Text);

                    //conn.Open();
                    //cmd.ExecuteNonQuery();

                    DataAccess.DemirbasKayýtEntities entity = new DataAccess.DemirbasKayýtEntities();
                    int selectedId = Int16.Parse(label10.Text);
                    var silinecekUrun = entity.urunler.FirstOrDefault(x => x.urunId == selectedId);
                    if (silinecekUrun != null)
                    {
                        entity.urunler.Remove(silinecekUrun);
                        entity.SaveChanges();
                    }

                    MessageBox.Show("Silme tamam");


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalý iþlem yaptýnýz", "HATA");
                temizle();
            }
            finally
            {
                //conn.Close();
                listele();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //da = new SqlDataAdapter("select * from urunler where urunId like'"+textBox2.Text+ "%' OR  urunKodu like'"+textBox2.Text+ "%'  OR  cinsi like'"+textBox2.Text+ "%' OR  urunAdý like'"+textBox2.Text+ "%'  OR  marka like'"+textBox2.Text+ "%'  OR  model like'"+textBox2.Text+"%' OR  alanKisi like'"+textBox2.Text+ "%'  OR  departman like'"+textBox2.Text+ "%'  OR  alisTarihi like'"+textBox2.Text+"%' ", conn);
            //DataTable tablo = new DataTable();
            //da.Fill(tablo);
            //dataGridView1.DataSource = tablo;

            DataAccess.DemirbasKayýtEntities entity = new DataAccess.DemirbasKayýtEntities();
            var arananUrun = entity.urunler.Where(x => x.urunKodu.Contains(textBox2.Text) || x.urunAdý.Contains(textBox2.Text) || x.cinsi.Contains(textBox2.Text) || x.marka.Contains(textBox2.Text) || x.model.Contains(textBox2.Text) || x.alanKisi.Contains(textBox2.Text) || x.departman.Contains(textBox2.Text)).ToList();
            dataGridView1.DataSource = arananUrun;
        }
    }
}