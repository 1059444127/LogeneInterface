using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LGInterface
{
    public partial class ApplicationSelector : Form
    {
        public DataTable Table { get; set; }
        public DataRow SelectedRow { get; set; } = null;

        public event Action<DataRow> ItemSelected;

        public ApplicationSelector()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataRowView rv = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            OnItemSelected(rv.Row);
        }

        protected virtual void OnItemSelected(DataRow obj)
        {
            SelectedRow = obj;
            ItemSelected?.Invoke(obj);
            Close();
        }

        private void ApplicationSelector_Load(object sender, EventArgs e)
        {
            if (Table == null || Table.Rows.Count == 0)
            {
                MessageBox.Show("没有查询到任何申请项目!");
                Close();
            }
            else
            {
                dataGridView1.DataSource = Table.DefaultView.ToTable();
                dataGridView1.AutoResizeColumns();
            }
        }

        private void ApplicationSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
