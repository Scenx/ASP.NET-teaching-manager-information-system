using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///CollegeInfo 的摘要说明：学院信息实体
    /// </summary>

    public class CollegeInfo
    {
        /*学院编号*/
        private string _collegeNumber;
        public string collegeNumber
        {
            get { return _collegeNumber; }
            set { _collegeNumber = value; }
        }

        /*学院名称*/
        private string _collegeName;
        public string collegeName
        {
            get { return _collegeName; }
            set { _collegeName = value; }
        }

        /*成立日期*/
        private DateTime _collegeBirthDate;
        public DateTime collegeBirthDate
        {
            get { return _collegeBirthDate; }
            set { _collegeBirthDate = value; }
        }

        /*院长姓名*/
        private string _collegeMan;
        public string collegeMan
        {
            get { return _collegeMan; }
            set { _collegeMan = value; }
        }

        /*联系电话*/
        private string _collegeTelephone;
        public string collegeTelephone
        {
            get { return _collegeTelephone; }
            set { _collegeTelephone = value; }
        }

        /*附加信息*/
        private string _collegeMemo;
        public string collegeMemo
        {
            get { return _collegeMemo; }
            set { _collegeMemo = value; }
        }

    }
}
