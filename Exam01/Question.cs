using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    internal abstract class Question:ICloneable
    {
        #region Properties
        public string? Header { get; set; }
        public string? Body { get; set; }
        public int Mark { get; set; } 
        public Answer[]? Answerslist { get; set; }
        public Answer? RightAnswer { get; set; }

        #endregion

        public Question() { }

        public Question(string? header, string? body,int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public abstract void DisplayQuestionDetails();
        public abstract object Clone();
    }
}
