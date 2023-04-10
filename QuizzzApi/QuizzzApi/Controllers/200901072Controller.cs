using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizzzApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace QuizzzApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/value/type={type}&TotalQuestions={one}&category={two}")]

    //https://localhost:44308/api/_200901072/TotalQuestions20
    public class _200901072Controller : ControllerBase
    {
        public string readFile() // Function to read a txt file and convert to string
        {
            var fileContents = string.Empty;
            string fileName = "Questions.txt";
            using (StreamReader reader = new StreamReader(fileName))
            {
                fileContents = reader.ReadToEnd();
            }
           // Console.WriteLine(fileContents);
            return fileContents;
        }
        /*
        
        // This  was for practice


        List<_200901072> _200901072l = new List<_200901072>()
        {
             new _200901072(0,new List<subObjects>()
      {
       new subObjects("coding", "prog", "medium", "write a question?", "test", new string[] { "test1", "test1" }),
       new subObjects("coding", "prog", "medium", "write a question?", "test", new string[] { "test1", "test1" })
      })
        };*/

       List<_200901072> _200901072l = new List<_200901072>(); 

       [HttpGet]

        public dynamic Get(int one , int two)
        {
            /*
             
              This function is used to take input from url and 
              display result according to the input
             
             */



            if (one > 20 || one <= 0 )
            {
                return "{\"response_code\":404 , \"result\": \"questions out of range!\" }";
            }
            else if ( two > 64 || two < 64)
            {
                return "{\"response_code\":909 , \"result\": \"Bad Request!\" }";
            }
            else
            {
                string[] lines = readFile().Split('\n');
                string pattern = @"^\s*$";

                Regex regex = new Regex(pattern);
                
                subObjects[] obj = new subObjects[20];
               

                int j = 0;
                for (int i = 0; i < 20; i++)
                {
                    obj[i] = new subObjects();
                    while (j < lines.Length) {
                        if (regex.IsMatch(lines[j]))
                        {
                            j += 1;
                            break;
                        }
                        else {
                            obj[i].category = lines[j].Replace("\r", "");
                            j += 1;
                            obj[i].type = lines[j].Replace("\r", "");
                            j += 1;
                            obj[i].difficulty = lines[j].Replace("\r", "");
                            j += 1;
                            obj[i].question = lines[j].Replace("\r", "");
                            j += 1;
                            string[] arrhold = new string[4];
                            int t = j;
                            int k = 0;
                            while (t <= (j + 3))
                            {
                                arrhold[k] = lines[t].Replace("\r", "");
                                k++;
                                t += 1;


                            }
                            Random rnd = new Random();
                            for (int p = arrhold.Length - 1; p > 0; p--)
                            {
                                int q = rnd.Next(0, 3);
                                if (q < 4)
                                {
                                    string temp = arrhold[p];
                                    arrhold[p] = arrhold[q];
                                    arrhold[q] = temp;
                                }

                            }
                            j += 4;

                            obj[i].incorrect_answers = arrhold;

                            obj[i].correct_answer = lines[j].Replace("\r", "");
                            j += 1;



                        }


                    }


                }

                int[] idxHold = new int[one];
                Random rnder = new Random();
                List<subObjects> subObjectList = new List<subObjects>();
                //subObjectList.Add(obj[two]);
                for (int idxAllocater = 0; idxAllocater < one; idxAllocater++)
                {
                    int idxMaker = rnder.Next(0, 19);

                    if (!idxHold.Contains(idxMaker))
                    {
                        subObjectList.Add(obj[idxMaker]);


                    }
                    else {


                        idxAllocater -= 1;


                    }



                }
                _200901072 objListHolder = new _200901072(0, subObjectList);

                List<_200901072> _200901072_List = new List<_200901072>();
                _200901072_List.Add(objListHolder);
                return _200901072_List;

            }

        


        }

       




    }
}
