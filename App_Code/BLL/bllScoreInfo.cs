using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*成绩信息业务逻辑层*/
    public class bllScoreInfo{
        /*添加成绩信息*/
        public static bool AddScoreInfo(ENTITY.ScoreInfo scoreInfo)
        {
            return DAL.dalScoreInfo.AddScoreInfo(scoreInfo);
        }

        /*根据scoreId获取某条成绩信息记录*/
        public static ENTITY.ScoreInfo getSomeScoreInfo(int scoreId)
        {
            return DAL.dalScoreInfo.getSomeScoreInfo(scoreId);
        }

        /*更新成绩信息*/
        public static bool EditScoreInfo(ENTITY.ScoreInfo scoreInfo)
        {
            return DAL.dalScoreInfo.EditScoreInfo(scoreInfo);
        }

        /*删除成绩信息*/
        public static bool DelScoreInfo(string p)
        {
            return DAL.dalScoreInfo.DelScoreInfo(p);
        }

        /*根据条件分页查询成绩信息*/
        public static System.Data.DataTable GetScoreInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalScoreInfo.GetScoreInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的成绩信息*/
        public static System.Data.DataSet getAllScoreInfo()
        {
            return DAL.dalScoreInfo.getAllScoreInfo();
        }
    }
}
