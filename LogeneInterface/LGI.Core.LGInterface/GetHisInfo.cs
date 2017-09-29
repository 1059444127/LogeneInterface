namespace LGInterface
{
    /// <summary>
    /// PIS调用接口传入的查询参数
    /// </summary>
    public sealed class GetHisInfo
    {
        private string _sHISName;
        private string _Sslbx;
        private string _Ssbz;
        private bool _Debug;
        private string _by;

        public string SHisName
        {
            get { return _sHISName; }
            set { _sHISName = value; }
        }

        public string Sslbx
        {
            get { return _Sslbx; }
            set { _Sslbx = value; }
        }

        public string Ssbz
        {
            get { return _Ssbz; }
            set { _Ssbz = value; }
        }

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