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
    public partial class M_SpecialFieldInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
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
            ListItem li = new ListItem("=��ѡ��=", "");
            specialCollegeNumber.Items.Add(li);
            specialCollegeNumber.SelectedValue = "";
        }

        protected void BtnSpecialFieldInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_EditSpecialFieldInfo.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllSpecialFieldInfo.DelSpecialFieldInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "M_SpecialFieldInfoList.aspx");
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
        protected void RpSpecialFieldInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllSpecialFieldInfo.DelSpecialFieldInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "M_SpecialFieldInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "M_SpecialFieldInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "M_SpecialFieldInfoList.aspx");
                }
            }
        }
        public string GetCollegeInfospecialCollegeNumber(string specialCollegeNumber)
        {
            return BLL.bllCollegeInfo.getSomeCollegeInfo(specialCollegeNumber).collegeName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_SpecialFieldInfoList.aspx?specialFieldNumber=" + specialFieldNumber.Text.Trim() + "&&specialFieldName=" + specialFieldName.Text.Trim() + "&&specialCollegeNumber=" + specialCollegeNumber.SelectedValue.Trim()+ "&&specialBirthDate=" + specialBirthDate.Text.Trim());
        }
    }
}
