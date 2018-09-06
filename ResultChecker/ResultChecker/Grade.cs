using System;
using System.Collections.Generic;
using System.Text;

namespace ResultChecker
{
    public class Grade
    {

        Dictionary<string, string> ScoreDict = new Dictionary<string, string>
        {
            {"1", "A1" },
            {"2", "B2" },
            {"3", "B3" },
            {"4", "C4" },
            {"5", "C5" },
            {"6", "C6" },
            {"7", "D7" },
            {"8", "E8" },
            {"9", "F9" },
            {"H", "HELD" },
            {"$", "CANCELLED" },
            {"X", "ABSENT" }
        };

        Dictionary<string, string> SubjectDict = new Dictionary<string, string>
        {
            { "101" , "English Language"},
            { "102" , "Mathematics"},
            { "103" , "Biology"},
            { "104" , "Chemistry"},
            { "105" , "Physics"},
            { "106" , "Yoruba Language"},
            { "107" , "Igbo Language"},
            { "108" , "Hausa Language"},
            { "109" , "Economics"},
            { "110" , "Financial Accounting"},
            { "111" , "Commerce"},
            { "112" , "Government"},
            { "113" , "Geography"}
        };

        //public Subject Subject { get; set; }

        private string score;
        private string subject;
        public string Score {
            get {
                string scoreOut;
                ScoreDict.TryGetValue(score, out scoreOut);
                return scoreOut;
            }

            set
            {
                score = value;
            }
        }


        public string Subject
        {
            get
            {
                string subjectOut;
                SubjectDict.TryGetValue(subject, out subjectOut);
                return subjectOut;
            }

            set
            {
                score = value;
            }
        }

        public Grade(string subject, string score)
        {
            this.subject = subject;
            this.score = score;
        }


    }


   
}
