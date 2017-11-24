using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraCharts;
using LGI.Core.Model;

namespace WebReport
{
    public partial class EbvLineReport : System.Web.UI.Page
    {
        public T_JCXX Jcxx = new T_JCXX();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var db = ContextPool.GetContext();
                var blh = Request["blh"];
                Jcxx = db.T_JCXX.SingleOrDefault(o => o.F_BLH == blh);
                if (Jcxx == null)
                    Response.Redirect("NotDataFound.aspx");

                double referenceValue = 0;
                var seriesName = "";
                var seriesName2 = "";
                if (Jcxx.F_BLK == "EBV")
                {
                    seriesName = "结果值(copy/mL)";
                    seriesName2 = "参考值(copy/mL)";

                }
                else if (Jcxx.F_BLK == "HBV")
                {
                    seriesName = "结果值(IU/mL)";
                    seriesName2 = "参考值(IU/mL)";
                }
                WebChartControl1.Series[0].Name =seriesName;
                WebChartControl1.Series[1].Name = seriesName2;
            }
        }

        public List<ChartItem> GetChartItems(string blh)
        {
            var db = ContextPool.GetContext();

            var jcxx = db.T_JCXX.SingleOrDefault(o => o.F_BLH == blh);
            if (jcxx == null)
            {
                return new List<ChartItem>();
            }
            var chartItems = (from jc in db.T_JCXX
                join tb in db.T_TBS_BG on jc.F_BLH equals tb.F_BLH
                where jc.F_BRBH == jcxx.F_BRBH && jc.F_BLK == jcxx.F_BLK && jc.F_BGZT=="已审核"
                select new ChartItem
                {
                    TestDate = jc.F_SPARE5.Substring(0,jc.F_SPARE5.Length-9),
                    ResultText = tb.F_TBS_XBXM1,
                    ReferenceValueText =tb.F_TBS_XBXM2
                    // Result = ChangeToDouble(tb.F_TBS_XBXM1.Replace("copy/mL","").Trim())
                }).ToList();

            //结果值
            chartItems.ForEach(o => o.Result = ChangeToDouble(o.ResultText.Replace("copy/mL", "").Replace("IU/mL","").Trim()));
            //参考值
            try
            {
                chartItems.ForEach(o => o.ReferenceValue = Convert.ToDouble(o.ReferenceValueText
                    .Replace("copy/mL", "")
                    .Replace("IU/mL", "")
                    .Replace("＜","")
                    .Trim()));
            }
            catch (Exception e)
            {
                }

            return chartItems;
        }

        public class ChartItem
        {
            public string TestDate { get; set; }
            public double Result { get; set; }
            public string ResultText { get; set; }
            public double ReferenceValue { get; set; }public string ReferenceValueText { get; set; }
        }

        /// <summary>
        /// 数字科学计数法处理
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        private double ChangeToDouble(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            else
            {
                dData = Convert.ToDecimal(strData);
            }
            return (double) Math.Round(dData, 4);
        }
    }
}