using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�γ���Ϣҵ���߼���ʵ��*/
    public class dalCourseInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӿγ���Ϣʵ��*/
        public static bool AddCourseInfo(ENTITY.CourseInfo courseInfo)
        {
            string sql = "insert into CourseInfo(courseNumber,courseName,courseTeacher,courseTime,coursePlace,courseScore,courseMemo) values(@courseNumber,@courseName,@courseTeacher,@courseTime,@coursePlace,@courseScore,@courseMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseNumber",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@courseTeacher",SqlDbType.VarChar),
             new SqlParameter("@courseTime",SqlDbType.VarChar),
             new SqlParameter("@coursePlace",SqlDbType.VarChar),
             new SqlParameter("@courseScore",SqlDbType.Float),
             new SqlParameter("@courseMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = courseInfo.courseNumber; //�γ̱��
            parm[1].Value = courseInfo.courseName; //�γ�����
            parm[2].Value = courseInfo.courseTeacher; //�Ͽ���ʦ
            parm[3].Value = courseInfo.courseTime; //�Ͽ�ʱ��
            parm[4].Value = courseInfo.coursePlace; //�Ͽεص�
            parm[5].Value = courseInfo.courseScore; //�γ�ѧ��
            parm[6].Value = courseInfo.courseMemo; //������Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����courseNumber��ȡĳ���γ���Ϣ��¼*/
        public static ENTITY.CourseInfo getSomeCourseInfo(string courseNumber)
        {
            /*������ѯsql*/
            string sql = "select * from CourseInfo where courseNumber='" + courseNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CourseInfo courseInfo = new ENTITY.CourseInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                courseInfo.courseNumber = DataRead["courseNumber"].ToString();
                courseInfo.courseName = DataRead["courseName"].ToString();
                courseInfo.courseTeacher = DataRead["courseTeacher"].ToString();
                courseInfo.courseTime = DataRead["courseTime"].ToString();
                courseInfo.coursePlace = DataRead["coursePlace"].ToString();
                courseInfo.courseScore = float.Parse(DataRead["courseScore"].ToString());
                courseInfo.courseMemo = DataRead["courseMemo"].ToString();
            }
            return courseInfo;
        }

        /*���¿γ���Ϣʵ��*/
        public static bool EditCourseInfo(ENTITY.CourseInfo courseInfo)
        {
            string sql = "update CourseInfo set courseName=@courseName,courseTeacher=@courseTeacher,courseTime=@courseTime,coursePlace=@coursePlace,courseScore=@courseScore,courseMemo=@courseMemo where courseNumber=@courseNumber";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@courseTeacher",SqlDbType.VarChar),
             new SqlParameter("@courseTime",SqlDbType.VarChar),
             new SqlParameter("@coursePlace",SqlDbType.VarChar),
             new SqlParameter("@courseScore",SqlDbType.Float),
             new SqlParameter("@courseMemo",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = courseInfo.courseName;
            parm[1].Value = courseInfo.courseTeacher;
            parm[2].Value = courseInfo.courseTime;
            parm[3].Value = courseInfo.coursePlace;
            parm[4].Value = courseInfo.courseScore;
            parm[5].Value = courseInfo.courseMemo;
            parm[6].Value = courseInfo.courseNumber;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���γ���Ϣ*/
        public static bool DelCourseInfo(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from CourseInfo where courseNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�γ���Ϣ*/
        public static System.Data.DataTable GetCourseInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CourseInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "courseNumber", strShow, strSql, strWhere, " courseNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCourseInfo()
        {
            try
            {
                string strSql = "select * from CourseInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
