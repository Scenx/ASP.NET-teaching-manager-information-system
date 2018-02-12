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
    public partial class Front_Student_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*进入本信息添加页显示无图的图片*/
                this.StudentPhotoImage.ImageUrl = "Admin\\FileUpload\\NoImage.jpg";
                if (Request["studentNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "studentNumber")))
            {
                ENTITY.Student student = BLL.bllStudent.getSomeStudent(Common.GetMes.GetRequestQuery(Request, "studentNumber"));
                studentNumber.Text = student.studentNumber;
                studentName.Text = student.studentName;
                studentPassword.Text = student.studentPassword;
                studentSex.Text = student.studentSex;
            studentClassNumber.Text = BLL.bllClassInfo.getSomeClassInfo(student.studentClassNumber).className;
                studentBirthday.Text = student.studentBirthday.ToShortDateString();
                studentState.Text = student.studentState;
            if (student.studentPhoto != "") this.StudentPhotoImage.ImageUrl = "Admin\\" + student.studentPhoto;
                studentTelephone.Text = student.studentTelephone;
                studentEmail.Text = student.studentEmail;
                studentQQ.Text = student.studentQQ;
                studentAddress.Text = student.studentAddress;
                studentMemo.Text = student.studentMemo;
            }
        }
    }
}
