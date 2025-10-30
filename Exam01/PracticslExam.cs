using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    internal class PracticslExam : Exam
    {

        #region Constructors
        public PracticslExam() { }

        public PracticslExam(int time, int numberofquestion)
        {
            Time_of_exam = time;
            No_of_Question = numberofquestion;
            questionlist = new Question[numberofquestion];
        }

        
        #endregion

        public override void ShowExam()
        {

            Console.WriteLine("------------------------Practical Exam------------------------");

            for(int i = 0 ; i < No_of_Question ; i++) 
            {
                questionlist[i].DisplayQuestionDetails();

                Console.Write("Enter Your answer please : ");
                string? youranswer;
                do
                {
                    youranswer = Console.ReadLine();

                } while (youranswer is null);

                Console.WriteLine($"The Answer : {questionlist[i].RightAnswer.AnswerTxt}");
            }
 
        }
            public override void CreateExam()
        {
            Console.WriteLine("Creating Practical Exam...");

            for (int i = 0; i < No_of_Question; i++)
            {                

                bool isparsed;


                Console.WriteLine("------- Please enter Question Details -------");

                string? header;
                do
                {
                    Console.Write("Enter Header of question: ");
                    header = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(header));

                string? body;
                do
                {
                    Console.Write("Enter Body of question: ");
                    body = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(body));

                int mark;
                do
                {
                    Console.Write("Enter Mark of question: ");
                    isparsed = int.TryParse(Console.ReadLine(), out mark);
                } while (!isparsed);

                    questionlist[i] = new TrueorFalseQuestion(header, body, mark);
            }
        }
    }
}
