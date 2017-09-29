using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var f = new global::LGInterface.LGInterface();
            var xml = f.LGGetHISINFO("测试医院", "", "", "", "");
            MessageBox.Show(xml);
        }
    }
}