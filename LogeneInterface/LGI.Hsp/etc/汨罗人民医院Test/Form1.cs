using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 汨罗人民医院Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LGInterface.LGInterface lg = new LGInterface.LGInterface();
            try
            {
               var xml = lg.LGGetHISINFO("汨罗市人民医院", "门诊号", textBox1.Text, "1", "ldy");
                MessageBox.Show(xml);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
