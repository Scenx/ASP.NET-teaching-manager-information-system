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
    public partial class M_StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindClassInfo();
                string sqlstr = " where 1=1 ";
                if (Request["studentNumber"] != null && Request["studentNumber"].ToString() != "")
                {
                    sqlstr += "  and studentNumber like '%" + Request["studentNumber"].ToString() + "%'";
                    studentNumber.Text = Request["studentNumber"].ToString();
                }
                if (Request["studentName"] != null && Request["studentName"].ToString() != "")
                {
                    sqlstr += "  and studentName like '%" + Request["studentName"].ToString() + "%'";
                    studentName.Text = Request["studentName"].ToString();
                }
                if (Request["studentClassNumber"] != null && Request["studentClassNumber"].ToString() != "")
                {
                    sqlstr += "  and studentClassNumber='" + Request["studentClassNumber"].ToString() + "'";
                    studentClassNumber.SelectedValue = Request["studentClassNumber"].ToString();
                }
                if (Request["studentBirthday"] != null && Request["studentBirthday"].ToString() != "")
                {
                    sqlstr += "  and studentBirthday= '" + Request["studentBirthday"].ToString() + "'";
                    studentBirthday.Text = Request["studentBirthday"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindClassInfo()
        {
            studentClassNumber.DataSource = BLL.bllClassInfo.getAllClassInfo();
            studentClassNumber.DataTextField = "className";
            studentClassNumber.DataValueField = "classNumber";
            studentClassNumber.DataBind();
            ListItem li = new ListItem("=请选择=", "");
            studentClassNumber.Items.Add(li);
            studentClassNumber.SelectedValue = "";
        }

        protected void BtnStudentAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_EditStudent.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllStudent.DelStudent(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "M_StudentList.aspx");
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
            DataTable dsLog = BLL.bllStudent.GetStudent(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpStudent.DataSource = dsLog;
            RpStudent.DataBind();
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
        protected void RpStudent_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllStudent.DelStudent((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "M_StudentList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "M_StudentList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "M_StudentList.aspx");
                }
            }
        }
        public string GetClassInfostudentClassNumber(string studentClassNumber)
        {
            return BLL.bllClassInfo.getSomeClassInfo(studentClassNumber).className;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_StudentList.aspx?studentNumber=" + studentNumber.Text.Trim() + "&&studentName=" + studentName.Text.Trim() + "&&studentClassNumber=" + studentClassNumber.SelectedValue.Trim()+ "&&studentBirthday=" + studentBirthday.Text.Trim());
        }
    }
}
