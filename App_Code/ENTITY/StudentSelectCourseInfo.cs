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
    ///StudentSelectCourseInfo ��ժҪ˵����ѡ����Ϣʵ��
    /// </summary>

    public class StudentSelectCourseInfo
    {
        /*��¼���*/
        private int _selectId;
        public int selectId
        {
            get { return _selectId; }
            set { _selectId = value; }
        }

        /*ѧ������*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        /*�γ̶���*/
        private string _courseNumber;
        public string courseNumber
        {
            get { return _courseNumber; }
            set { _courseNumber = value; }
        }

    }
}
