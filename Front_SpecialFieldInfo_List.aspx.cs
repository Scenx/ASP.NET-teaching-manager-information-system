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
    public partial class Front_SpecialFieldInfo_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCollegeInfo();
                string sqlstr = " where 1=1 ";
                if (Request["specialFieldNumber"] != null && Request["specialFieldNumber"].ToString() != "")
                {
                    sqlstr += "  and specialFieldNumber like '%" + Request["specialFieldNumber"].ToString() + "%'";
                    specialFieldNumber.Text = Request["specialFieldNumber"].ToString();
                }
                if (Request["specialFieldName"] != null && Request["specialFieldName"].ToString() != "")
                {
                    sqlstr += "  and specialFieldName like '%" + Request["specialFieldName"].ToString() + "%'";
                    specialFieldName.Text = Request["specialFieldName"].ToString();
                }
                if (Request["specialCollegeNumber"] != null && Request["specialCollegeNumber"].ToString() != "")
                {
                    sqlstr += "  and specialCollegeNumber='" + Request["specialCollegeNumber"].ToString() + "'";
                    specialCollegeNumber.SelectedValue = Request["specialCollegeNumber"].ToString();
                }
                if (Request["specialBirthDate"] != null && Request["specialBirthDate"].ToString() != "")
                {
                    sqlstr += "  and specialBirthDate= '" + Request["specialBirthDate"].ToString() + "'";
                    specialBirthDate.Text = Request["specialBirthDate"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindCollegeInfo()
        {
            specialCollegeNumber.DataSource = BLL.bllCollegeInfo.getAllCollegeInfo();
            specialCollegeNumber.DataTextField = "collegeName";
            specialCollegeNumber.DataValueField = "collegeNumber";
            specialCollegeNumber.DataBind();
            ListItem li = new ListItem("=请选择=", "");
            specialCollegeNumber.Items.Add(li);
            specialCollegeNumber.SelectedValue = "";
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
            DataTable dsLog = BLL.bllSpecialFieldInfo.GetSpecialFieldInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpSpecialFieldInfo.DataSource = dsLog;
            RpSpecialFieldInfo.DataBind();
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
        public string GetCollegeInfospecialCollegeNumber(string specialCollegeNumber)
        {
            return BLL.bllCollegeInfo.getSomeCollegeInfo(specialCollegeNumber).collegeName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Front_SpecialFieldInfo_List.aspx?specialFieldNumber=" + specialFieldNumber.Text.Trim() + "&&specialFieldName=" + specialFieldName.Text.Trim() + "&&specialCollegeNumber=" + specialCollegeNumber.SelectedValue.Trim()+ "&&specialBirthDate=" + specialBirthDate.Text.Trim());
        }
    }
}
