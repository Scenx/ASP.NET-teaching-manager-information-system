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
    public partial class M_ClassInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindSpecialFieldInfo();
                string sqlstr = " where 1=1 ";
                if (Request["classNumber"] != null && Request["classNumber"].ToString() != "")
                {
                    sqlstr += "  and classNumber like '%" + Request["classNumber"].ToString() + "%'";
                    classNumber.Text = Request["classNumber"].ToString();
                }
                if (Request["className"] != null && Request["className"].ToString() != "")
                {
                    sqlstr += "  and className like '%" + Request["className"].ToString() + "%'";
                    className.Text = Request["className"].ToString();
                }
                if (Request["classSpecialFieldNumber"] != null && Request["classSpecialFieldNumber"].ToString() != "")
                {
                    sqlstr += "  and classSpecialFieldNumber='" + Request["classSpecialFieldNumber"].ToString() + "'";
                    classSpecialFieldNumber.SelectedValue = Request["classSpecialFieldNumber"].ToString();
                }
                if (Request["classBirthDate"] != null && Request["classBirthDate"].ToString() != "")
                {
                    sqlstr += "  and classBirthDate= '" + Request["classBirthDate"].ToString() + "'";
                    classBirthDate.Text = Request["classBirthDate"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindSpecialFieldInfo()
        {
            classSpecialFieldNumber.DataSource = BLL.bllSpecialFieldInfo.getAllSpecialFieldInfo();
            classSpecialFieldNumber.DataTextField = "specialFieldName";
            classSpecialFieldNumber.DataValueField = "specialFieldNumber";
            classSpecialFieldNumber.DataBind();
            ListItem li = new ListItem("=��ѡ��=", "");
            classSpecialFieldNumber.Items.Add(li);
            classSpecialFieldNumber.SelectedValue = "";
        }

        protected void BtnClassInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_EditClassInfo.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllClassInfo.DelClassInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "M_ClassInfoList.aspx");
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
            DataTable dsLog = BLL.bllClassInfo.GetClassInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpClassInfo.DataSource = dsLog;
            RpClassInfo.DataBind();
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
        protected void RpClassInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllClassInfo.DelClassInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "M_ClassInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "M_ClassInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "M_ClassInfoList.aspx");
                }
            }
        }
        public string GetSpecialFieldInfoclassSpecialFieldNumber(string classSpecialFieldNumber)
        {
            return BLL.bllSpecialFieldInfo.getSomeSpecialFieldInfo(classSpecialFieldNumber).specialFieldName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_ClassInfoList.aspx?classNumber=" + classNumber.Text.Trim() + "&&className=" + className.Text.Trim() + "&&classSpecialFieldNumber=" + classSpecialFieldNumber.SelectedValue.Trim()+ "&&classBirthDate=" + classBirthDate.Text.Trim());
        }
    }
}
