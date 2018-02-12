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
                /*进入本信息添加页显示无图的图片*/
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

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditStudent.aspx?studentNumber=" + Request["studentNumber"] + "\"} else  {location.href=\"M_StudentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllStudent.AddStudent(student))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditStudent.aspx\"} else  {location.href=\"M_StudentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_StudentList.aspx");
        }
        protected void Btn_StudentPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.StudentPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.StudentPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.studentPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.StudentPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload\\" + saveFileName;/*图片路径*/
                    this.StudentPhotoUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                    this.StudentPhotoImage.ImageUrl = imagePath;
                    this.studentPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

