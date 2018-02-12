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
    ///ClassInfo ��ժҪ˵�����༶��Ϣʵ��
    /// </summary>

    public class ClassInfo
    {
        /*�༶���*/
        private string _classNumber;
        public string classNumber
        {
            get { return _classNumber; }
            set { _classNumber = value; }
        }

        /*�༶����*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*����רҵ*/
        private string _classSpecialFieldNumber;
        public string classSpecialFieldNumber
        {
            get { return _classSpecialFieldNumber; }
            set { _classSpecialFieldNumber = value; }
        }

        /*��������*/
        private DateTime _classBirthDate;
        public DateTime classBirthDate
        {
            get { return _classBirthDate; }
            set { _classBirthDate = value; }
        }

        /*������*/
        private string _classTeacherCharge;
        public string classTeacherCharge
        {
            get { return _classTeacherCharge; }
            set { _classTeacherCharge = value; }
        }

        /*��ϵ�绰*/
        private string _classTelephone;
        public string classTelephone
        {
            get { return _classTelephone; }
            set { _classTelephone = value; }
        }

        /*������Ϣ*/
        private string _classMemo;
        public string classMemo
        {
            get { return _classMemo; }
            set { _classMemo = value; }
        }

    }
}
