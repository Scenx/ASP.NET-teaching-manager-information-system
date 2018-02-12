using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*专业信息业务逻辑层实现*/
    public class dalSpecialFieldInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加专业信息实现*/
        public static bool AddSpecialFieldInfo(ENTITY.SpecialFieldInfo specialFieldInfo)
        {
            string sql = "insert into SpecialFieldInfo(specialFieldNumber,specialFieldName,specialCollegeNumber,specialBirthDate,specialMan,specialTelephone,specialMemo) values(@specialFieldNumber,@specialFieldName,@specialCollegeNumber,@specialBirthDate,@specialMan,@specialTelephone,@specialMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@specialFieldNumber",SqlDbType.VarChar),
             new SqlParameter("@specialFieldName",SqlDbType.VarChar),
             new SqlParameter("@specialCollegeNumber",SqlDbType.VarChar),
             new SqlParameter("@specialBirthDate",SqlDbType.DateTime),
             new SqlParameter("@specialMan",SqlDbType.VarChar),
             new SqlParameter("@specialTelephone",SqlDbType.VarChar),
             new SqlParameter("@specialMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = specialFieldInfo.specialFieldNumber; //专业编号
            parm[1].Value = specialFieldInfo.specialFieldName; //专业名称
            parm[2].Value = specialFieldInfo.specialCollegeNumber; //所在学院
            parm[3].Value = specialFieldInfo.specialBirthDate; //成立日期
            parm[4].Value = specialFieldInfo.specialMan; //联系人
            parm[5].Value = specialFieldInfo.specialTelephone; //联系电话
            parm[6].Value = specialFieldInfo.specialMemo; //附加信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据specialFieldNumber获取某条专业信息记录*/
        public static ENTITY.SpecialFieldInfo getSomeSpecialFieldInfo(string specialFieldNumber)
        {
            /*构建查询sql*/
            string sql = "select * from SpecialFieldInfo where specialFieldNumber='" + specialFieldNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.SpecialFieldInfo specialFieldInfo = new ENTITY.SpecialFieldInfo();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                specialFieldInfo.specialFieldNumber = DataRead["specialFieldNumber"].ToString();
                specialFieldInfo.specialFieldName = DataRead["specialFieldName"].ToString();
                specialFieldInfo.specialCollegeNumber = DataRead["specialCollegeNumber"].ToString();
                specialFieldInfo.specialBirthDate = Convert.ToDateTime(DataRead["specialBirthDate"].ToString());
                specialFieldInfo.specialMan = DataRead["specialMan"].ToString();
                specialFieldInfo.specialTelephone = DataRead["specialTelephone"].ToString();
                specialFieldInfo.specialMemo = DataRead["specialMemo"].ToString();
            }
            return specialFieldInfo;
        }

        /*更新专业信息实现*/
        public static bool EditSpecialFieldInfo(ENTITY.SpecialFieldInfo specialFieldInfo)
        {
            string sql = "update SpecialFieldInfo set specialFieldName=@specialFieldName,specialCollegeNumber=@specialCollegeNumber,specialBirthDate=@specialBirthDate,specialMan=@specialMan,specialTelephone=@specialTelephone,specialMemo=@specialMemo where specialFieldNumber=@specialFieldNumber";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@specialFieldName",SqlDbType.VarChar),
             new SqlParameter("@specialCollegeNumber",SqlDbType.VarChar),
             new SqlParameter("@specialBirthDate",SqlDbType.DateTime),
             new SqlParameter("@specialMan",SqlDbType.VarChar),
             new SqlParameter("@specialTelephone",SqlDbType.VarChar),
             new SqlParameter("@specialMemo",SqlDbType.VarChar),
             new SqlParameter("@specialFieldNumber",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = specialFieldInfo.specialFieldName;
            parm[1].Value = specialFieldInfo.specialCollegeNumber;
            parm[2].Value = specialFieldInfo.specialBirthDate;
            parm[3].Value = specialFieldInfo.specialMan;
            parm[4].Value = specialFieldInfo.specialTelephone;
            parm[5].Value = specialFieldInfo.specialMemo;
            parm[6].Value = specialFieldInfo.specialFieldNumber;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除专业信息*/
        public static bool DelSpecialFieldInfo(string p)
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
            sql = "delete from SpecialFieldInfo where specialFieldNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询专业信息*/
        public static System.Data.DataTable GetSpecialFieldInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from SpecialFieldInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "specialFieldNumber", strShow, strSql, strWhere, " specialFieldNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSpecialFieldInfo()
        {
            try
            {
                string strSql = "select * from SpecialFieldInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
