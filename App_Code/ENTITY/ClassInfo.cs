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
    ///ClassInfo 的摘要说明：班级信息实体
    /// </summary>

    public class ClassInfo
    {
        /*班级编号*/
        private string _classNumber;
        public string classNumber
        {
            get { return _classNumber; }
            set { _classNumber = value; }
        }

        /*班级名称*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*所属专业*/
        private string _classSpecialFieldNumber;
        public string classSpecialFieldNumber
        {
            get { return _classSpecialFieldNumber; }
            set { _classSpecialFieldNumber = value; }
        }

        /*成立日期*/
        private DateTime _classBirthDate;
        public DateTime classBirthDate
        {
            get { return _classBirthDate; }
            set { _classBirthDate = value; }
        }

        /*班主任*/
        private string _classTeacherCharge;
        public string classTeacherCharge
        {
            get { return _classTeacherCharge; }
            set { _classTeacherCharge = value; }
        }

        /*联系电话*/
        private string _classTelephone;
        public string classTelephone
        {
            get { return _classTelephone; }
            set { _classTelephone = value; }
        }

        /*附加信息*/
        private string _classMemo;
        public string classMemo
        {
            get { return _classMemo; }
            set { _classMemo = value; }
        }

    }
}
