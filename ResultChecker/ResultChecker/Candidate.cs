using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ResultChecker
{
    public class Candidate
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ExaminationYear { get; set; }

        public string ExaminationType { get; set; }

        public string ExaminationNumber { get; set; }

        public string CandidateName { get; set; }

        public string CandidateGender { get; set; }

        public string Centre { get; set; }

        public string Result { get; set; }
        
        public string ExamDiet
        {
            get
            {
                return $"{ExaminationType} {ExaminationYear}";
            }
        }


        [Ignore]
        public List<Grade> Grades
        {
            get{

                //this.result = results;
                List<Grade> grades = new List<Grade>();
                int i = 0;
                try
                {
                    while (i < Result.Length)
                    {
                        var subject = Result.Substring(i, 3);
                        //subjects.Add(result.Substring(i, 3));

                        i += 3;

                        //grade.Add(result.Substring(i, 1));
                        var score = Result.Substring(i, 1);
                        i++;

                        grades.Add(new Grade(subject, score));

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return grades;

            }
        }

        public Candidate() { }

        public Candidate(int examinationYear, string examinationType, string examinationNo, string candidateName, string candidateGender, string centre, string result) {

            ExaminationYear = examinationYear;
            ExaminationType = examinationType;
            ExaminationNumber = examinationNo;
            CandidateName = candidateName;
            CandidateGender = candidateGender;
            Centre = centre;
            Result = result;

        }
        

        
    }
}
