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
    public partial class M_EditStudentSelectCourseInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindStudentstudentNumber();
                BindCourseInfocourseNumber();
                if (Request["selectId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindStudentstudentNumber()
        {
            studentNumber.DataSource = BLL.bllStudent.getAllStudent();
            studentNumber.DataTextField = "studentName";
            studentNumber.DataValueField = "studentNumber";
            studentNumber.DataBind();
        }

        private void BindCourseInfocourseNumber()
        {
            courseNumber.DataSource = BLL.bllCourseInfo.getAllCourseInfo();
            courseNumber.DataTextField = "courseName";
            courseNumber.DataValueField = "courseNumber";
            courseNumber.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "selectId")))
            {
                ENTITY.StudentSelectCourseInfo studentSelectCourseInfo = BLL.bllStudentSelectCourseInfo.getSomeStudentSelectCourseInfo(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "selectId")));
                studentNumber.SelectedValue = studentSelectCourseInfo.studentNumber;
                courseNumber.SelectedValue = studentSelectCourseInfo.courseNumber;
            }
        }

        protected void BtnStudentSelectCourseInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.StudentSelectCourseInfo studentSelectCourseInfo = new ENTITY.StudentSelectCourseInfo();
            studentSelectCourseInfo.studentNumber = studentNumber.SelectedValue;
            studentSelectCourseInfo.courseNumber = courseNumber.SelectedValue;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "selectId")))
            {
                studentSelectCourseInfo.selectId = int.Parse(Request["selectId"]);
                if (BLL.bllStudentSelectCourseInfo.EditStudentSelectCourseInfo(studentSelectCourseInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditStudentSelectCourseInfo.aspx?selectId=" + Request["selectId"] + "\"} else  {location.href=\"M_StudentSelectCourseInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllStudentSelectCourseInfo.AddStudentSelectCourseInfo(studentSelectCourseInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditStudentSelectCourseInfo.aspx\"} else  {location.href=\"M_StudentSelectCourseInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_StudentSelectCourseInfoList.aspx");
        }
    }
}

