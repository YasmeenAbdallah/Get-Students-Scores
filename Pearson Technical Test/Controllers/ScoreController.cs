using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Pearson_Technical_Test.Model;
using Pearson_Technical_Test.Services;

namespace Pearson_Technical_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : Controller
    {
        private readonly IStudentScoreService _studentScoreService;
        public ScoreController(IStudentScoreService studentScoreService)
        {
            _studentScoreService = studentScoreService;
        }
    
        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            var scoresList = new List<Response>();

            using (var reader = new StreamReader("scores.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    var records = csv.GetRecords<Result>().ToList();
                    scoresList= _studentScoreService.MapRes(records);

                    }
                }
            return Ok(scoresList);
            }
     


       
    }
}
