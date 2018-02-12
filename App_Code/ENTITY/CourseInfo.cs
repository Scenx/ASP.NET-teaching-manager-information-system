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
    ///CourseInfo 的摘要说明：课程信息实体
    /// </summary>

    public class CourseInfo
    {
        /*课程编号*/
        private string _courseNumber;
        public string courseNumber
        {
            get { return _courseNumber; }
            set { _courseNumber = value; }
        }

        /*课程名称*/
        private string _courseName;
        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        /*上课老师*/
        private string _courseTeacher;
        public string courseTeacher
        {
            get { return _courseTeacher; }
            set { _courseTeacher = value; }
        }

        /*上课时间*/
        private string _courseTime;
        public string courseTime
        {
            get { return _courseTime; }
            set { _courseTime = value; }
        }

        /*上课地点*/
        private string _coursePlace;
        public string coursePlace
        {
            get { return _coursePlace; }
            set { _coursePlace = value; }
        }

        /*课程学分*/
        private float _courseScore;
        public float courseScore
        {
            get { return _courseScore; }
            set { _courseScore = value; }
        }

        /*附加信息*/
        private string _courseMemo;
        public string courseMemo
        {
            get { return _courseMemo; }
            set { _courseMemo = value; }
        }

    }
}
