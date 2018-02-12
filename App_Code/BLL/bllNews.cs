using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*新闻信息业务逻辑层*/
    public class bllNews{
        /*添加新闻信息*/
        public static bool AddNews(ENTITY.News news)
        {
            return DAL.dalNews.AddNews(news);
        }

        /*根据newsId获取某条新闻信息记录*/
        public static ENTITY.News getSomeNews(int newsId)
        {
            return DAL.dalNews.getSomeNews(newsId);
        }

        /*更新新闻信息*/
        public static bool EditNews(ENTITY.News news)
        {
            return DAL.dalNews.EditNews(news);
        }

        /*删除新闻信息*/
        public static bool DelNews(string p)
        {
            return DAL.dalNews.DelNews(p);
        }

        /*根据条件分页查询新闻信息*/
        public static System.Data.DataTable GetNews(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNews.GetNews(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的新闻信息*/
        public static System.Data.DataSet getAllNews()
        {
            return DAL.dalNews.getAllNews();
        }
    }
}
