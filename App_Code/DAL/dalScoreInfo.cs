using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�ɼ���Ϣҵ���߼���ʵ��*/
    public class dalScoreInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӳɼ���Ϣʵ��*/
        public static bool AddScoreInfo(ENTITY.ScoreInfo scoreInfo)
        {
            string sql = "insert into ScoreInfo(studentNumber,courseNumber,scoreValue,studentEvaluate) values(@studentNumber,@courseNumber,@scoreValue,@studentEvaluate)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar),
             new SqlParameter("@scoreValue",SqlDbType.Float),
             new SqlParameter("@studentEvaluate",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = scoreInfo.studentNumber; //ѧ������
            parm[1].Value = scoreInfo.courseNumber; //�γ̶���
            parm[2].Value = scoreInfo.scoreValue; //�ɼ��÷�
            parm[3].Value = scoreInfo.studentEvaluate; //ѧ������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����scoreId��ȡĳ���ɼ���Ϣ��¼*/
        public static ENTITY.ScoreInfo getSomeScoreInfo(int scoreId)
        {
            /*������ѯsql*/
            string sql = "select * from ScoreInfo where scoreId=" + scoreId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ScoreInfo scoreInfo = new ENTITY.ScoreInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                scoreInfo.scoreId = Convert.ToInt32(DataRead["scoreId"]);
                scoreInfo.studentNumber = DataRead["studentNumber"].ToString();
                scoreInfo.courseNumber = DataRead["courseNumber"].ToString();
                scoreInfo.scoreValue = float.Parse(DataRead["scoreValue"].ToString());
                scoreInfo.studentEvaluate = DataRead["studentEvaluate"].ToString();
            }
            return scoreInfo;
        }

        /*���³ɼ���Ϣʵ��*/
        public static bool EditScoreInfo(ENTITY.ScoreInfo scoreInfo)
        {
            string sql = "update ScoreInfo set studentNumber=@studentNumber,courseNumber=@courseNumber,scoreValue=@scoreValue,studentEvaluate=@studentEvaluate where scoreId=@scoreId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar),
             new SqlParameter("@scoreValue",SqlDbType.Float),
             new SqlParameter("@studentEvaluate",SqlDbType.VarChar),
             new SqlParameter("@scoreId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = scoreInfo.studentNumber;
            parm[1].Value = scoreInfo.courseNumber;
            parm[2].Value = scoreInfo.scoreValue;
            parm[3].Value = scoreInfo.studentEvaluate;
            parm[4].Value = scoreInfo.scoreId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���ɼ���Ϣ*/
        public static bool DelScoreInfo(string p)
        {
            string sql = "delete from ScoreInfo where scoreId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�ɼ���Ϣ*/
        public static System.Data.DataTable GetScoreInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ScoreInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "scoreId", strShow, strSql, strWhere, " scoreId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllScoreInfo()
        {
            try
            {
                string strSql = "select * from ScoreInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
