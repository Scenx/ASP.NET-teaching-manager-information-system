using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*新闻信息业务逻辑层实现*/
    public class dalNews
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加新闻信息实现*/
        public static bool AddNews(ENTITY.News news)
        {
            string sql = "insert into News(newsTitle,newsContent,newsDate,newsPhoto) values(@newsTitle,@newsContent,@newsDate,@newsPhoto)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsTitle",SqlDbType.VarChar),
             new SqlParameter("@newsContent",SqlDbType.VarChar),
             new SqlParameter("@newsDate",SqlDbType.DateTime),
             new SqlParameter("@newsPhoto",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = news.newsTitle; //新闻标题
            parm[1].Value = news.newsContent; //新闻内容
            parm[2].Value = news.newsDate; //发布日期
            parm[3].Value = news.newsPhoto; //新闻图片

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据newsId获取某条新闻信息记录*/
        public static ENTITY.News getSomeNews(int newsId)
        {
            /*构建查询sql*/
            string sql = "select * from News where newsId=" + newsId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.News news = new ENTITY.News();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                news.newsId = Convert.ToInt32(DataRead["newsId"]);
                news.newsTitle = DataRead["newsTitle"].ToString();
                news.newsContent = DataRead["newsContent"].ToString();
                news.newsDate = Convert.ToDateTime(DataRead["newsDate"].ToString());
                news.newsPhoto = DataRead["newsPhoto"].ToString();
            }
            return news;
        }

        /*更新新闻信息实现*/
        public static bool EditNews(ENTITY.News news)
        {
            string sql = "update News set newsTitle=@newsTitle,newsContent=@newsContent,newsDate=@newsDate,newsPhoto=@newsPhoto where newsId=@newsId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsTitle",SqlDbType.VarChar),
             new SqlParameter("@newsContent",SqlDbType.VarChar),
             new SqlParameter("@newsDate",SqlDbType.DateTime),
             new SqlParameter("@newsPhoto",SqlDbType.VarChar),
             new SqlParameter("@newsId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = news.newsTitle;
            parm[1].Value = news.newsContent;
            parm[2].Value = news.newsDate;
            parm[3].Value = news.newsPhoto;
            parm[4].Value = news.newsId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除新闻信息*/
        public static bool DelNews(string p)
        {
            string sql = "delete from News where newsId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询新闻信息*/
        public static System.Data.DataTable GetNews(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from News";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "newsId", strShow, strSql, strWhere, " newsId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllNews()
        {
            try
            {
                string strSql = "select * from News";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
