using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�ɼ���Ϣҵ���߼���*/
    public class bllScoreInfo{
        /*��ӳɼ���Ϣ*/
        public static bool AddScoreInfo(ENTITY.ScoreInfo scoreInfo)
        {
            return DAL.dalScoreInfo.AddScoreInfo(scoreInfo);
        }

        /*����scoreId��ȡĳ���ɼ���Ϣ��¼*/
        public static ENTITY.ScoreInfo getSomeScoreInfo(int scoreId)
        {
            return DAL.dalScoreInfo.getSomeScoreInfo(scoreId);
        }

        /*���³ɼ���Ϣ*/
        public static bool EditScoreInfo(ENTITY.ScoreInfo scoreInfo)
        {
            return DAL.dalScoreInfo.EditScoreInfo(scoreInfo);
        }

        /*ɾ���ɼ���Ϣ*/
        public static bool DelScoreInfo(string p)
        {
            return DAL.dalScoreInfo.DelScoreInfo(p);
        }

        /*����������ҳ��ѯ�ɼ���Ϣ*/
        public static System.Data.DataTable GetScoreInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalScoreInfo.GetScoreInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĳɼ���Ϣ*/
        public static System.Data.DataSet getAllScoreInfo()
        {
            return DAL.dalScoreInfo.getAllScoreInfo();
        }
    }
}
