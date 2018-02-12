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
    public partial class Front_News_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.NewsPhotoImage.ImageUrl = "Admin\\FileUpload\\NoImage.jpg";
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
                newsTitle.Text = news.newsTitle;
                newsContent.Text = news.newsContent;
                newsDate.Text = news.newsDate.ToShortDateString();
            if (news.newsPhoto != "") this.NewsPhotoImage.ImageUrl = "Admin\\" + news.newsPhoto;
            }
        }
    }
}
