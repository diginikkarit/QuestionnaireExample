using QuestionnaireLibrary;
using System;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Questionnaire questionnaire = new Questionnaire();

            Question q1 = new Question() { id = 0, question = "Onko käki lintu?", answer = true };
            Question q2 = new Question() { id = 1, question = "Onko piano soitin?", answer = false };
            Question q3 = new Question() { id = 2, question = "Haluatko vokaalin?", answer = true };
            Question q4 = new Question() { id = 3, question = "Palaako metalli?", answer = false };
            Question q5 = new Question() { id = 4, question = "Käykö keuhko?", answer = true };

            questionnaire.questions.Add(q1);
            questionnaire.questions.Add(q2);
            questionnaire.questions.Add(q3);
            questionnaire.questions.Add(q4);
            questionnaire.questions.Add(q5);

            Answer testAnswer = new Answer();
            testAnswer.name = "Julli";
            testAnswer.questionnaire = questionnaire;
            testAnswer.answers.Add(true);
            testAnswer.answers.Add(false);
            testAnswer.answers.Add(false);
            testAnswer.answers.Add(true);
            testAnswer.answers.Add(true);

            Answer testAnswer1 = new Answer();
            testAnswer1.name = "Nalle";
            testAnswer1.questionnaire = questionnaire;
            testAnswer1.answers.Add(false);
            testAnswer1.answers.Add(false);
            testAnswer1.answers.Add(true);
            testAnswer1.answers.Add(false);
            testAnswer1.answers.Add(false);

            Answer testAnswer2 = new Answer();
            testAnswer2.name = "Heppu";
            testAnswer2.questionnaire = questionnaire;
            testAnswer2.answers.Add(true);
            testAnswer2.answers.Add(true);
            testAnswer2.answers.Add(true);
            testAnswer2.answers.Add(false);
            testAnswer2.answers.Add(false);

            DataHandler dh = new DataHandler();
            dh.answers.Add(testAnswer);
            dh.answers.Add(testAnswer1);
            dh.answers.Add(testAnswer2);

            dh.PrintAnswerMatrix(dh.answers);

            bool domore = true;
            while (domore)
            {
                Console.WriteLine("Add one more person?");
                bool oneMore = dh.AskTrueOrFalse();
                Console.WriteLine(" - "+oneMore);
                if (oneMore)
                {
                    Console.Clear();
                    dh.answers.Add(dh.FillQuestionnaire(questionnaire));
                    dh.PrintAnswerMatrix(dh.answers);
                }
                else
                {
                    domore = false;
                }
            }

            Console.WriteLine("\n\nThanks for using questionnaire Pro v2.11 !");

            Console.ReadKey();
        }
    }
}
