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
    ///CollegeInfo ��ժҪ˵����ѧԺ��Ϣʵ��
    /// </summary>

    public class CollegeInfo
    {
        /*ѧԺ���*/
        private string _collegeNumber;
        public string collegeNumber
        {
            get { return _collegeNumber; }
            set { _collegeNumber = value; }
        }

        /*ѧԺ����*/
        private string _collegeName;
        public string collegeName
        {
            get { return _collegeName; }
            set { _collegeName = value; }
        }

        /*��������*/
        private DateTime _collegeBirthDate;
        public DateTime collegeBirthDate
        {
            get { return _collegeBirthDate; }
            set { _collegeBirthDate = value; }
        }

        /*Ժ������*/
        private string _collegeMan;
        public string collegeMan
        {
            get { return _collegeMan; }
            set { _collegeMan = value; }
        }

        /*��ϵ�绰*/
        private string _collegeTelephone;
        public string collegeTelephone
        {
            get { return _collegeTelephone; }
            set { _collegeTelephone = value; }
        }

        /*������Ϣ*/
        private string _collegeMemo;
        public string collegeMemo
        {
            get { return _collegeMemo; }
            set { _collegeMemo = value; }
        }

    }
}
