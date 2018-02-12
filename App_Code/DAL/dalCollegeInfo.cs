using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧԺ��Ϣҵ���߼���ʵ��*/
    public class dalCollegeInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧԺ��Ϣʵ��*/
        public static bool AddCollegeInfo(ENTITY.CollegeInfo collegeInfo)
        {
            string sql = "insert into CollegeInfo(collegeNumber,collegeName,collegeBirthDate,collegeMan,collegeTelephone,collegeMemo) values(@collegeNumber,@collegeName,@collegeBirthDate,@collegeMan,@collegeTelephone,@collegeMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@collegeNumber",SqlDbType.VarChar),
             new SqlParameter("@collegeName",SqlDbType.VarChar),
             new SqlParameter("@collegeBirthDate",SqlDbType.DateTime),
             new SqlParameter("@collegeMan",SqlDbType.VarChar),
             new SqlParameter("@collegeTelephone",SqlDbType.VarChar),
             new SqlParameter("@collegeMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = collegeInfo.collegeNumber; //ѧԺ���
            parm[1].Value = collegeInfo.collegeName; //ѧԺ����
            parm[2].Value = collegeInfo.collegeBirthDate; //��������
            parm[3].Value = collegeInfo.collegeMan; //Ժ������
            parm[4].Value = collegeInfo.collegeTelephone; //��ϵ�绰
            parm[5].Value = collegeInfo.collegeMemo; //������Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����collegeNumber��ȡĳ��ѧԺ��Ϣ��¼*/
        public static ENTITY.CollegeInfo getSomeCollegeInfo(string collegeNumber)
        {
            /*������ѯsql*/
            string sql = "select * from CollegeInfo where collegeNumber='" + collegeNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CollegeInfo collegeInfo = new ENTITY.CollegeInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*����ѧԺ��Ϣʵ��*/
        public static bool EditCollegeInfo(ENTITY.CollegeInfo collegeInfo)
        {
            string sql = "update CollegeInfo set collegeName=@collegeName,collegeBirthDate=@collegeBirthDate,collegeMan=@collegeMan,collegeTelephone=@collegeTelephone,collegeMemo=@collegeMemo where collegeNumber=@collegeNumber";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@collegeName",SqlDbType.VarChar),
             new SqlParameter("@collegeBirthDate",SqlDbType.DateTime),
             new SqlParameter("@collegeMan",SqlDbType.VarChar),
             new SqlParameter("@collegeTelephone",SqlDbType.VarChar),
             new SqlParameter("@collegeMemo",SqlDbType.VarChar),
             new SqlParameter("@collegeNumber",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = collegeInfo.collegeName;
            parm[1].Value = collegeInfo.collegeBirthDate;
            parm[2].Value = collegeInfo.collegeMan;
            parm[3].Value = collegeInfo.collegeTelephone;
            parm[4].Value = collegeInfo.collegeMemo;
            parm[5].Value = collegeInfo.collegeNumber;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧԺ��Ϣ*/
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


        /*��ѯѧԺ��Ϣ*/
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
