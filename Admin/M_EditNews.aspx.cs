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
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.NewsPhotoImage.ImageUrl = "FileUpload\\NoImage.jpg";
                if (Request["newsId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditNews.aspx?newsId=" + Request["newsId"] + "\"} else  {location.href=\"M_NewsList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllNews.AddNews(news))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditNews.aspx\"} else  {location.href=\"M_NewsList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_NewsList.aspx");
        }
        protected void Btn_NewsPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.NewsPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.NewsPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.newsPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.NewsPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload\\" + saveFileName;/*ͼƬ·��*/
                    this.NewsPhotoUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                    this.NewsPhotoImage.ImageUrl = imagePath;
                    this.newsPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

