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
    public partial class Front_SpecialFieldInfo_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["specialFieldNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "specialFieldNumber")))
            {
                ENTITY.SpecialFieldInfo specialFieldInfo = BLL.bllSpecialFieldInfo.getSomeSpecialFieldInfo(Common.GetMes.GetRequestQuery(Request, "specialFieldNumber"));
                specialFieldNumber.Text = specialFieldInfo.specialFieldNumber;
                specialFieldName.Text = specialFieldInfo.specialFieldName;
            specialCollegeNumber.Text = BLL.bllCollegeInfo.getSomeCollegeInfo(specialFieldInfo.specialCollegeNumber).collegeName;
                specialBirthDate.Text = specialFieldInfo.specialBirthDate.ToShortDateString();
                specialMan.Text = specialFieldInfo.specialMan;
                specialTelephone.Text = specialFieldInfo.specialTelephone;
                specialMemo.Text = specialFieldInfo.specialMemo;
            }
        }
    }
}
