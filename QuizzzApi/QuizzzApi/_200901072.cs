using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzzApi.models
{
    public class _200901072
    {
        public int response_code { get; set; }
        public List<subObjects> result { get; set; }

        public _200901072(int response_code, List<subObjects> obj)
        {
            this.response_code = response_code;
            this.result = obj;
        }
    }
    public class subObjects
    {
       

        public string category { get; set; }

        public string type { get; set; }

        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public string[] incorrect_answers { get; set; }

        public subObjects( string category, string type, string difficulty, string question, string correct_answer, string[] incorrect_answers)
        {

           this.category = category;
            this.type = type;
            this.difficulty = difficulty;
            this.question = question;
            this.correct_answer = correct_answer;
            this.incorrect_answers = incorrect_answers;
        }

        public subObjects()
        {
            
        }
    }
}
