using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*选课信息业务逻辑层实现*/
    public class dalStudentSelectCourseInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加选课信息实现*/
        public static bool AddStudentSelectCourseInfo(ENTITY.StudentSelectCourseInfo studentSelectCourseInfo)
        {
            string sql = "insert into StudentSelectCourseInfo(studentNumber,courseNumber) values(@studentNumber,@courseNumber)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = studentSelectCourseInfo.studentNumber; //学生对象
            parm[1].Value = studentSelectCourseInfo.courseNumber; //课程对象

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据selectId获取某条选课信息记录*/
        public static ENTITY.StudentSelectCourseInfo getSomeStudentSelectCourseInfo(int selectId)
        {
            /*构建查询sql*/
            string sql = "select * from StudentSelectCourseInfo where selectId=" + selectId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.StudentSelectCourseInfo studentSelectCourseInfo = new ENTITY.StudentSelectCourseInfo();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                studentSelectCourseInfo.selectId = Convert.ToInt32(DataRead["selectId"]);
                studentSelectCourseInfo.studentNumber = DataRead["studentNumber"].ToString();
                studentSelectCourseInfo.courseNumber = DataRead["courseNumber"].ToString();
            }
            return studentSelectCourseInfo;
        }

        /*更新选课信息实现*/
        public static bool EditStudentSelectCourseInfo(ENTITY.StudentSelectCourseInfo studentSelectCourseInfo)
        {
            string sql = "update StudentSelectCourseInfo set studentNumber=@studentNumber,courseNumber=@courseNumber where selectId=@selectId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar),
             new SqlParameter("@selectId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = studentSelectCourseInfo.studentNumber;
            parm[1].Value = studentSelectCourseInfo.courseNumber;
            parm[2].Value = studentSelectCourseInfo.selectId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除选课信息*/
        public static bool DelStudentSelectCourseInfo(string p)
        {
            string sql = "delete from StudentSelectCourseInfo where selectId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询选课信息*/
        public static System.Data.DataTable GetStudentSelectCourseInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from StudentSelectCourseInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "selectId", strShow, strSql, strWhere, " selectId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllStudentSelectCourseInfo()
        {
            try
            {
                string strSql = "select * from StudentSelectCourseInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
