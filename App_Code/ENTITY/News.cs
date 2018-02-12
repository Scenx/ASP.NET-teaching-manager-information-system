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
    ///News ��ժҪ˵����������Ϣʵ��
    /// </summary>

    public class News
    {
        /*��¼���*/
        private int _newsId;
        public int newsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        /*���ű���*/
        private string _newsTitle;
        public string newsTitle
        {
            get { return _newsTitle; }
            set { _newsTitle = value; }
        }

        /*��������*/
        private string _newsContent;
        public string newsContent
        {
            get { return _newsContent; }
            set { _newsContent = value; }
        }

        /*��������*/
        private DateTime _newsDate;
        public DateTime newsDate
        {
            get { return _newsDate; }
            set { _newsDate = value; }
        }

        /*����ͼƬ*/
        private string _newsPhoto;
        public string newsPhoto
        {
            get { return _newsPhoto; }
            set { _newsPhoto = value; }
        }

    }
}
