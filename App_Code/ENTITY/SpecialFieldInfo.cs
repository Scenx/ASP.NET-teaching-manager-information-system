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
    ///SpecialFieldInfo ��ժҪ˵����רҵ��Ϣʵ��
    /// </summary>

    public class SpecialFieldInfo
    {
        /*רҵ���*/
        private string _specialFieldNumber;
        public string specialFieldNumber
        {
            get { return _specialFieldNumber; }
            set { _specialFieldNumber = value; }
        }

        /*רҵ����*/
        private string _specialFieldName;
        public string specialFieldName
        {
            get { return _specialFieldName; }
            set { _specialFieldName = value; }
        }

        /*����ѧԺ*/
        private string _specialCollegeNumber;
        public string specialCollegeNumber
        {
            get { return _specialCollegeNumber; }
            set { _specialCollegeNumber = value; }
        }

        /*��������*/
        private DateTime _specialBirthDate;
        public DateTime specialBirthDate
        {
            get { return _specialBirthDate; }
            set { _specialBirthDate = value; }
        }

        /*��ϵ��*/
        private string _specialMan;
        public string specialMan
        {
            get { return _specialMan; }
            set { _specialMan = value; }
        }

        /*��ϵ�绰*/
        private string _specialTelephone;
        public string specialTelephone
        {
            get { return _specialTelephone; }
            set { _specialTelephone = value; }
        }

        /*������Ϣ*/
        private string _specialMemo;
        public string specialMemo
        {
            get { return _specialMemo; }
            set { _specialMemo = value; }
        }

    }
}
