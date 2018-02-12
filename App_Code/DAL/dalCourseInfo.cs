using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*课程信息业务逻辑层实现*/
    public class dalCourseInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加课程信息实现*/
        public static bool AddCourseInfo(ENTITY.CourseInfo courseInfo)
        {
            string sql = "insert into CourseInfo(courseNumber,courseName,courseTeacher,courseTime,coursePlace,courseScore,courseMemo) values(@courseNumber,@courseName,@courseTeacher,@courseTime,@coursePlace,@courseScore,@courseMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseNumber",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@courseTeacher",SqlDbType.VarChar),
             new SqlParameter("@courseTime",SqlDbType.VarChar),
             new SqlParameter("@coursePlace",SqlDbType.VarChar),
             new SqlParameter("@courseScore",SqlDbType.Float),
             new SqlParameter("@courseMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = courseInfo.courseNumber; //课程编号
            parm[1].Value = courseInfo.courseName; //课程名称
            parm[2].Value = courseInfo.courseTeacher; //上课老师
            parm[3].Value = courseInfo.courseTime; //上课时间
            parm[4].Value = courseInfo.coursePlace; //上课地点
            parm[5].Value = courseInfo.courseScore; //课程学分
            parm[6].Value = courseInfo.courseMemo; //附加信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据courseNumber获取某条课程信息记录*/
        public static ENTITY.CourseInfo getSomeCourseInfo(string courseNumber)
        {
            /*构建查询sql*/
            string sql = "select * from CourseInfo where courseNumber='" + courseNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CourseInfo courseInfo = new ENTITY.CourseInfo();
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新课程信息实现*/
        public static bool EditCourseInfo(ENTITY.CourseInfo courseInfo)
        {
            string sql = "update CourseInfo set courseName=@courseName,courseTeacher=@courseTeacher,courseTime=@courseTime,coursePlace=@coursePlace,courseScore=@courseScore,courseMemo=@courseMemo where courseNumber=@courseNumber";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@courseTeacher",SqlDbType.VarChar),
             new SqlParameter("@courseTime",SqlDbType.VarChar),
             new SqlParameter("@coursePlace",SqlDbType.VarChar),
             new SqlParameter("@courseScore",SqlDbType.Float),
             new SqlParameter("@courseMemo",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = courseInfo.courseName;
            parm[1].Value = courseInfo.courseTeacher;
            parm[2].Value = courseInfo.courseTime;
            parm[3].Value = courseInfo.coursePlace;
            parm[4].Value = courseInfo.courseScore;
            parm[5].Value = courseInfo.courseMemo;
            parm[6].Value = courseInfo.courseNumber;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除课程信息*/
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


        /*查询课程信息*/
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
