using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///News 的摘要说明：新闻信息实体
    /// </summary>

    public class News
    {
        /*记录编号*/
        private int _newsId;
        public int newsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        /*新闻标题*/
        private string _newsTitle;
        public string newsTitle
        {
            get { return _newsTitle; }
            set { _newsTitle = value; }
        }

        /*新闻内容*/
        private string _newsContent;
        public string newsContent
        {
            get { return _newsContent; }
            set { _newsContent = value; }
        }

        /*发布日期*/
        private DateTime _newsDate;
        public DateTime newsDate
        {
            get { return _newsDate; }
            set { _newsDate = value; }
        }

        /*新闻图片*/
        private string _newsPhoto;
        public string newsPhoto
        {
            get { return _newsPhoto; }
            set { _newsPhoto = value; }
        }

    }
}
