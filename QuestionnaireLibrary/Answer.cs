using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionnaireLibrary
{
    public class Answer
    {
        public string name;
        public Questionnaire questionnaire;
        public List<bool> answers = new List<bool>();

    }
}
