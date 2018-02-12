using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�γ���Ϣҵ���߼���*/
    public class bllCourseInfo{
        /*��ӿγ���Ϣ*/
        public static bool AddCourseInfo(ENTITY.CourseInfo courseInfo)
        {
            return DAL.dalCourseInfo.AddCourseInfo(courseInfo);
        }

        /*����courseNumber��ȡĳ���γ���Ϣ��¼*/
        public static ENTITY.CourseInfo getSomeCourseInfo(string courseNumber)
        {
            return DAL.dalCourseInfo.getSomeCourseInfo(courseNumber);
        }

        /*���¿γ���Ϣ*/
        public static bool EditCourseInfo(ENTITY.CourseInfo courseInfo)
        {
            return DAL.dalCourseInfo.EditCourseInfo(courseInfo);
        }

        /*ɾ���γ���Ϣ*/
        public static bool DelCourseInfo(string p)
        {
            return DAL.dalCourseInfo.DelCourseInfo(p);
        }

        /*����������ҳ��ѯ�γ���Ϣ*/
        public static System.Data.DataTable GetCourseInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCourseInfo.GetCourseInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĿγ���Ϣ*/
        public static System.Data.DataSet getAllCourseInfo()
        {
            return DAL.dalCourseInfo.getAllCourseInfo();
        }
    }
}
