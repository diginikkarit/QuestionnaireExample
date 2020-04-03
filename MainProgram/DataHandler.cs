using System;
using System.Collections.Generic;
using System.Text;
using QuestionnaireLibrary;

namespace MainProgram
{
    public class DataHandler
    {
        public List<Answer> answers = new List<Answer>();
        public ConsoleColor clr_base = ConsoleColor.Green;
        public ConsoleColor clr_true = ConsoleColor.Blue;
        public ConsoleColor clr_false = ConsoleColor.Red;

        public DataHandler()
        {
            Console.ForegroundColor = clr_base;
            Console.Title = "Questionnaire Pro v2.11";
        }

        public bool AskQuestion(Question question)
        {
            Console.WriteLine("\n---------");
            Console.WriteLine(question.question);
            bool trueOrFalse = AskTrueOrFalse();
            Console.WriteLine(" - " + trueOrFalse);
            return trueOrFalse;
        }
        public Answer FillQuestionnaire(Questionnaire questionnaire)
        {
            //fill basics for new answer Class 
            Answer answer = new Answer();
            answer.questionnaire = questionnaire;
            Console.WriteLine("Give me your nick name:");
            answer.name = Console.ReadLine();

            //ask the questions
            foreach (Question question in questionnaire.questions)
            {
                bool participantsAnswer = AskQuestion(question);
                answer.answers.Add(participantsAnswer);
            }

            Console.WriteLine("\n Thanks for answering");
            Console.ReadKey();
            return answer;
        }

        public void PrintAnswerMatrix(List<Answer> answers)
        {
            Console.Clear();
            Console.Write("\t\t");
            //tulostetaan nimet yläriville.
            foreach (var answer in answers)
            {
                Console.Write("\t"+answer.name);
            }
            Console.WriteLine("\t Oikea vastaus");
            Console.WriteLine("\n");
            var questions = answers[0].questionnaire.questions;
            for (int i = 0; i < questions.Count; i++)
            {
                //tulostetaan kysymys.
                Console.Write($" {i+1}. {questions[i].question}");
                
                //Käsitellään vastaajien vastuakset.
                foreach (var answer in answers)
                {
                    SetColor(answer.answers[i]);
                    Console.Write($"\t{answer.answers[i]} ");
                }

                //oikea vastaus
                SetColor(questions[i].answer);
                Console.WriteLine("\t"+questions[i].answer);
                Console.ForegroundColor = clr_base;
                Console.WriteLine("\n");
            }
        }

        public void SetColor(bool trueOrFalse)
        {
            if (trueOrFalse)
            {
                Console.ForegroundColor = clr_true;
            }
            else
            {
                Console.ForegroundColor = clr_false;
            }
        }

        public void PrintAllAnswers()
        {
            foreach (var answer in answers)
            {
                PrintAnswer(answer);
            }
        }

        public void PrintAnswer(Answer answer)
        {
            Console.WriteLine($"Name : {answer.name}");
            var questions = answer.questionnaire.questions;
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i} {questions[i].question} Your answer: {answer.answers[i]} Right answer: {questions[i].answer}");
            }
        }
        
        public void PrintWholeQuestionnaire(Questionnaire questionnaire)
        {
            foreach (var question in questionnaire.questions)
            {
                Console.WriteLine($"Id: {question.id} Question : {question.question} \tanswer : {question.answer}");
            }
        }

        public bool AskTrueOrFalse()
        {
            Console.WriteLine("(1) true OR (2) false?");

            while (true)
            {
                 Console.WriteLine("vastaus:");
                //bool parsed = Int32.TryParse(Console.ReadLine().ToString(),out answer);
                 ConsoleKeyInfo e = Console.ReadKey();
                if (e.Key == ConsoleKey.D1)
                {
                    return true;
                }
                else if(e.Key == ConsoleKey.D2)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("\nPlease enter 1 or 2...");
                }
            }
           
        }
    }

}
