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
    public partial class M_ScoreInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindStudent();
                BindCourseInfo();
                string sqlstr = " where 1=1 ";
                if (Request["studentNumber"] != null && Request["studentNumber"].ToString() != "")
                {
                    sqlstr += "  and studentNumber='" + Request["studentNumber"].ToString() + "'";
                    studentNumber.SelectedValue = Request["studentNumber"].ToString();
                }
                if (Request["courseNumber"] != null && Request["courseNumber"].ToString() != "")
                {
                    sqlstr += "  and courseNumber='" + Request["courseNumber"].ToString() + "'";
                    courseNumber.SelectedValue = Request["courseNumber"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindStudent()
        {
            studentNumber.DataSource = BLL.bllStudent.getAllStudent();
            studentNumber.DataTextField = "studentName";
            studentNumber.DataValueField = "studentNumber";
            studentNumber.DataBind();
            ListItem li = new ListItem("=��ѡ��=", "");
            studentNumber.Items.Add(li);
            studentNumber.SelectedValue = "";
        }

        private void BindCourseInfo()
        {
            courseNumber.DataSource = BLL.bllCourseInfo.getAllCourseInfo();
            courseNumber.DataTextField = "courseName";
            courseNumber.DataValueField = "courseNumber";
            courseNumber.DataBind();
            ListItem li = new ListItem("=��ѡ��=", "");
            courseNumber.Items.Add(li);
            courseNumber.SelectedValue = "";
        }

        protected void BtnScoreInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_EditScoreInfo.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllScoreInfo.DelScoreInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "M_ScoreInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "ɾ��ʧ��..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllScoreInfo.GetScoreInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpScoreInfo.DataSource = dsLog;
            RpScoreInfo.DataBind();
            PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpScoreInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllScoreInfo.DelScoreInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "M_ScoreInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "M_ScoreInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "M_ScoreInfoList.aspx");
                }
            }
        }
        public string GetStudentstudentNumber(string studentNumber)
        {
            return BLL.bllStudent.getSomeStudent(studentNumber).studentName;
        }

        public string GetCourseInfocourseNumber(string courseNumber)
        {
            return BLL.bllCourseInfo.getSomeCourseInfo(courseNumber).courseName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_ScoreInfoList.aspx?studentNumber=" + studentNumber.SelectedValue.Trim() + "&&courseNumber=" + courseNumber.SelectedValue.Trim());
        }
    }
}
