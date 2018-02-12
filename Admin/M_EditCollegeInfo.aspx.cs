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
    public partial class M_EditCollegeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["collegeNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "collegeNumber")))
            {
                ENTITY.CollegeInfo collegeInfo = BLL.bllCollegeInfo.getSomeCollegeInfo(Common.GetMes.GetRequestQuery(Request, "collegeNumber"));
                collegeNumber.Value = collegeInfo.collegeNumber;
                collegeName.Value = collegeInfo.collegeName;
                collegeBirthDate.Text = collegeInfo.collegeBirthDate.ToShortDateString();
                collegeMan.Value = collegeInfo.collegeMan;
                collegeTelephone.Value = collegeInfo.collegeTelephone;
                collegeMemo.Value = collegeInfo.collegeMemo;
            }
        }

        protected void BtnCollegeInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.CollegeInfo collegeInfo = new ENTITY.CollegeInfo();
            collegeInfo.collegeNumber = this.collegeNumber.Value;
            collegeInfo.collegeName = collegeName.Value;
            collegeInfo.collegeBirthDate = Convert.ToDateTime(collegeBirthDate.Text);
            collegeInfo.collegeMan = collegeMan.Value;
            collegeInfo.collegeTelephone = collegeTelephone.Value;
            collegeInfo.collegeMemo = collegeMemo.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "collegeNumber")))
            {
                collegeInfo.collegeNumber = Request["collegeNumber"];
                if (BLL.bllCollegeInfo.EditCollegeInfo(collegeInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCollegeInfo.aspx?collegeNumber=" + Request["collegeNumber"] + "\"} else  {location.href=\"M_CollegeInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllCollegeInfo.AddCollegeInfo(collegeInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCollegeInfo.aspx\"} else  {location.href=\"M_CollegeInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_CollegeInfoList.aspx");
        }
    }
}

