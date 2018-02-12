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

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditSpecialFieldInfo.aspx?specialFieldNumber=" + Request["specialFieldNumber"] + "\"} else  {location.href=\"M_SpecialFieldInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllSpecialFieldInfo.AddSpecialFieldInfo(specialFieldInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditSpecialFieldInfo.aspx\"} else  {location.href=\"M_SpecialFieldInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_SpecialFieldInfoList.aspx");
        }
    }
}

