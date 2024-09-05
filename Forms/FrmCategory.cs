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
    public partial class FrmCategory : Form
    {
        public bool IsOpened { get; set; } = false;

        Library_MgmtEntities library = new Library_MgmtEntities();

        DataGridViewRow currentRow = new DataGridViewRow();
        public FrmCategory()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.ClearSelection();
        }

        private void LoadCategory()
        {
            var categories = from cate in library.Categories
                             select new
                             {
                                 CategoryID = cate.CategoryID,
                                 CategoryName = cate.Name,
                                 Description = cate.Description
                             };
            dgvCategories.DataSource = categories.ToList();
        }

        private void ClearForms()
        {
            txtName.Text = txtDescription.Text = string.Empty;
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            LoadCategory();
            ClearForms();

            deleteBtn.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
            updateBtn.Enabled = false;

            txtName.Enabled = false;
            txtDescription.Enabled = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            updateBtn.Enabled = false;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
            txtName.Enabled = true;
            txtDescription.Enabled = true;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtDescription.Enabled = true;
            saveBtn.Enabled = true;

            addBtn.Enabled = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (addBtn.Enabled)
            {
                if (txtName.Text.Length <= 0 || txtDescription.Text.Length <= 0)
                {
                    MessageBox.Show("Các trường thông tin không được để trống");
                    return;
                }
                //MessageBox.Show("Add");
                var category = new Category();
                category.Name = txtName.Text;
                category.Description = txtDescription.Text;

                library.Categories.Add(category);
                library.SaveChanges();
                LoadCategory();
                addBtn.Enabled = true;
                deleteBtn.Enabled = false;
                updateBtn.Enabled = false;
                saveBtn.Enabled = false;
                cancelBtn.Enabled = false;

                txtName.Enabled = false;
                txtDescription.Enabled = false;

                dgvCategories.ClearSelection();
                ClearForms();
            }
            if (updateBtn.Enabled)
            {
                int Id = (int)currentRow.Cells[0].Value;
                var cate = library.Categories.FirstOrDefault(x => x.CategoryID == Id);

                if (txtName.Text.Length <= 0 || txtDescription.Text.Length <= 0)
                {
                    MessageBox.Show("Các trường thông tin không được để trống");
                    return;
                }

                if (cate != null)
                {
                    cate.Name = txtName.Text;
                    cate.Description = txtDescription.Text;

                    library.SaveChanges();
                    LoadCategory();

                    addBtn.Enabled = true;
                    deleteBtn.Enabled = false;
                    updateBtn.Enabled = false;
                    saveBtn.Enabled = false;
                    cancelBtn.Enabled = false;

                    txtName.Enabled = false;
                    txtDescription.Enabled = false;

                    dgvCategories.ClearSelection();
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
            txtDescription.Enabled = false;

            dgvCategories.ClearSelection();
            ClearForms();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Id = (int)currentRow.Cells[0].Value;
                    var cate = library.Categories.FirstOrDefault(x => x.CategoryID == Id);
                    if (cate != null)
                    {
                        library.Categories.Remove(cate);

                        library.SaveChanges();
                        LoadCategory();

                        addBtn.Enabled = true;
                        deleteBtn.Enabled = false;
                        updateBtn.Enabled = false;
                        saveBtn.Enabled = false;
                        cancelBtn.Enabled = false;

                        txtName.Enabled = false;
                        txtDescription.Enabled = false;

                        dgvCategories.ClearSelection();
                        ClearForms();
                    }
                }
            }
        }


        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                currentRow = dgvCategories.CurrentRow;

                txtName.Text = currentRow.Cells[1].Value.ToString();
                txtDescription.Text = currentRow.Cells[2].Value.ToString();

                txtName.Enabled = false;
                txtDescription.Enabled = false;

                addBtn.Enabled = false;
                deleteBtn.Enabled = true;
                updateBtn.Enabled = true;
                cancelBtn.Enabled = true;
            }
        }


    }
}
