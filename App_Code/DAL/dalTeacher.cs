using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*教师信息业务逻辑层实现*/
    public class dalTeacher
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加教师信息实现*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            string sql = "insert into Teacher(teacherNumber,teacherName,teacherPassword,teacherSex,teacherBirthday,teacherArriveDate,teacherCardNumber,teacherPhone,teacherPhoto,teacherAddress,teacherMemo) values(@teacherNumber,@teacherName,@teacherPassword,@teacherSex,@teacherBirthday,@teacherArriveDate,@teacherCardNumber,@teacherPhone,@teacherPhoto,@teacherAddress,@teacherMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teacherNumber",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@teacherPassword",SqlDbType.VarChar),
             new SqlParameter("@teacherSex",SqlDbType.VarChar),
             new SqlParameter("@teacherBirthday",SqlDbType.DateTime),
             new SqlParameter("@teacherArriveDate",SqlDbType.DateTime),
             new SqlParameter("@teacherCardNumber",SqlDbType.VarChar),
             new SqlParameter("@teacherPhone",SqlDbType.VarChar),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@teacherAddress",SqlDbType.VarChar),
             new SqlParameter("@teacherMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = teacher.teacherNumber; //教师编号
            parm[1].Value = teacher.teacherName; //教师姓名
            parm[2].Value = teacher.teacherPassword; //登录密码
            parm[3].Value = teacher.teacherSex; //性别
            parm[4].Value = teacher.teacherBirthday; //出生日期
            parm[5].Value = teacher.teacherArriveDate; //入职日期
            parm[6].Value = teacher.teacherCardNumber; //身份证号
            parm[7].Value = teacher.teacherPhone; //联系电话
            parm[8].Value = teacher.teacherPhoto; //教师照片
            parm[9].Value = teacher.teacherAddress; //家庭地址
            parm[10].Value = teacher.teacherMemo; //附加信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据teacherNumber获取某条教师信息记录*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNumber)
        {
            /*构建查询sql*/
            string sql = "select * from Teacher where teacherNumber='" + teacherNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Teacher teacher = new ENTITY.Teacher();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                teacher.teacherNumber = DataRead["teacherNumber"].ToString();
                teacher.teacherName = DataRead["teacherName"].ToString();
                teacher.teacherPassword = DataRead["teacherPassword"].ToString();
                teacher.teacherSex = DataRead["teacherSex"].ToString();
                teacher.teacherBirthday = Convert.ToDateTime(DataRead["teacherBirthday"].ToString());
                teacher.teacherArriveDate = Convert.ToDateTime(DataRead["teacherArriveDate"].ToString());
                teacher.teacherCardNumber = DataRead["teacherCardNumber"].ToString();
                teacher.teacherPhone = DataRead["teacherPhone"].ToString();
                teacher.teacherPhoto = DataRead["teacherPhoto"].ToString();
                teacher.teacherAddress = DataRead["teacherAddress"].ToString();
                teacher.teacherMemo = DataRead["teacherMemo"].ToString();
            }
            return teacher;
        }

        /*更新教师信息实现*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            string sql = "update Teacher set teacherName=@teacherName,teacherPassword=@teacherPassword,teacherSex=@teacherSex,teacherBirthday=@teacherBirthday,teacherArriveDate=@teacherArriveDate,teacherCardNumber=@teacherCardNumber,teacherPhone=@teacherPhone,teacherPhoto=@teacherPhoto,teacherAddress=@teacherAddress,teacherMemo=@teacherMemo where teacherNumber=@teacherNumber";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@teacherPassword",SqlDbType.VarChar),
             new SqlParameter("@teacherSex",SqlDbType.VarChar),
             new SqlParameter("@teacherBirthday",SqlDbType.DateTime),
             new SqlParameter("@teacherArriveDate",SqlDbType.DateTime),
             new SqlParameter("@teacherCardNumber",SqlDbType.VarChar),
             new SqlParameter("@teacherPhone",SqlDbType.VarChar),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@teacherAddress",SqlDbType.VarChar),
             new SqlParameter("@teacherMemo",SqlDbType.VarChar),
             new SqlParameter("@teacherNumber",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = teacher.teacherName;
            parm[1].Value = teacher.teacherPassword;
            parm[2].Value = teacher.teacherSex;
            parm[3].Value = teacher.teacherBirthday;
            parm[4].Value = teacher.teacherArriveDate;
            parm[5].Value = teacher.teacherCardNumber;
            parm[6].Value = teacher.teacherPhone;
            parm[7].Value = teacher.teacherPhoto;
            parm[8].Value = teacher.teacherAddress;
            parm[9].Value = teacher.teacherMemo;
            parm[10].Value = teacher.teacherNumber;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除教师信息*/
        public static bool DelTeacher(string p)
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
            sql = "delete from Teacher where teacherNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询教师信息*/
        public static System.Data.DataTable GetTeacher(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Teacher";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "teacherNumber", strShow, strSql, strWhere, " teacherNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTeacher()
        {
            try
            {
                string strSql = "select * from Teacher";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
