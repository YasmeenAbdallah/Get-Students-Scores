using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Mvc;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
namespace Pearson_Technical_Test.Model
{
    public class Result {
        //these name annotation for mapping from col name to this obj

        [Name("Student ID")]
        public string student_id { get; set; }

        [Name("Name")]
        public string name { get; set; }

        [Name("Subject")]
        public string subject { get; set; }

        [Name("Learning Objective")]
        public string learning_objective { get; set; }

        [Name("Score")]
        public string Score  { get; set; }

        //  public IList<ScoreDetailsMV> scores { get; set; }


    }
}
