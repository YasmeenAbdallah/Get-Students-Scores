using CsvHelper.Configuration.Attributes;

namespace Pearson_Technical_Test.Model
{
    public class Response
    {
        
       
        public string student_id { get; set; }

        public string name { get; set; }

        public string subject { get; set; }

        public IList<ScoreDetails> scores { get; set; }
    }
}
