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
    public partial class Front_CollegeInfo_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["collegeNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "collegeNumber")))
            {
                ENTITY.CollegeInfo collegeInfo = BLL.bllCollegeInfo.getSomeCollegeInfo(Common.GetMes.GetRequestQuery(Request, "collegeNumber"));
                collegeNumber.Text = collegeInfo.collegeNumber;
                collegeName.Text = collegeInfo.collegeName;
                collegeBirthDate.Text = collegeInfo.collegeBirthDate.ToShortDateString();
                collegeMan.Text = collegeInfo.collegeMan;
                collegeTelephone.Text = collegeInfo.collegeTelephone;
                collegeMemo.Text = collegeInfo.collegeMemo;
            }
        }
    }
}
