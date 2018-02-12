using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*班级信息业务逻辑层实现*/
    public class dalClassInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加班级信息实现*/
        public static bool AddClassInfo(ENTITY.ClassInfo classInfo)
        {
            string sql = "insert into ClassInfo(classNumber,className,classSpecialFieldNumber,classBirthDate,classTeacherCharge,classTelephone,classMemo) values(@classNumber,@className,@classSpecialFieldNumber,@classBirthDate,@classTeacherCharge,@classTelephone,@classMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classNumber",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@classSpecialFieldNumber",SqlDbType.VarChar),
             new SqlParameter("@classBirthDate",SqlDbType.DateTime),
             new SqlParameter("@classTeacherCharge",SqlDbType.VarChar),
             new SqlParameter("@classTelephone",SqlDbType.VarChar),
             new SqlParameter("@classMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = classInfo.classNumber; //班级编号
            parm[1].Value = classInfo.className; //班级名称
            parm[2].Value = classInfo.classSpecialFieldNumber; //所属专业
            parm[3].Value = classInfo.classBirthDate; //成立日期
            parm[4].Value = classInfo.classTeacherCharge; //班主任
            parm[5].Value = classInfo.classTelephone; //联系电话
            parm[6].Value = classInfo.classMemo; //附加信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据classNumber获取某条班级信息记录*/
        public static ENTITY.ClassInfo getSomeClassInfo(string classNumber)
        {
            /*构建查询sql*/
            string sql = "select * from ClassInfo where classNumber='" + classNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ClassInfo classInfo = new ENTITY.ClassInfo();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                classInfo.classNumber = DataRead["classNumber"].ToString();
                classInfo.className = DataRead["className"].ToString();
                classInfo.classSpecialFieldNumber = DataRead["classSpecialFieldNumber"].ToString();
                classInfo.classBirthDate = Convert.ToDateTime(DataRead["classBirthDate"].ToString());
                classInfo.classTeacherCharge = DataRead["classTeacherCharge"].ToString();
                classInfo.classTelephone = DataRead["classTelephone"].ToString();
                classInfo.classMemo = DataRead["classMemo"].ToString();
            }
            return classInfo;
        }

        /*更新班级信息实现*/
        public static bool EditClassInfo(ENTITY.ClassInfo classInfo)
        {
            string sql = "update ClassInfo set className=@className,classSpecialFieldNumber=@classSpecialFieldNumber,classBirthDate=@classBirthDate,classTeacherCharge=@classTeacherCharge,classTelephone=@classTelephone,classMemo=@classMemo where classNumber=@classNumber";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@classSpecialFieldNumber",SqlDbType.VarChar),
             new SqlParameter("@classBirthDate",SqlDbType.DateTime),
             new SqlParameter("@classTeacherCharge",SqlDbType.VarChar),
             new SqlParameter("@classTelephone",SqlDbType.VarChar),
             new SqlParameter("@classMemo",SqlDbType.VarChar),
             new SqlParameter("@classNumber",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = classInfo.className;
            parm[1].Value = classInfo.classSpecialFieldNumber;
            parm[2].Value = classInfo.classBirthDate;
            parm[3].Value = classInfo.classTeacherCharge;
            parm[4].Value = classInfo.classTelephone;
            parm[5].Value = classInfo.classMemo;
            parm[6].Value = classInfo.classNumber;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除班级信息*/
        public static bool DelClassInfo(string p)
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
            sql = "delete from ClassInfo where classNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询班级信息*/
        public static System.Data.DataTable GetClassInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ClassInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "classNumber", strShow, strSql, strWhere, " classNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllClassInfo()
        {
            try
            {
                string strSql = "select * from ClassInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
