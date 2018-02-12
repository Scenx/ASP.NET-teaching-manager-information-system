using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�༶��Ϣҵ���߼���ʵ��*/
    public class dalClassInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӱ༶��Ϣʵ��*/
        public static bool AddClassInfo(ENTITY.ClassInfo classInfo)
        {
            string sql = "insert into ClassInfo(classNumber,className,classSpecialFieldNumber,classBirthDate,classTeacherCharge,classTelephone,classMemo) values(@classNumber,@className,@classSpecialFieldNumber,@classBirthDate,@classTeacherCharge,@classTelephone,@classMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classNumber",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@classSpecialFieldNumber",SqlDbType.VarChar),
             new SqlParameter("@classBirthDate",SqlDbType.DateTime),
             new SqlParameter("@classTeacherCharge",SqlDbType.VarChar),
             new SqlParameter("@classTelephone",SqlDbType.VarChar),
             new SqlParameter("@classMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = classInfo.classNumber; //�༶���
            parm[1].Value = classInfo.className; //�༶����
            parm[2].Value = classInfo.classSpecialFieldNumber; //����רҵ
            parm[3].Value = classInfo.classBirthDate; //��������
            parm[4].Value = classInfo.classTeacherCharge; //������
            parm[5].Value = classInfo.classTelephone; //��ϵ�绰
            parm[6].Value = classInfo.classMemo; //������Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����classNumber��ȡĳ���༶��Ϣ��¼*/
        public static ENTITY.ClassInfo getSomeClassInfo(string classNumber)
        {
            /*������ѯsql*/
            string sql = "select * from ClassInfo where classNumber='" + classNumber + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ClassInfo classInfo = new ENTITY.ClassInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���°༶��Ϣʵ��*/
        public static bool EditClassInfo(ENTITY.ClassInfo classInfo)
        {
            string sql = "update ClassInfo set className=@className,classSpecialFieldNumber=@classSpecialFieldNumber,classBirthDate=@classBirthDate,classTeacherCharge=@classTeacherCharge,classTelephone=@classTelephone,classMemo=@classMemo where classNumber=@classNumber";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@classSpecialFieldNumber",SqlDbType.VarChar),
             new SqlParameter("@classBirthDate",SqlDbType.DateTime),
             new SqlParameter("@classTeacherCharge",SqlDbType.VarChar),
             new SqlParameter("@classTelephone",SqlDbType.VarChar),
             new SqlParameter("@classMemo",SqlDbType.VarChar),
             new SqlParameter("@classNumber",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = classInfo.className;
            parm[1].Value = classInfo.classSpecialFieldNumber;
            parm[2].Value = classInfo.classBirthDate;
            parm[3].Value = classInfo.classTeacherCharge;
            parm[4].Value = classInfo.classTelephone;
            parm[5].Value = classInfo.classMemo;
            parm[6].Value = classInfo.classNumber;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���༶��Ϣ*/
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


        /*��ѯ�༶��Ϣ*/
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
