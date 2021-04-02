using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ConstInfo
    {
        public const string CTS_HANDLE_DONE = "done";
        public const string CTS_HANDLE_FAILED = "failed";

        public const string CORRECTTYPE_UPDATED = "已校正";
        public const string CORRECTTYPE_CORRECT = "正确";
        public const string CORRECTTYPE_SUBMIT = "已提交";
        public const string CORRECTTYPE_CS = "校正/提交";

        public const string SUBJECT_DETAIL_FIRST = "FIRST";

        public enum QuestionType : int
        {
            MainSubject = 0,
            Selection = 1,
            Judgement = 2,
            Fill = 3,
            Question = 4

        }

        public enum TestWay : int
        {
            试题学习 = 1,
            计时考试 = 2,
            正式考试 = 3,
            随机抽题 = 4,
            我的收藏 = 5,
            错题重做 = 6

        }

        public enum DisplayStyle:int
        {
            列表 = 0,
            逐个 = 1
        }
    }
}