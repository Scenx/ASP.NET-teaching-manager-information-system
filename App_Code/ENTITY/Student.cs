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
    ///Student ��ժҪ˵����ѧ����Ϣʵ��
    /// </summary>

    public class Student
    {
        /*ѧ��*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        /*����*/
        private string _studentName;
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        /*��¼����*/
        private string _studentPassword;
        public string studentPassword
        {
            get { return _studentPassword; }
            set { _studentPassword = value; }
        }

        /*�Ա�*/
        private string _studentSex;
        public string studentSex
        {
            get { return _studentSex; }
            set { _studentSex = value; }
        }

        /*���ڰ༶*/
        private string _studentClassNumber;
        public string studentClassNumber
        {
            get { return _studentClassNumber; }
            set { _studentClassNumber = value; }
        }

        /*��������*/
        private DateTime _studentBirthday;
        public DateTime studentBirthday
        {
            get { return _studentBirthday; }
            set { _studentBirthday = value; }
        }

        /*������ò*/
        private string _studentState;
        public string studentState
        {
            get { return _studentState; }
            set { _studentState = value; }
        }

        /*ѧ����Ƭ*/
        private string _studentPhoto;
        public string studentPhoto
        {
            get { return _studentPhoto; }
            set { _studentPhoto = value; }
        }

        /*��ϵ�绰*/
        private string _studentTelephone;
        public string studentTelephone
        {
            get { return _studentTelephone; }
            set { _studentTelephone = value; }
        }

        /*ѧ������*/
        private string _studentEmail;
        public string studentEmail
        {
            get { return _studentEmail; }
            set { _studentEmail = value; }
        }

        /*��ϵqq*/
        private string _studentQQ;
        public string studentQQ
        {
            get { return _studentQQ; }
            set { _studentQQ = value; }
        }

        /*��ͥ��ַ*/
        private string _studentAddress;
        public string studentAddress
        {
            get { return _studentAddress; }
            set { _studentAddress = value; }
        }

        /*������Ϣ*/
        private string _studentMemo;
        public string studentMemo
        {
            get { return _studentMemo; }
            set { _studentMemo = value; }
        }

    }
}
