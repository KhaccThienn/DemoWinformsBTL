using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWinformsBTL.Forms
{
    public partial class FrmPublisher : Form
    {
        public bool IsOpened { get; set; } = false;

        Library_MgmtEntities library = new Library_MgmtEntities();

        DataGridViewRow currentRow = new DataGridViewRow();
        public FrmPublisher()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            dgvPublisher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPublisher.ClearSelection();
        }

        private void LoadPublishers()
        {
            var publishers = from pub in library.Publishers
                             select new
                             {
                                 PublisherId = pub.Id,
                                 PublisherName = pub.Name,
                             };
            dgvPublisher.DataSource = publishers.ToList();
        }

        private void ClearForms()
        {
            txtName.Text = string.Empty;
        }

        private void FrmPublisher_Load(object sender, EventArgs e)
        {
            LoadPublishers();
            ClearForms();

            deleteBtn.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
            updateBtn.Enabled = false;

            txtName.Enabled = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            updateBtn.Enabled = false;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
            txtName.Enabled = true;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            saveBtn.Enabled = true;

            addBtn.Enabled = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (addBtn.Enabled)
            {
                if (txtName.Text.Length <= 0)
                {
                    MessageBox.Show("Các trường thông tin không được để trống");
                    return;
                }
                //MessageBox.Show("Add");
                var pub = new Publisher();
                pub.Name = txtName.Text;

                library.Publishers.Add(pub);
                library.SaveChanges();
                LoadPublishers();
                addBtn.Enabled = true;
                deleteBtn.Enabled = false;
                updateBtn.Enabled = false;
                saveBtn.Enabled = false;
                cancelBtn.Enabled = false;

                txtName.Enabled = false;

                dgvPublisher.ClearSelection();
                ClearForms();
            }
            if (updateBtn.Enabled)
            {
                int Id = (int)currentRow.Cells[0].Value;
                var pub = library.Publishers.FirstOrDefault(x => x.Id == Id);

                if (txtName.Text.Length <= 0 )
                {
                    MessageBox.Show("Các trường thông tin không được để trống");
                    return;
                }

                if (pub != null)
                {
                    pub.Name = txtName.Text;

                    library.SaveChanges();
                    LoadPublishers();

                    addBtn.Enabled = true;
                    deleteBtn.Enabled = false;
                    updateBtn.Enabled = false;
                    saveBtn.Enabled = false;
                    cancelBtn.Enabled = false;

                    txtName.Enabled = false;

                    dgvPublisher.ClearSelection();
                    ClearForms();
                }
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
            deleteBtn.Enabled = false;
            updateBtn.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;

            txtName.Enabled = false;

            dgvPublisher.ClearSelection();
            ClearForms();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dgvPublisher.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Id = (int)currentRow.Cells[0].Value;
                    var pub = library.Publishers.FirstOrDefault(x => x.Id == Id);
                    if (pub != null)
                    {
                        library.Publishers.Remove(pub);

                        library.SaveChanges();
                        LoadPublishers();

                        addBtn.Enabled = true;
                        deleteBtn.Enabled = false;
                        updateBtn.Enabled = false;
                        saveBtn.Enabled = false;
                        cancelBtn.Enabled = false;

                        txtName.Enabled = false;

                        dgvPublisher.ClearSelection();
                        ClearForms();
                    }
                }
            }
        }

        private void dgvPublisher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPublisher.CurrentRow != null)
            {
                currentRow = dgvPublisher.CurrentRow;

                txtName.Text = currentRow.Cells[1].Value.ToString();

                txtName.Enabled = false;

                addBtn.Enabled = false;
                deleteBtn.Enabled = true;
                updateBtn.Enabled = true;
                cancelBtn.Enabled = true;
            }
        }
    }
}
