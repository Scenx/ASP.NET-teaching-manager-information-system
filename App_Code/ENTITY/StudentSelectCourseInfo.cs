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
    ///StudentSelectCourseInfo 的摘要说明：选课信息实体
    /// </summary>

    public class StudentSelectCourseInfo
    {
        /*记录编号*/
        private int _selectId;
        public int selectId
        {
            get { return _selectId; }
            set { _selectId = value; }
        }

        /*学生对象*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        /*课程对象*/
        private string _courseNumber;
        public string courseNumber
        {
            get { return _courseNumber; }
            set { _courseNumber = value; }
        }

    }
}
