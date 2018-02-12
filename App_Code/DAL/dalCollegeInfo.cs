using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学院信息业务逻辑层实现*/
    public class dalCollegeInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学院信息实现*/
        public static bool AddCollegeInfo(ENTITY.CollegeInfo collegeInfo)
        {
            string sql = "insert into CollegeInfo(collegeNumber,collegeName,collegeBirthDate,collegeMan,collegeTelephone,collegeMemo) values(@collegeNumber,@collegeName,@collegeBirthDate,@collegeMan,@collegeTelephone,@collegeMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@collegeNumber",SqlDbType.VarChar),
             new SqlParameter("@collegeName",SqlDbType.VarChar),
             new SqlParameter("@collegeBirthDate",SqlDbType.DateTime),
             new SqlParameter("@collegeMan",SqlDbType.VarChar),
             new SqlParameter("@collegeTelephone",SqlDbType.VarChar),
             new SqlParameter("@collegeMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = collegeInfo.collegeNumber; //学院编号
            parm[1].Value = collegeInfo.collegeName; //学院名称
            parm[2].Value = collegeInfo.collegeBirthDate; //成立日期
            parm[3].Value = collegeInfo.collegeMan; //院长姓名
            parm[4].Value = collegeInfo.collegeTelephone; //联系电话
            parm[5].Value = collegeInfo.collegeMemo; //附加信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据collegeNumber获取某条学院信息记录*/
        public static ENTITY.CollegeInfo getSomeCollegeInfo(string collegeNumber)
        {
            /*构建查询sql*/
            string sql = "select * from CollegeInfo where collegeNumber='" + collegeNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CollegeInfo collegeInfo = new ENTITY.CollegeInfo();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                collegeInfo.collegeNumber = DataRead["collegeNumber"].ToString();
                collegeInfo.collegeName = DataRead["collegeName"].ToString();
                collegeInfo.collegeBirthDate = Convert.ToDateTime(DataRead["collegeBirthDate"].ToString());
                collegeInfo.collegeMan = DataRead["collegeMan"].ToString();
                collegeInfo.collegeTelephone = DataRead["collegeTelephone"].ToString();
                collegeInfo.collegeMemo = DataRead["collegeMemo"].ToString();
            }
            return collegeInfo;
        }

        /*更新学院信息实现*/
        public static bool EditCollegeInfo(ENTITY.CollegeInfo collegeInfo)
        {
            string sql = "update CollegeInfo set collegeName=@collegeName,collegeBirthDate=@collegeBirthDate,collegeMan=@collegeMan,collegeTelephone=@collegeTelephone,collegeMemo=@collegeMemo where collegeNumber=@collegeNumber";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@collegeName",SqlDbType.VarChar),
             new SqlParameter("@collegeBirthDate",SqlDbType.DateTime),
             new SqlParameter("@collegeMan",SqlDbType.VarChar),
             new SqlParameter("@collegeTelephone",SqlDbType.VarChar),
             new SqlParameter("@collegeMemo",SqlDbType.VarChar),
             new SqlParameter("@collegeNumber",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = collegeInfo.collegeName;
            parm[1].Value = collegeInfo.collegeBirthDate;
            parm[2].Value = collegeInfo.collegeMan;
            parm[3].Value = collegeInfo.collegeTelephone;
            parm[4].Value = collegeInfo.collegeMemo;
            parm[5].Value = collegeInfo.collegeNumber;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学院信息*/
        public static bool DelCollegeInfo(string p)
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
            sql = "delete from CollegeInfo where collegeNumber in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学院信息*/
        public static System.Data.DataTable GetCollegeInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CollegeInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "collegeNumber", strShow, strSql, strWhere, " collegeNumber asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCollegeInfo()
        {
            try
            {
                string strSql = "select * from CollegeInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
