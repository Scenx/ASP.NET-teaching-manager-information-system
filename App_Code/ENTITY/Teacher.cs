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
    ///Teacher ��ժҪ˵������ʦ��Ϣʵ��
    /// </summary>

    public class Teacher
    {
        /*��ʦ���*/
        private string _teacherNumber;
        public string teacherNumber
        {
            get { return _teacherNumber; }
            set { _teacherNumber = value; }
        }

        /*��ʦ����*/
        private string _teacherName;
        public string teacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }

        /*��¼����*/
        private string _teacherPassword;
        public string teacherPassword
        {
            get { return _teacherPassword; }
            set { _teacherPassword = value; }
        }

        /*�Ա�*/
        private string _teacherSex;
        public string teacherSex
        {
            get { return _teacherSex; }
            set { _teacherSex = value; }
        }

        /*��������*/
        private DateTime _teacherBirthday;
        public DateTime teacherBirthday
        {
            get { return _teacherBirthday; }
            set { _teacherBirthday = value; }
        }

        /*��ְ����*/
        private DateTime _teacherArriveDate;
        public DateTime teacherArriveDate
        {
            get { return _teacherArriveDate; }
            set { _teacherArriveDate = value; }
        }

        /*���֤��*/
        private string _teacherCardNumber;
        public string teacherCardNumber
        {
            get { return _teacherCardNumber; }
            set { _teacherCardNumber = value; }
        }

        /*��ϵ�绰*/
        private string _teacherPhone;
        public string teacherPhone
        {
            get { return _teacherPhone; }
            set { _teacherPhone = value; }
        }

        /*��ʦ��Ƭ*/
        private string _teacherPhoto;
        public string teacherPhoto
        {
            get { return _teacherPhoto; }
            set { _teacherPhoto = value; }
        }

        /*��ͥ��ַ*/
        private string _teacherAddress;
        public string teacherAddress
        {
            get { return _teacherAddress; }
            set { _teacherAddress = value; }
        }

        /*������Ϣ*/
        private string _teacherMemo;
        public string teacherMemo
        {
            get { return _teacherMemo; }
            set { _teacherMemo = value; }
        }

    }
}
