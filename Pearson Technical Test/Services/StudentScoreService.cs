
using Pearson_Technical_Test.Model;

namespace Pearson_Technical_Test.Services
{
    public class StudentScoreService : IStudentScoreService
    {
        
     
        public List<Response> MapRes(IList<Result> records)
        {
            var scoresList = new List<Response>();
            foreach (var item in records)
            {
                var index = scoresList.FindIndex(x => x.student_id == item.student_id);
                if (index >= 0)
                {
                  
                        scoresList[index].scores.Add(new ScoreDetails
                        {
                            learning_objective = item.learning_objective,
                            score = item.Score
                        });
                   
                    if (item.Score.Length == 1 && IsBasicLetter(item.Score[0]))
                    {
                       
                            scoresList[index].scores = SortAZType(scoresList[index].scores);
                        
                     }
                    else if (int.TryParse(item.Score, out int n))
                    {
                        scoresList[index].scores = SortNumericalType(scoresList[index].scores);
                    }
                    else
                    {
                        scoresList[index].scores = SortExcellentToPoorType(scoresList[index].scores);
                    }
                   

                }

                else
                {
                    var scoreObj = new ScoreDetails
                    {
                        learning_objective = item.learning_objective,
                        score = item.Score
                    };
                    var list = new List<ScoreDetails>();
                    list.Add(scoreObj);
                    scoresList.Add(new Response
                    {
                        student_id = item.student_id,
                        name = item.name,
                        subject = item.subject,
                        scores = list


                    });


                }

            }
            return scoresList;
        }
        private static bool IsBasicLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
        private List<ScoreDetails> SortAZType(IList<ScoreDetails> scoreDetails)
         {
            return scoreDetails.OrderBy(x => x.score).ToList();
        }
        private List<ScoreDetails> SortNumericalType(IList<ScoreDetails> scoreDetails)
        {
            
            return scoreDetails.OrderByDescending(x => int.Parse(x.score)).ToList();
        }
        private List<ScoreDetails> SortExcellentToPoorType(IList<ScoreDetails> scoreDetails)
        {
           
            Dictionary<string, int> ordering = new Dictionary<string, int>
                {
  
                    { "Excellent", 1 },
                    { "Good", 2 },
                    { "Average", 3 },
                    { "Poor", 4 },
                    { "Very Poor", 5 },
                };
              return scoreDetails.OrderBy(x => ordering[x.score]).ToList();
               

          
          
        }
       

        
    }
}

