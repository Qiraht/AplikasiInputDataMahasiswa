using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    public partial class Form1 : Form
    {
        public class Mahasiswa
        {
            public string Nim {get; set;}
            public string Nama { get; set; }
            public string Kelas { get; set; }
            public int Nilai { get; set; }
 
        }


        private List<Mahasiswa> list = new List<Mahasiswa>();

        // constructor
        public Form1()
        {
            InitializeComponent();
            InisialiasiListView();
        }
          
        private void InisialiasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No. ", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("NIM", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai Huruf", 50, HorizontalAlignment.Right);

        }

        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Text = "0";
            txtNim.Focus();
        }

        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private void TampilkanData()
        {
            lvwMahasiswa.Items.Clear();

            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                

                lvwMahasiswa.Items.Add(item);
            }
        }

        private void Konversi()
        {
            
        }


        private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtNilai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();

            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);

            list.Add(mhs);

            var msg = "Data mahasiswa berhasil disimpan.";

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
        }

        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }
    }
}
