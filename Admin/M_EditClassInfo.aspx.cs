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
    public partial class M_EditClassInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindSpecialFieldInfoclassSpecialFieldNumber();
                if (Request["classNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindSpecialFieldInfoclassSpecialFieldNumber()
        {
            classSpecialFieldNumber.DataSource = BLL.bllSpecialFieldInfo.getAllSpecialFieldInfo();
            classSpecialFieldNumber.DataTextField = "specialFieldName";
            classSpecialFieldNumber.DataValueField = "specialFieldNumber";
            classSpecialFieldNumber.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "classNumber")))
            {
                ENTITY.ClassInfo classInfo = BLL.bllClassInfo.getSomeClassInfo(Common.GetMes.GetRequestQuery(Request, "classNumber"));
                classNumber.Value = classInfo.classNumber;
                className.Value = classInfo.className;
                classSpecialFieldNumber.SelectedValue = classInfo.classSpecialFieldNumber;
                classBirthDate.Text = classInfo.classBirthDate.ToShortDateString();
                classTeacherCharge.Value = classInfo.classTeacherCharge;
                classTelephone.Value = classInfo.classTelephone;
                classMemo.Value = classInfo.classMemo;
            }
        }

        protected void BtnClassInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.ClassInfo classInfo = new ENTITY.ClassInfo();
            classInfo.classNumber = this.classNumber.Value;
            classInfo.className = className.Value;
            classInfo.classSpecialFieldNumber = classSpecialFieldNumber.SelectedValue;
            classInfo.classBirthDate = Convert.ToDateTime(classBirthDate.Text);
            classInfo.classTeacherCharge = classTeacherCharge.Value;
            classInfo.classTelephone = classTelephone.Value;
            classInfo.classMemo = classMemo.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "classNumber")))
            {
                classInfo.classNumber = Request["classNumber"];
                if (BLL.bllClassInfo.EditClassInfo(classInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditClassInfo.aspx?classNumber=" + Request["classNumber"] + "\"} else  {location.href=\"M_ClassInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllClassInfo.AddClassInfo(classInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditClassInfo.aspx\"} else  {location.href=\"M_ClassInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_ClassInfoList.aspx");
        }
    }
}

