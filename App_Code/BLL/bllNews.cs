using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*������Ϣҵ���߼���*/
    public class bllNews{
        /*���������Ϣ*/
        public static bool AddNews(ENTITY.News news)
        {
            return DAL.dalNews.AddNews(news);
        }

        /*����newsId��ȡĳ��������Ϣ��¼*/
        public static ENTITY.News getSomeNews(int newsId)
        {
            return DAL.dalNews.getSomeNews(newsId);
        }

        /*����������Ϣ*/
        public static bool EditNews(ENTITY.News news)
        {
            return DAL.dalNews.EditNews(news);
        }

        /*ɾ��������Ϣ*/
        public static bool DelNews(string p)
        {
            return DAL.dalNews.DelNews(p);
        }

        /*����������ҳ��ѯ������Ϣ*/
        public static System.Data.DataTable GetNews(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNews.GetNews(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�������Ϣ*/
        public static System.Data.DataSet getAllNews()
        {
            return DAL.dalNews.getAllNews();
        }
    }
}
