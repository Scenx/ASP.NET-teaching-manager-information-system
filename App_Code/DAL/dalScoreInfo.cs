using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*成绩信息业务逻辑层实现*/
    public class dalScoreInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加成绩信息实现*/
        public static bool AddScoreInfo(ENTITY.ScoreInfo scoreInfo)
        {
            string sql = "insert into ScoreInfo(studentNumber,courseNumber,scoreValue,studentEvaluate) values(@studentNumber,@courseNumber,@scoreValue,@studentEvaluate)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar),
             new SqlParameter("@scoreValue",SqlDbType.Float),
             new SqlParameter("@studentEvaluate",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = scoreInfo.studentNumber; //学生对象
            parm[1].Value = scoreInfo.courseNumber; //课程对象
            parm[2].Value = scoreInfo.scoreValue; //成绩得分
            parm[3].Value = scoreInfo.studentEvaluate; //学生评价

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据scoreId获取某条成绩信息记录*/
        public static ENTITY.ScoreInfo getSomeScoreInfo(int scoreId)
        {
            /*构建查询sql*/
            string sql = "select * from ScoreInfo where scoreId=" + scoreId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ScoreInfo scoreInfo = new ENTITY.ScoreInfo();
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新成绩信息实现*/
        public static bool EditScoreInfo(ENTITY.ScoreInfo scoreInfo)
        {
            string sql = "update ScoreInfo set studentNumber=@studentNumber,courseNumber=@courseNumber,scoreValue=@scoreValue,studentEvaluate=@studentEvaluate where scoreId=@scoreId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar),
             new SqlParameter("@scoreValue",SqlDbType.Float),
             new SqlParameter("@studentEvaluate",SqlDbType.VarChar),
             new SqlParameter("@scoreId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = scoreInfo.studentNumber;
            parm[1].Value = scoreInfo.courseNumber;
            parm[2].Value = scoreInfo.scoreValue;
            parm[3].Value = scoreInfo.studentEvaluate;
            parm[4].Value = scoreInfo.scoreId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除成绩信息*/
        public static bool DelScoreInfo(string p)
        {
            string sql = "delete from ScoreInfo where scoreId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询成绩信息*/
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
