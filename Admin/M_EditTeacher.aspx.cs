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
    public partial class M_EditTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.TeacherPhotoImage.ImageUrl = "FileUpload\\NoImage.jpg";
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
                teacherNumber.Value = teacher.teacherNumber;
                teacherName.Value = teacher.teacherName;
                teacherPassword.Value = teacher.teacherPassword;
                teacherSex.Value = teacher.teacherSex;
                teacherBirthday.Text = teacher.teacherBirthday.ToShortDateString();
                teacherArriveDate.Text = teacher.teacherArriveDate.ToShortDateString();
                teacherCardNumber.Value = teacher.teacherCardNumber;
                teacherPhone.Value = teacher.teacherPhone;
                teacherPhoto.Text = teacher.teacherPhoto;
                if (teacher.teacherPhoto != "") this.TeacherPhotoImage.ImageUrl = teacher.teacherPhoto;
                teacherAddress.Value = teacher.teacherAddress;
                teacherMemo.Value = teacher.teacherMemo;
            }
        }

        protected void BtnTeacherSave_Click(object sender, EventArgs e)
        {
            ENTITY.Teacher teacher = new ENTITY.Teacher();
            teacher.teacherNumber = this.teacherNumber.Value;
            teacher.teacherName = teacherName.Value;
            teacher.teacherPassword = teacherPassword.Value;
            teacher.teacherSex = teacherSex.Value;
            teacher.teacherBirthday = Convert.ToDateTime(teacherBirthday.Text);
            teacher.teacherArriveDate = Convert.ToDateTime(teacherArriveDate.Text);
            teacher.teacherCardNumber = teacherCardNumber.Value;
            teacher.teacherPhone = teacherPhone.Value;
            if (teacherPhoto.Text == "") teacherPhoto.Text = "FileUpload\\NoImage.jpg";
            teacher.teacherPhoto = teacherPhoto.Text;
            teacher.teacherAddress = teacherAddress.Value;
            teacher.teacherMemo = teacherMemo.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "teacherNumber")))
            {
                teacher.teacherNumber = Request["teacherNumber"];
                if (BLL.bllTeacher.EditTeacher(teacher))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditTeacher.aspx?teacherNumber=" + Request["teacherNumber"] + "\"} else  {location.href=\"M_TeacherList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllTeacher.AddTeacher(teacher))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditTeacher.aspx\"} else  {location.href=\"M_TeacherList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_TeacherList.aspx");
        }
        protected void Btn_TeacherPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.TeacherPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.TeacherPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.teacherPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.TeacherPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload\\" + saveFileName;/*ͼƬ·��*/
                    this.TeacherPhotoUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                    this.TeacherPhotoImage.ImageUrl = imagePath;
                    this.teacherPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

