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
    public partial class M_CourseInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindTeacher();
                string sqlstr = " where 1=1 ";
                if (Request["courseNumber"] != null && Request["courseNumber"].ToString() != "")
                {
                    sqlstr += "  and courseNumber like '%" + Request["courseNumber"].ToString() + "%'";
                    courseNumber.Text = Request["courseNumber"].ToString();
                }
                if (Request["courseName"] != null && Request["courseName"].ToString() != "")
                {
                    sqlstr += "  and courseName like '%" + Request["courseName"].ToString() + "%'";
                    courseName.Text = Request["courseName"].ToString();
                }
                if (Request["courseTeacher"] != null && Request["courseTeacher"].ToString() != "")
                {
                    sqlstr += "  and courseTeacher='" + Request["courseTeacher"].ToString() + "'";
                    courseTeacher.SelectedValue = Request["courseTeacher"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindTeacher()
        {
            courseTeacher.DataSource = BLL.bllTeacher.getAllTeacher();
            courseTeacher.DataTextField = "teacherName";
            courseTeacher.DataValueField = "teacherNumber";
            courseTeacher.DataBind();
            ListItem li = new ListItem("=��ѡ��=", "");
            courseTeacher.Items.Add(li);
            courseTeacher.SelectedValue = "";
        }

        protected void BtnCourseInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_EditCourseInfo.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllCourseInfo.DelCourseInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "M_CourseInfoList.aspx");
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
            DataTable dsLog = BLL.bllCourseInfo.GetCourseInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpCourseInfo.DataSource = dsLog;
            RpCourseInfo.DataBind();
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
        protected void RpCourseInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllCourseInfo.DelCourseInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "M_CourseInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "M_CourseInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "M_CourseInfoList.aspx");
                }
            }
        }
        public string GetTeachercourseTeacher(string courseTeacher)
        {
            return BLL.bllTeacher.getSomeTeacher(courseTeacher).teacherName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_CourseInfoList.aspx?courseNumber=" + courseNumber.Text.Trim() + "&&courseName=" + courseName.Text.Trim() + "&&courseTeacher=" + courseTeacher.SelectedValue.Trim());
        }
    }
}
