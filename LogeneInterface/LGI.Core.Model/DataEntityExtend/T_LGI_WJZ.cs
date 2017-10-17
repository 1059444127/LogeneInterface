using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LGI.Core.Model
{
    [MetadataType(typeof(T_LGI_WJZ_MetaData))]
    public partial class T_LGI_WJZ
    {
        public List<T_LGI_WJZ_CL> ListWjzCl { get; set; } 
        public T_JCXX Jcxx { get; set; }

        [Display(Name = "临床处理状态")]
        public string LCCLZTMC
        {
            get
            {
                if (this.F_LCCLZT == 1)
                    return "已处理";
                return "未处理";
            }
        }
    }

    public class T_LGI_WJZ_MetaData
    {
        public string ID;
        [Display(Name="病理号")]
        public string F_BLH;
        [Display(Name = "类型编码")]
        public string F_LXBM;
        [Display(Name = "类型名称")]
        public string F_LXMC;
        [Display(Name = "说明")]
        public string F_SM;
        [Display(Name = "上报人")]
        public string F_SBRXM;
        [Display(Name = "审核人")]
        public string F_SHRXM;
        [Display(Name = "上报时间")]
        public Nullable<System.DateTime> F_SBSJ;
        [Display(Name = "临床处理状态")]
        public Nullable<int> F_LCCLZT;
        [Display(Name = "临床处理时间")]
        public Nullable<System.DateTime> F_LCCLSZ;
    }
}
