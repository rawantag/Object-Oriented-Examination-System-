using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    internal class Answer:ICloneable
    {
        #region Properties
        public int AnswerId { get; set; }
        public string? AnswerTxt { get; set; }
        #endregion

        public Answer() { }

        public Answer(int answerId, string? answerTxt)
        {
            AnswerId = answerId;
            AnswerTxt = answerTxt;
        }

        public override string ToString()
        {
            return $"Answer Id : {AnswerId} ) Answer : {AnswerTxt}";
        }

        public object Clone()
        {
            return new Answer
            {
                AnswerId = this.AnswerId,
                AnswerTxt = this.AnswerTxt
            };
        }
    }
}
