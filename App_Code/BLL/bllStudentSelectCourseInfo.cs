using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѡ����Ϣҵ���߼���*/
    public class bllStudentSelectCourseInfo{
        /*���ѡ����Ϣ*/
        public static bool AddStudentSelectCourseInfo(ENTITY.StudentSelectCourseInfo studentSelectCourseInfo)
        {
            return DAL.dalStudentSelectCourseInfo.AddStudentSelectCourseInfo(studentSelectCourseInfo);
        }

        /*����selectId��ȡĳ��ѡ����Ϣ��¼*/
        public static ENTITY.StudentSelectCourseInfo getSomeStudentSelectCourseInfo(int selectId)
        {
            return DAL.dalStudentSelectCourseInfo.getSomeStudentSelectCourseInfo(selectId);
        }

        /*����ѡ����Ϣ*/
        public static bool EditStudentSelectCourseInfo(ENTITY.StudentSelectCourseInfo studentSelectCourseInfo)
        {
            return DAL.dalStudentSelectCourseInfo.EditStudentSelectCourseInfo(studentSelectCourseInfo);
        }

        /*ɾ��ѡ����Ϣ*/
        public static bool DelStudentSelectCourseInfo(string p)
        {
            return DAL.dalStudentSelectCourseInfo.DelStudentSelectCourseInfo(p);
        }

        /*����������ҳ��ѯѡ����Ϣ*/
        public static System.Data.DataTable GetStudentSelectCourseInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStudentSelectCourseInfo.GetStudentSelectCourseInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѡ����Ϣ*/
        public static System.Data.DataSet getAllStudentSelectCourseInfo()
        {
            return DAL.dalStudentSelectCourseInfo.getAllStudentSelectCourseInfo();
        }
    }
}
