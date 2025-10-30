using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Exam01
{
    internal class FinalExam : Exam
    {
        #region contructors
        public FinalExam() { }

        public FinalExam(int time, int numberofquestion)
        {
            Time_of_exam = time;
            No_of_Question = numberofquestion;
            questionlist = new Question[numberofquestion];
        }

        #endregion

        public override void ShowExam()
        {
            double fullmark = 0.0, totalGrade = 0.0;

            Console.WriteLine("------------------------Final Exam------------------------");
            Console.WriteLine($"Number of Questions: {questionlist?.Length}");

            for (int i = 0; i < questionlist.Length; i++)
            {
                if (questionlist[i] is MCQQuestion mcq)
                {
                    mcq.DisplayQuestionDetails();
                    Console.Write("Please enter your answer: ");
                    string? youranswer;
                    do
                    {
                        youranswer = Console.ReadLine();
                    } while (youranswer is null);

                    if (youranswer.Trim().Equals(mcq.RightAnswer?.AnswerTxt, StringComparison.OrdinalIgnoreCase))
                    {
                        totalGrade += mcq.Mark;
                    }

                    else
                    {
                        Console.WriteLine("Your Answer is wrong.");
                    }

                    fullmark += mcq.Mark;
                }
                else if (questionlist[i] is TrueorFalseQuestion tf)
                {
                    tf.DisplayQuestionDetails();
                    Console.Write("Please enter your answer (true/false): ");
                    string? youranswer;
                    do
                    {
                        youranswer = Console.ReadLine();
                    } while (youranswer is null);

                    if (youranswer.Trim().Equals(tf.RightAnswer?.AnswerTxt, StringComparison.OrdinalIgnoreCase))
                    {
                        totalGrade += tf.Mark;
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Your Answer is wrong.");
                    }

                    fullmark += tf.Mark;
                }
            }
            Console.WriteLine($"Grade: {totalGrade}/{fullmark}");
        }



        public override void CreateExam()
        {
            Console.WriteLine("Creating Final Exam...");

            for (int i = 0; i < No_of_Question; i++)
            {
                Console.Write($"Please enter type of question {i + 1} (1 for MCQ / 2 for True or False): ");
                int type;
                bool isparsed;
                do
                {
                    isparsed = int.TryParse(Console.ReadLine(), out type);
                } while (!isparsed || (type != 1 && type != 2));

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

                if (type == 1)
                {
                    int no_of_answers;
                    do
                    {
                        Console.Write("Enter Number of Answers for the question: ");
                        isparsed = int.TryParse(Console.ReadLine(), out no_of_answers);
                    } while (!isparsed);


                    questionlist[i] = new MCQQuestion(header, body, mark, no_of_answers);
                }
                else if (type == 2)
                {

                    questionlist[i] = new TrueorFalseQuestion(header, body, mark);
                }
            }
        }
    }
}
            