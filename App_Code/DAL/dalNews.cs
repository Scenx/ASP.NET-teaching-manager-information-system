using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������Ϣҵ���߼���ʵ��*/
    public class dalNews
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���������Ϣʵ��*/
        public static bool AddNews(ENTITY.News news)
        {
            string sql = "insert into News(newsTitle,newsContent,newsDate,newsPhoto) values(@newsTitle,@newsContent,@newsDate,@newsPhoto)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsTitle",SqlDbType.VarChar),
             new SqlParameter("@newsContent",SqlDbType.VarChar),
             new SqlParameter("@newsDate",SqlDbType.DateTime),
             new SqlParameter("@newsPhoto",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = news.newsTitle; //���ű���
            parm[1].Value = news.newsContent; //��������
            parm[2].Value = news.newsDate; //��������
            parm[3].Value = news.newsPhoto; //����ͼƬ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����newsId��ȡĳ��������Ϣ��¼*/
        public static ENTITY.News getSomeNews(int newsId)
        {
            /*������ѯsql*/
            string sql = "select * from News where newsId=" + newsId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.News news = new ENTITY.News();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*����������Ϣʵ��*/
        public static bool EditNews(ENTITY.News news)
        {
            string sql = "update News set newsTitle=@newsTitle,newsContent=@newsContent,newsDate=@newsDate,newsPhoto=@newsPhoto where newsId=@newsId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsTitle",SqlDbType.VarChar),
             new SqlParameter("@newsContent",SqlDbType.VarChar),
             new SqlParameter("@newsDate",SqlDbType.DateTime),
             new SqlParameter("@newsPhoto",SqlDbType.VarChar),
             new SqlParameter("@newsId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = news.newsTitle;
            parm[1].Value = news.newsContent;
            parm[2].Value = news.newsDate;
            parm[3].Value = news.newsPhoto;
            parm[4].Value = news.newsId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������Ϣ*/
        public static bool DelNews(string p)
        {
            string sql = "delete from News where newsId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������Ϣ*/
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
