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
    public partial class M_EditSpecialFieldInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindCollegeInfospecialCollegeNumber();
                if (Request["specialFieldNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindCollegeInfospecialCollegeNumber()
        {
            specialCollegeNumber.DataSource = BLL.bllCollegeInfo.getAllCollegeInfo();
            specialCollegeNumber.DataTextField = "collegeName";
            specialCollegeNumber.DataValueField = "collegeNumber";
            specialCollegeNumber.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "specialFieldNumber")))
            {
                ENTITY.SpecialFieldInfo specialFieldInfo = BLL.bllSpecialFieldInfo.getSomeSpecialFieldInfo(Common.GetMes.GetRequestQuery(Request, "specialFieldNumber"));
                specialFieldNumber.Value = specialFieldInfo.specialFieldNumber;
                specialFieldName.Value = specialFieldInfo.specialFieldName;
                specialCollegeNumber.SelectedValue = specialFieldInfo.specialCollegeNumber;
                specialBirthDate.Text = specialFieldInfo.specialBirthDate.ToShortDateString();
                specialMan.Value = specialFieldInfo.specialMan;
                specialTelephone.Value = specialFieldInfo.specialTelephone;
                specialMemo.Value = specialFieldInfo.specialMemo;
            }
        }

        protected void BtnSpecialFieldInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.SpecialFieldInfo specialFieldInfo = new ENTITY.SpecialFieldInfo();
            specialFieldInfo.specialFieldNumber = this.specialFieldNumber.Value;
            specialFieldInfo.specialFieldName = specialFieldName.Value;
            specialFieldInfo.specialCollegeNumber = specialCollegeNumber.SelectedValue;
            specialFieldInfo.specialBirthDate = Convert.ToDateTime(specialBirthDate.Text);
            specialFieldInfo.specialMan = specialMan.Value;
            specialFieldInfo.specialTelephone = specialTelephone.Value;
            specialFieldInfo.specialMemo = specialMemo.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "specialFieldNumber")))
            {
                specialFieldInfo.specialFieldNumber = Request["specialFieldNumber"];
                if (BLL.bllSpecialFieldInfo.EditSpecialFieldInfo(specialFieldInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditSpecialFieldInfo.aspx?specialFieldNumber=" + Request["specialFieldNumber"] + "\"} else  {location.href=\"M_SpecialFieldInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllSpecialFieldInfo.AddSpecialFieldInfo(specialFieldInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditSpecialFieldInfo.aspx\"} else  {location.href=\"M_SpecialFieldInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_SpecialFieldInfoList.aspx");
        }
    }
}

