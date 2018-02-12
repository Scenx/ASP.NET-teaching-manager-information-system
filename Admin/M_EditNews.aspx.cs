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
    public partial class M_EditNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                /*进入本信息添加页显示无图的图片*/
                this.NewsPhotoImage.ImageUrl = "FileUpload\\NoImage.jpg";
                if (Request["newsId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "newsId")))
            {
                ENTITY.News news = BLL.bllNews.getSomeNews(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "newsId")));
                newsTitle.Value = news.newsTitle;
                newsContent.Value = news.newsContent;
                newsDate.Text = news.newsDate.ToShortDateString();
                newsPhoto.Text = news.newsPhoto;
                if (news.newsPhoto != "") this.NewsPhotoImage.ImageUrl = news.newsPhoto;
            }
        }

        protected void BtnNewsSave_Click(object sender, EventArgs e)
        {
            ENTITY.News news = new ENTITY.News();
            news.newsTitle = newsTitle.Value;
            news.newsContent = newsContent.Value;
            news.newsDate = Convert.ToDateTime(newsDate.Text);
            if (newsPhoto.Text == "") newsPhoto.Text = "FileUpload\\NoImage.jpg";
            news.newsPhoto = newsPhoto.Text;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "newsId")))
            {
                news.newsId = int.Parse(Request["newsId"]);
                if (BLL.bllNews.EditNews(news))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditNews.aspx?newsId=" + Request["newsId"] + "\"} else  {location.href=\"M_NewsList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllNews.AddNews(news))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditNews.aspx\"} else  {location.href=\"M_NewsList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_NewsList.aspx");
        }
        protected void Btn_NewsPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.NewsPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.NewsPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.newsPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.NewsPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload\\" + saveFileName;/*图片路径*/
                    this.NewsPhotoUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                    this.NewsPhotoImage.ImageUrl = imagePath;
                    this.newsPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

