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
    public partial class M_EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindClassInfostudentClassNumber();
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.StudentPhotoImage.ImageUrl = "FileUpload\\NoImage.jpg";
                if (Request["studentNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindClassInfostudentClassNumber()
        {
            studentClassNumber.DataSource = BLL.bllClassInfo.getAllClassInfo();
            studentClassNumber.DataTextField = "className";
            studentClassNumber.DataValueField = "classNumber";
            studentClassNumber.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "studentNumber")))
            {
                ENTITY.Student student = BLL.bllStudent.getSomeStudent(Common.GetMes.GetRequestQuery(Request, "studentNumber"));
                studentNumber.Value = student.studentNumber;
                studentName.Value = student.studentName;
                studentPassword.Value = student.studentPassword;
                studentSex.Value = student.studentSex;
                studentClassNumber.SelectedValue = student.studentClassNumber;
                studentBirthday.Text = student.studentBirthday.ToShortDateString();
                studentState.Value = student.studentState;
                studentPhoto.Text = student.studentPhoto;
                if (student.studentPhoto != "") this.StudentPhotoImage.ImageUrl = student.studentPhoto;
                studentTelephone.Value = student.studentTelephone;
                studentEmail.Value = student.studentEmail;
                studentQQ.Value = student.studentQQ;
                studentAddress.Value = student.studentAddress;
                studentMemo.Value = student.studentMemo;
            }
        }

        protected void BtnStudentSave_Click(object sender, EventArgs e)
        {
            ENTITY.Student student = new ENTITY.Student();
            student.studentNumber = this.studentNumber.Value;
            student.studentName = studentName.Value;
            student.studentPassword = studentPassword.Value;
            student.studentSex = studentSex.Value;
            student.studentClassNumber = studentClassNumber.SelectedValue;
            student.studentBirthday = Convert.ToDateTime(studentBirthday.Text);
            student.studentState = studentState.Value;
            if (studentPhoto.Text == "") studentPhoto.Text = "FileUpload\\NoImage.jpg";
            student.studentPhoto = studentPhoto.Text;
            student.studentTelephone = studentTelephone.Value;
            student.studentEmail = studentEmail.Value;
            student.studentQQ = studentQQ.Value;
            student.studentAddress = studentAddress.Value;
            student.studentMemo = studentMemo.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "studentNumber")))
            {
                student.studentNumber = Request["studentNumber"];
                if (BLL.bllStudent.EditStudent(student))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditStudent.aspx?studentNumber=" + Request["studentNumber"] + "\"} else  {location.href=\"M_StudentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllStudent.AddStudent(student))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditStudent.aspx\"} else  {location.href=\"M_StudentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_StudentList.aspx");
        }
        protected void Btn_StudentPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.StudentPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.StudentPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.studentPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.StudentPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload\\" + saveFileName;/*ͼƬ·��*/
                    this.StudentPhotoUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                    this.StudentPhotoImage.ImageUrl = imagePath;
                    this.studentPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

