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
    ///Student 的摘要说明：学生信息实体
    /// </summary>

    public class Student
    {
        /*学号*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        /*姓名*/
        private string _studentName;
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        /*登录密码*/
        private string _studentPassword;
        public string studentPassword
        {
            get { return _studentPassword; }
            set { _studentPassword = value; }
        }

        /*性别*/
        private string _studentSex;
        public string studentSex
        {
            get { return _studentSex; }
            set { _studentSex = value; }
        }

        /*所在班级*/
        private string _studentClassNumber;
        public string studentClassNumber
        {
            get { return _studentClassNumber; }
            set { _studentClassNumber = value; }
        }

        /*出生日期*/
        private DateTime _studentBirthday;
        public DateTime studentBirthday
        {
            get { return _studentBirthday; }
            set { _studentBirthday = value; }
        }

        /*政治面貌*/
        private string _studentState;
        public string studentState
        {
            get { return _studentState; }
            set { _studentState = value; }
        }

        /*学生照片*/
        private string _studentPhoto;
        public string studentPhoto
        {
            get { return _studentPhoto; }
            set { _studentPhoto = value; }
        }

        /*联系电话*/
        private string _studentTelephone;
        public string studentTelephone
        {
            get { return _studentTelephone; }
            set { _studentTelephone = value; }
        }

        /*学生邮箱*/
        private string _studentEmail;
        public string studentEmail
        {
            get { return _studentEmail; }
            set { _studentEmail = value; }
        }

        /*联系qq*/
        private string _studentQQ;
        public string studentQQ
        {
            get { return _studentQQ; }
            set { _studentQQ = value; }
        }

        /*家庭地址*/
        private string _studentAddress;
        public string studentAddress
        {
            get { return _studentAddress; }
            set { _studentAddress = value; }
        }

        /*附加信息*/
        private string _studentMemo;
        public string studentMemo
        {
            get { return _studentMemo; }
            set { _studentMemo = value; }
        }

    }
}
