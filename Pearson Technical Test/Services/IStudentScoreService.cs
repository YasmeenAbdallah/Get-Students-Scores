using Pearson_Technical_Test.Model;

namespace Pearson_Technical_Test.Services
{
    public interface IStudentScoreService
    {
        /// <summary>
        /// this function take the result from the csv file and convert it to the request response shape
        /// </summary>
        /// <param name="records">the students data</param>
        /// <returns></returns>
        public List<Response> MapRes(IList<Result> records);
        /// <summary>
        /// sort the first of scoring system
        /// </summary>
        /// <param name="scoreDetails"></param>
        /// <returns></returns>
       // public IList<ScoreDetails> SortAZType(IList<ScoreDetails> scoreDetails);

    }
}
