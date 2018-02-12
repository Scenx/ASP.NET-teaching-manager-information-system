using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学生信息业务逻辑层实现*/
    public class dalStudent
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学生信息实现*/
        public static bool AddStudent(ENTITY.Student student)
        {
            string sql = "insert into Student(studentNumber,studentName,studentPassword,studentSex,studentClassNumber,studentBirthday,studentState,studentPhoto,studentTelephone,studentEmail,studentQQ,studentAddress,studentMemo) values(@studentNumber,@studentName,@studentPassword,@studentSex,@studentClassNumber,@studentBirthday,@studentState,@studentPhoto,@studentTelephone,@studentEmail,@studentQQ,@studentAddress,@studentMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@studentPassword",SqlDbType.VarChar),
             new SqlParameter("@studentSex",SqlDbType.VarChar),
             new SqlParameter("@studentClassNumber",SqlDbType.VarChar),
             new SqlParameter("@studentBirthday",SqlDbType.DateTime),
             new SqlParameter("@studentState",SqlDbType.VarChar),
             new SqlParameter("@studentPhoto",SqlDbType.VarChar),
             new SqlParameter("@studentTelephone",SqlDbType.VarChar),
             new SqlParameter("@studentEmail",SqlDbType.VarChar),
             new SqlParameter("@studentQQ",SqlDbType.VarChar),
             new SqlParameter("@studentAddress",SqlDbType.VarChar),
             new SqlParameter("@studentMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = student.studentNumber; //学号
            parm[1].Value = student.studentName; //姓名
            parm[2].Value = student.studentPassword; //登录密码
            parm[3].Value = student.studentSex; //性别
            parm[4].Value = student.studentClassNumber; //所在班级
            parm[5].Value = student.studentBirthday; //出生日期
            parm[6].Value = student.studentState; //政治面貌
            parm[7].Value = student.studentPhoto; //学生照片
            parm[8].Value = student.studentTelephone; //联系电话
            parm[9].Value = student.studentEmail; //学生邮箱
            parm[10].Value = student.studentQQ; //联系qq
            parm[11].Value = student.studentAddress; //家庭地址
            parm[12].Value = student.studentMemo; //附加信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据studentNumber获取某条学生信息记录*/
        public static ENTITY.Student getSomeStudent(string studentNumber)
        {
            /*构建查询sql*/
            string sql = "select * from Student where studentNumber='" + studentNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Student student = new ENTITY.Student();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                student.studentNumber = DataRead["studentNumber"].ToString();
                student.studentName = DataRead["studentName"].ToString();
                student.studentPassword = DataRead["studentPassword"].ToString();
                student.studentSex = DataRead["studentSex"].ToString();
                student.studentClassNumber = DataRead["studentClassNumber"].ToString();
                student.studentBirthday = Convert.ToDateTime(DataRead["studentBirthday"].ToString());
                student.studentState = DataRead["studentState"].ToString();
                student.studentPhoto = DataRead["studentPhoto"].ToString();
                student.studentTelephone = DataRead["studentTelephone"].ToString();
                student.studentEmail = DataRead["studentEmail"].ToString();
                student.studentQQ = DataRead["studentQQ"].ToString();
                student.studentAddress = DataRead["studentAddress"].ToString();
                student.studentMemo = DataRead["studentMemo"].ToString();
            }
            return student;
        }

        /*更新学生信息实现*/
        public static bool EditStudent(ENTITY.Student student)
        {
            string sql = "update Student set studentName=@studentName,studentPassword=@studentPassword,studentSex=@studentSex,studentClassNumber=@studentClassNumber,studentBirthday=@studentBirthday,studentState=@studentState,studentPhoto=@studentPhoto,studentTelephone=@studentTelephone,studentEmail=@studentEmail,studentQQ=@studentQQ,studentAddress=@studentAddress,studentMemo=@studentMemo where studentNumber=@studentNumber";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@studentPassword",SqlDbType.VarChar),
             new SqlParameter("@studentSex",SqlDbType.VarChar),
             new SqlParameter("@studentClassNumber",SqlDbType.VarChar),
             new SqlParameter("@studentBirthday",SqlDbType.DateTime),
             new SqlParameter("@studentState",SqlDbType.VarChar),
             new SqlParameter("@studentPhoto",SqlDbType.VarChar),
             new SqlParameter("@studentTelephone",SqlDbType.VarChar),
             new SqlParameter("@studentEmail",SqlDbType.VarChar),
             new SqlParameter("@studentQQ",SqlDbType.VarChar),
             new SqlParameter("@studentAddress",SqlDbType.VarChar),
             new SqlParameter("@studentMemo",SqlDbType.VarChar),
             new SqlParameter("@studentNumber",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = student.studentName;
            parm[1].Value = student.studentPassword;
            parm[2].Value = student.studentSex;
            parm[3].Value = student.studentClassNumber;
            parm[4].Value = student.studentBirthday;
            parm[5].Value = student.studentState;
            parm[6].Value = student.studentPhoto;
            parm[7].Value = student.studentTelephone;
            parm[8].Value = student.studentEmail;
            parm[9].Value = student.studentQQ;
            parm[10].Value = student.studentAddress;
            parm[11].Value = student.studentMemo;
            parm[12].Value = student.studentNumber;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学生信息*/
        public static bool DelStudent(string p)
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
            sql = "delete from Student where studentNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学生信息*/
        public static System.Data.DataTable GetStudent(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Student";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "studentNumber", strShow, strSql, strWhere, " studentNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllStudent()
        {
            try
            {
                string strSql = "select * from Student";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
