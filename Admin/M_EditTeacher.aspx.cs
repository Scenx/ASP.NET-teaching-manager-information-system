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
                /*进入本信息添加页显示无图的图片*/
                this.TeacherPhotoImage.ImageUrl = "FileUpload\\NoImage.jpg";
                if (Request["teacherNumber"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditTeacher.aspx?teacherNumber=" + Request["teacherNumber"] + "\"} else  {location.href=\"M_TeacherList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllTeacher.AddTeacher(teacher))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditTeacher.aspx\"} else  {location.href=\"M_TeacherList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_TeacherList.aspx");
        }
        protected void Btn_TeacherPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.TeacherPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.TeacherPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.teacherPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.TeacherPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload\\" + saveFileName;/*图片路径*/
                    this.TeacherPhotoUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                    this.TeacherPhotoImage.ImageUrl = imagePath;
                    this.teacherPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

