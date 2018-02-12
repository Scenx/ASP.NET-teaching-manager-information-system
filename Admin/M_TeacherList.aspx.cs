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
    public partial class M_TeacherList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                string sqlstr = " where 1=1 ";
                if (Request["teacherNumber"] != null && Request["teacherNumber"].ToString() != "")
                {
                    sqlstr += "  and teacherNumber like '%" + Request["teacherNumber"].ToString() + "%'";
                    teacherNumber.Text = Request["teacherNumber"].ToString();
                }
                if (Request["teacherName"] != null && Request["teacherName"].ToString() != "")
                {
                    sqlstr += "  and teacherName like '%" + Request["teacherName"].ToString() + "%'";
                    teacherName.Text = Request["teacherName"].ToString();
                }
                if (Request["teacherBirthday"] != null && Request["teacherBirthday"].ToString() != "")
                {
                    sqlstr += "  and teacherBirthday= '" + Request["teacherBirthday"].ToString() + "'";
                    teacherBirthday.Text = Request["teacherBirthday"].ToString();
                }
                if (Request["teacherArriveDate"] != null && Request["teacherArriveDate"].ToString() != "")
                {
                    sqlstr += "  and teacherArriveDate= '" + Request["teacherArriveDate"].ToString() + "'";
                    teacherArriveDate.Text = Request["teacherArriveDate"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        protected void BtnTeacherAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_EditTeacher.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllTeacher.DelTeacher(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "M_TeacherList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
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
            DataTable dsLog = BLL.bllTeacher.GetTeacher(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpTeacher.DataSource = dsLog;
            RpTeacher.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
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
        protected void RpTeacher_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllTeacher.DelTeacher((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "M_TeacherList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "M_TeacherList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "M_TeacherList.aspx");
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_TeacherList.aspx?teacherNumber=" + teacherNumber.Text.Trim() + "&&teacherName=" + teacherName.Text.Trim()+ "&&teacherBirthday=" + teacherBirthday.Text.Trim()+ "&&teacherArriveDate=" + teacherArriveDate.Text.Trim());
        }
    }
}
