using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace shuangyulin.Front
{
    public partial class Front_CourseInfo_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["courseNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "courseNumber")))
            {
                ENTITY.CourseInfo courseInfo = BLL.bllCourseInfo.getSomeCourseInfo(Common.GetMes.GetRequestQuery(Request, "courseNumber"));
                courseNumber.Text = courseInfo.courseNumber;
                courseName.Text = courseInfo.courseName;
            courseTeacher.Text = BLL.bllTeacher.getSomeTeacher(courseInfo.courseTeacher).teacherName;
                courseTime.Text = courseInfo.courseTime;
                coursePlace.Text = courseInfo.coursePlace;
                courseScore.Text = courseInfo.courseScore.ToString("0.00");
                courseMemo.Text = courseInfo.courseMemo;
            }
        }
    }
}
