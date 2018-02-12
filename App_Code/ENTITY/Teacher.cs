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
    ///Teacher 的摘要说明：教师信息实体
    /// </summary>

    public class Teacher
    {
        /*教师编号*/
        private string _teacherNumber;
        public string teacherNumber
        {
            get { return _teacherNumber; }
            set { _teacherNumber = value; }
        }

        /*教师姓名*/
        private string _teacherName;
        public string teacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }

        /*登录密码*/
        private string _teacherPassword;
        public string teacherPassword
        {
            get { return _teacherPassword; }
            set { _teacherPassword = value; }
        }

        /*性别*/
        private string _teacherSex;
        public string teacherSex
        {
            get { return _teacherSex; }
            set { _teacherSex = value; }
        }

        /*出生日期*/
        private DateTime _teacherBirthday;
        public DateTime teacherBirthday
        {
            get { return _teacherBirthday; }
            set { _teacherBirthday = value; }
        }

        /*入职日期*/
        private DateTime _teacherArriveDate;
        public DateTime teacherArriveDate
        {
            get { return _teacherArriveDate; }
            set { _teacherArriveDate = value; }
        }

        /*身份证号*/
        private string _teacherCardNumber;
        public string teacherCardNumber
        {
            get { return _teacherCardNumber; }
            set { _teacherCardNumber = value; }
        }

        /*联系电话*/
        private string _teacherPhone;
        public string teacherPhone
        {
            get { return _teacherPhone; }
            set { _teacherPhone = value; }
        }

        /*教师照片*/
        private string _teacherPhoto;
        public string teacherPhoto
        {
            get { return _teacherPhoto; }
            set { _teacherPhoto = value; }
        }

        /*家庭地址*/
        private string _teacherAddress;
        public string teacherAddress
        {
            get { return _teacherAddress; }
            set { _teacherAddress = value; }
        }

        /*附加信息*/
        private string _teacherMemo;
        public string teacherMemo
        {
            get { return _teacherMemo; }
            set { _teacherMemo = value; }
        }

    }
}
