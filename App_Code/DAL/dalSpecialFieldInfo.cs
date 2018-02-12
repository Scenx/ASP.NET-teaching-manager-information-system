using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*רҵ��Ϣҵ���߼���ʵ��*/
    public class dalSpecialFieldInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���רҵ��Ϣʵ��*/
        public static bool AddSpecialFieldInfo(ENTITY.SpecialFieldInfo specialFieldInfo)
        {
            string sql = "insert into SpecialFieldInfo(specialFieldNumber,specialFieldName,specialCollegeNumber,specialBirthDate,specialMan,specialTelephone,specialMemo) values(@specialFieldNumber,@specialFieldName,@specialCollegeNumber,@specialBirthDate,@specialMan,@specialTelephone,@specialMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@specialFieldNumber",SqlDbType.VarChar),
             new SqlParameter("@specialFieldName",SqlDbType.VarChar),
             new SqlParameter("@specialCollegeNumber",SqlDbType.VarChar),
             new SqlParameter("@specialBirthDate",SqlDbType.DateTime),
             new SqlParameter("@specialMan",SqlDbType.VarChar),
             new SqlParameter("@specialTelephone",SqlDbType.VarChar),
             new SqlParameter("@specialMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = specialFieldInfo.specialFieldNumber; //רҵ���
            parm[1].Value = specialFieldInfo.specialFieldName; //רҵ����
            parm[2].Value = specialFieldInfo.specialCollegeNumber; //����ѧԺ
            parm[3].Value = specialFieldInfo.specialBirthDate; //��������
            parm[4].Value = specialFieldInfo.specialMan; //��ϵ��
            parm[5].Value = specialFieldInfo.specialTelephone; //��ϵ�绰
            parm[6].Value = specialFieldInfo.specialMemo; //������Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����specialFieldNumber��ȡĳ��רҵ��Ϣ��¼*/
        public static ENTITY.SpecialFieldInfo getSomeSpecialFieldInfo(string specialFieldNumber)
        {
            /*������ѯsql*/
            string sql = "select * from SpecialFieldInfo where specialFieldNumber='" + specialFieldNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.SpecialFieldInfo specialFieldInfo = new ENTITY.SpecialFieldInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*����רҵ��Ϣʵ��*/
        public static bool EditSpecialFieldInfo(ENTITY.SpecialFieldInfo specialFieldInfo)
        {
            string sql = "update SpecialFieldInfo set specialFieldName=@specialFieldName,specialCollegeNumber=@specialCollegeNumber,specialBirthDate=@specialBirthDate,specialMan=@specialMan,specialTelephone=@specialTelephone,specialMemo=@specialMemo where specialFieldNumber=@specialFieldNumber";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@specialFieldName",SqlDbType.VarChar),
             new SqlParameter("@specialCollegeNumber",SqlDbType.VarChar),
             new SqlParameter("@specialBirthDate",SqlDbType.DateTime),
             new SqlParameter("@specialMan",SqlDbType.VarChar),
             new SqlParameter("@specialTelephone",SqlDbType.VarChar),
             new SqlParameter("@specialMemo",SqlDbType.VarChar),
             new SqlParameter("@specialFieldNumber",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = specialFieldInfo.specialFieldName;
            parm[1].Value = specialFieldInfo.specialCollegeNumber;
            parm[2].Value = specialFieldInfo.specialBirthDate;
            parm[3].Value = specialFieldInfo.specialMan;
            parm[4].Value = specialFieldInfo.specialTelephone;
            parm[5].Value = specialFieldInfo.specialMemo;
            parm[6].Value = specialFieldInfo.specialFieldNumber;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��רҵ��Ϣ*/
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


        /*��ѯרҵ��Ϣ*/
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
