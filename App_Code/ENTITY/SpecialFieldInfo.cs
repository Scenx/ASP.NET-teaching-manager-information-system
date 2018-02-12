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
    ///SpecialFieldInfo 的摘要说明：专业信息实体
    /// </summary>

    public class SpecialFieldInfo
    {
        /*专业编号*/
        private string _specialFieldNumber;
        public string specialFieldNumber
        {
            get { return _specialFieldNumber; }
            set { _specialFieldNumber = value; }
        }

        /*专业名称*/
        private string _specialFieldName;
        public string specialFieldName
        {
            get { return _specialFieldName; }
            set { _specialFieldName = value; }
        }

        /*所在学院*/
        private string _specialCollegeNumber;
        public string specialCollegeNumber
        {
            get { return _specialCollegeNumber; }
            set { _specialCollegeNumber = value; }
        }

        /*成立日期*/
        private DateTime _specialBirthDate;
        public DateTime specialBirthDate
        {
            get { return _specialBirthDate; }
            set { _specialBirthDate = value; }
        }

        /*联系人*/
        private string _specialMan;
        public string specialMan
        {
            get { return _specialMan; }
            set { _specialMan = value; }
        }

        /*联系电话*/
        private string _specialTelephone;
        public string specialTelephone
        {
            get { return _specialTelephone; }
            set { _specialTelephone = value; }
        }

        /*附加信息*/
        private string _specialMemo;
        public string specialMemo
        {
            get { return _specialMemo; }
            set { _specialMemo = value; }
        }

    }
}
