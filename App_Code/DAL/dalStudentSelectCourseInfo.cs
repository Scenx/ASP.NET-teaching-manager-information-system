using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѡ����Ϣҵ���߼���ʵ��*/
    public class dalStudentSelectCourseInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѡ����Ϣʵ��*/
        public static bool AddStudentSelectCourseInfo(ENTITY.StudentSelectCourseInfo studentSelectCourseInfo)
        {
            string sql = "insert into StudentSelectCourseInfo(studentNumber,courseNumber) values(@studentNumber,@courseNumber)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = studentSelectCourseInfo.studentNumber; //ѧ������
            parm[1].Value = studentSelectCourseInfo.courseNumber; //�γ̶���

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����selectId��ȡĳ��ѡ����Ϣ��¼*/
        public static ENTITY.StudentSelectCourseInfo getSomeStudentSelectCourseInfo(int selectId)
        {
            /*������ѯsql*/
            string sql = "select * from StudentSelectCourseInfo where selectId=" + selectId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.StudentSelectCourseInfo studentSelectCourseInfo = new ENTITY.StudentSelectCourseInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                studentSelectCourseInfo.selectId = Convert.ToInt32(DataRead["selectId"]);
                studentSelectCourseInfo.studentNumber = DataRead["studentNumber"].ToString();
                studentSelectCourseInfo.courseNumber = DataRead["courseNumber"].ToString();
            }
            return studentSelectCourseInfo;
        }

        /*����ѡ����Ϣʵ��*/
        public static bool EditStudentSelectCourseInfo(ENTITY.StudentSelectCourseInfo studentSelectCourseInfo)
        {
            string sql = "update StudentSelectCourseInfo set studentNumber=@studentNumber,courseNumber=@courseNumber where selectId=@selectId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@studentNumber",SqlDbType.VarChar),
             new SqlParameter("@courseNumber",SqlDbType.VarChar),
             new SqlParameter("@selectId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = studentSelectCourseInfo.studentNumber;
            parm[1].Value = studentSelectCourseInfo.courseNumber;
            parm[2].Value = studentSelectCourseInfo.selectId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѡ����Ϣ*/
        public static bool DelStudentSelectCourseInfo(string p)
        {
            string sql = "delete from StudentSelectCourseInfo where selectId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѡ����Ϣ*/
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
