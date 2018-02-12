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
    public partial class Front_Teacher_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.TeacherPhotoImage.ImageUrl = "Admin\\FileUpload\\NoImage.jpg";
                if (Request["teacherNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "teacherNumber")))
            {
                ENTITY.Teacher teacher = BLL.bllTeacher.getSomeTeacher(Common.GetMes.GetRequestQuery(Request, "teacherNumber"));
                teacherNumber.Text = teacher.teacherNumber;
                teacherName.Text = teacher.teacherName;
                teacherPassword.Text = teacher.teacherPassword;
                teacherSex.Text = teacher.teacherSex;
                teacherBirthday.Text = teacher.teacherBirthday.ToShortDateString();
                teacherArriveDate.Text = teacher.teacherArriveDate.ToShortDateString();
                teacherCardNumber.Text = teacher.teacherCardNumber;
                teacherPhone.Text = teacher.teacherPhone;
            if (teacher.teacherPhoto != "") this.TeacherPhotoImage.ImageUrl = "Admin\\" + teacher.teacherPhoto;
                teacherAddress.Text = teacher.teacherAddress;
                teacherMemo.Text = teacher.teacherMemo;
            }
        }
    }
}
