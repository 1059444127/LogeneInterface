using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using LGI.Core.Model;

namespace LGI.Common.Crisis
{
    public partial class Main : XtraForm
    {
        private PathnetEntities _context = null;

        public Main()
        {
            InitializeComponent();
            dteSbsj1.DateTime = DateTime.Now.AddMonths(-1); ;
            dteSbsj2.DateTime = DateTime.Now;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _context = ContextPool.GetContext();
            var filterStr = txtFilter.Text.Trim();

            var query = (from o in _context.T_LGI_WJZ
                join j in _context.T_JCXX on o.F_BLH equals j.F_BLH
                where o.F_SBSJ >= dteSbsj1.DateTime && o.F_SBSJ <= dteSbsj2.DateTime
                select new {Wjz=o,Jcxx=j});

            var lstWjz = new List<T_LGI_WJZ>();
            foreach (var x1 in query)
            {
                x1.Wjz.Jcxx = x1.Jcxx;
                lstWjz.Add(x1.Wjz);
            }

            tLGIWJZBindingSource.DataSource = lstWjz;
            gridView1.RefreshData();
        }
    }
}