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
    public partial class M_EditScoreInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindStudentstudentNumber();
                BindCourseInfocourseNumber();
                if (Request["scoreId"] != null)
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
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "scoreId")))
            {
                ENTITY.ScoreInfo scoreInfo = BLL.bllScoreInfo.getSomeScoreInfo(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "scoreId")));
                studentNumber.SelectedValue = scoreInfo.studentNumber;
                courseNumber.SelectedValue = scoreInfo.courseNumber;
                scoreValue.Value = scoreInfo.scoreValue.ToString("0.00");
                studentEvaluate.Value = scoreInfo.studentEvaluate;
            }
        }

        protected void BtnScoreInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.ScoreInfo scoreInfo = new ENTITY.ScoreInfo();
            scoreInfo.studentNumber = studentNumber.SelectedValue;
            scoreInfo.courseNumber = courseNumber.SelectedValue;
            scoreInfo.scoreValue = float.Parse(float.Parse(scoreValue.Value).ToString("0.00"));
            scoreInfo.studentEvaluate = studentEvaluate.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "scoreId")))
            {
                scoreInfo.scoreId = int.Parse(Request["scoreId"]);
                if (BLL.bllScoreInfo.EditScoreInfo(scoreInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditScoreInfo.aspx?scoreId=" + Request["scoreId"] + "\"} else  {location.href=\"M_ScoreInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllScoreInfo.AddScoreInfo(scoreInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditScoreInfo.aspx\"} else  {location.href=\"M_ScoreInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_ScoreInfoList.aspx");
        }
    }
}

