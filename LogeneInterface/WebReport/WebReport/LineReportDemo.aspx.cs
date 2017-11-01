using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebReport
{
    public partial class LineReportDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public class LineReportDemoItem
    {
        public DateTime TestDate { get; set; }
        public double Result { get; set; } = 1.1233;
    }

    public static  class MonkData
    {
        public static List<LineReportDemoItem> GetLineReportDemoItems()
        {
            var lst  = new List<LineReportDemoItem>();
            lst.Add(new LineReportDemoItem
            {
                TestDate = DateTime.Now.AddDays(0),
                Result = (new Random(1)).Next(100,400)
            });
            lst.Add(new LineReportDemoItem
            {
                TestDate = DateTime.Now.AddDays(5),
                Result = (new Random(2)).Next(100, 400)
            });
            lst.Add(new LineReportDemoItem
            {
                TestDate = DateTime.Now.AddDays(10),
                Result = (new Random(3)).Next(100, 400)
            });
            lst.Add(new LineReportDemoItem
            {
                TestDate = DateTime.Now.AddDays(20),
                Result = (new Random(4)).Next(100, 400)
            });
            lst.Add(new LineReportDemoItem
            {
                TestDate = DateTime.Now.AddDays(25),
                Result = (new Random(5)).Next(100, 400)
            });

            return lst;
        } 
    }
}