using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧԺ��Ϣҵ���߼���*/
    public class bllCollegeInfo{
        /*���ѧԺ��Ϣ*/
        public static bool AddCollegeInfo(ENTITY.CollegeInfo collegeInfo)
        {
            return DAL.dalCollegeInfo.AddCollegeInfo(collegeInfo);
        }

        /*����collegeNumber��ȡĳ��ѧԺ��Ϣ��¼*/
        public static ENTITY.CollegeInfo getSomeCollegeInfo(string collegeNumber)
        {
            return DAL.dalCollegeInfo.getSomeCollegeInfo(collegeNumber);
        }

        /*����ѧԺ��Ϣ*/
        public static bool EditCollegeInfo(ENTITY.CollegeInfo collegeInfo)
        {
            return DAL.dalCollegeInfo.EditCollegeInfo(collegeInfo);
        }

        /*ɾ��ѧԺ��Ϣ*/
        public static bool DelCollegeInfo(string p)
        {
            return DAL.dalCollegeInfo.DelCollegeInfo(p);
        }

        /*����������ҳ��ѯѧԺ��Ϣ*/
        public static System.Data.DataTable GetCollegeInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCollegeInfo.GetCollegeInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѧԺ��Ϣ*/
        public static System.Data.DataSet getAllCollegeInfo()
        {
            return DAL.dalCollegeInfo.getAllCollegeInfo();
        }
    }
}
