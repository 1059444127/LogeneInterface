namespace LGI.Core.Model
{
    /// <summary>
    /// PIS调用接口传入的查询参数
    /// </summary>
    public class GetHisInfo
    {
        private string _sHISName;
        private string _Sslbx;
        private string _Ssbz;
        private bool _Debug;
        private string _by;

        /// <summary>
        /// 医院名称,与LGI.HSP里具体的医院接口实现名称对应,请使用中文名<
        /// </summary>
        public string SHisName
        {
            get { return _sHISName; }
            set { _sHISName = value; }
        }

        /// <summary>
        /// 查询类型,如门诊号,住院号等,PIS端可动态维护
        /// </summary>
        public string Sslbx
        {
            get { return _Sslbx; }
            set { _Sslbx = value; }
        }

        /// <summary>
        /// 查询条件,如门诊号,住院号的具体值
        /// </summary>
        public string Ssbz
        {
            get { return _Ssbz; }
            set { _Ssbz = value; }
        }

        /// <summary>
        /// 是否调试模式,调试模式下log会记录更多信息
        /// </summary>
        public bool Debug
        {
            get { return _Debug; }
            set { _Debug = value; }
        }

        public string By
        {
            get { return _by; }
            set { _by = value; }
        }
    }
}