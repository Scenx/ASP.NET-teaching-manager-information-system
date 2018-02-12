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

namespace shuangyulin.Admin
{
    public partial class M_EditCourseInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindTeachercourseTeacher();
                if (Request["courseNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindTeachercourseTeacher()
        {
            courseTeacher.DataSource = BLL.bllTeacher.getAllTeacher();
            courseTeacher.DataTextField = "teacherName";
            courseTeacher.DataValueField = "teacherNumber";
            courseTeacher.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "courseNumber")))
            {
                ENTITY.CourseInfo courseInfo = BLL.bllCourseInfo.getSomeCourseInfo(Common.GetMes.GetRequestQuery(Request, "courseNumber"));
                courseNumber.Value = courseInfo.courseNumber;
                courseName.Value = courseInfo.courseName;
                courseTeacher.SelectedValue = courseInfo.courseTeacher;
                courseTime.Value = courseInfo.courseTime;
                coursePlace.Value = courseInfo.coursePlace;
                courseScore.Value = courseInfo.courseScore.ToString("0.00");
                courseMemo.Value = courseInfo.courseMemo;
            }
        }

        protected void BtnCourseInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.CourseInfo courseInfo = new ENTITY.CourseInfo();
            courseInfo.courseNumber = this.courseNumber.Value;
            courseInfo.courseName = courseName.Value;
            courseInfo.courseTeacher = courseTeacher.SelectedValue;
            courseInfo.courseTime = courseTime.Value;
            courseInfo.coursePlace = coursePlace.Value;
            courseInfo.courseScore = float.Parse(float.Parse(courseScore.Value).ToString("0.00"));
            courseInfo.courseMemo = courseMemo.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "courseNumber")))
            {
                courseInfo.courseNumber = Request["courseNumber"];
                if (BLL.bllCourseInfo.EditCourseInfo(courseInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCourseInfo.aspx?courseNumber=" + Request["courseNumber"] + "\"} else  {location.href=\"M_CourseInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllCourseInfo.AddCourseInfo(courseInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCourseInfo.aspx\"} else  {location.href=\"M_CourseInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_CourseInfoList.aspx");
        }
    }
}

