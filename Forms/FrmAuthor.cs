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
    public partial class FrmAuthor : Form
    {
        public bool IsOpened { get; set; } = false;

        Library_MgmtEntities library = new Library_MgmtEntities();

        DataGridViewRow currentRow = new DataGridViewRow();
        public FrmAuthor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            dgvAuthors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuthors.ClearSelection();
        }
    }
}
