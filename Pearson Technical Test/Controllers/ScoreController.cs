using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Pearson_Technical_Test.Model;

namespace Pearson_Technical_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : Controller
    {

        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            var scoresList = new List<Response>();

            using (var reader = new StreamReader("E:/MyWork/scores.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    var records = csv.GetRecords<Result>().ToList();
                    scoresList= MapRes(records);

                    }
                }
            return Ok(scoresList);
            }
     

        [HttpGet("GetScores")]
        public IActionResult GetScores()
        {
            try
            {
                

                using (var reader = new StreamReader("E:/MyWork/scores.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        IDictionary<key, IList<ScoreDetails>> res = new Dictionary<key, IList<ScoreDetails>>();

                        var records = csv.GetRecords<Result>().ToList();
                        foreach (var item in records)
                        {
                            //var res =MapRes(records);
                            var key = new key();
                            key.student_id = item.student_id;
                            key.name = item.name;
                            key.subject = item.subject;
                            var details = new ScoreDetails();
                            details.score = item.Score;
                            details.learning_objective = item.learning_objective;

                            if (res.ContainsKey(key))
                            {
                                res[key].Add(details);
                            }
                            else
                            {
                                var list = new List<ScoreDetails>();
                                list.Add(details);
                                res.Add(key, list);
                            }
                        }
                        
                        foreach (var item in res)
                        {
                            var response = new Response();

                            response.subject = item.Key.subject;
                            response.name = item.Key.name;  
                            response.student_id=item.Key.student_id;
                            response.scores= item.Value;
                            scoresList.Add(response);
                        }
                    }
                }


                return Ok(scoresList);
            }
            catch (Exception)
            {

                throw;
            }


        }

        private List<Response> MapRes(IList<Result> records)
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
        //var key = new key();
        //key.student_id = item.student_id;
        //key.name = item.name;
        //key.subject = item.subject;
        //var details = new ScoreDetails();
        //details.score = item.Score;
        //details.learning_objective = item.learning_objective;

        //if (res.ContainsKey(key))
        //{
        //    res[key].Add(details);
        //}
        //else
        //{
        //    var list = new List<ScoreDetails>();
        //    list.Add(details);
        //    res.Add(key, list);
        //}

        //[HttpGet("GetScores")]
        //        public IActionResult GetScores()
        //        {
        //            try
        //            {


        //                string path = "E:/MyWork/scores.csv";
        //                FileInfo fileInfo = new FileInfo(path);




        //                    using (ExcelPackage package = new ExcelPackage(new FileInfo("E:/MyWork/scoresres.xslx")).
        //                    Workbook.Worksheets.Add("Worksheet1").Cells.LoadFromText(File.ReadAllText("E:/MyWork/scores.csv"),
        //                    new ExcelTextFormat { Delimiter = ',', TextQualifier = '"' });
        //                {
        //                    ExcelWorksheet worksheet = package.Workbook.Worksheets["scores"];


        //                    IDictionary<string, IList<ResultVM>> res = new Dictionary<string, IList<ResultVM>>();
        //                    int rows = worksheet.Dimension.Rows;
        //                    int columns = worksheet.Dimension.Columns;


        //                    for (int i = 1; i <= rows; i++)
        //                    {

        //                        var stdObj = new ResultVM();
        //                        var student_id = worksheet.Cells[i, 1].Value.ToString();
        //                        stdObj.name = worksheet.Cells[i, 2].Value.ToString();
        //                        stdObj.subject = worksheet.Cells[i, 5].Value.ToString();
        //                        stdObj.scores.Add(new ScoreDetailsMV
        //                        {
        //                            learning_objective = worksheet.Cells[i, 3].Value.ToString(),
        //                            score = worksheet.Cells[i, 4].Value.ToString()
        //                        });

        //                        if (res.ContainsKey(student_id))
        //                        {
        //                            res[student_id].Add(stdObj);
        //                        }
        //                        else
        //                        {
        //                            var list = new List<ResultVM>();
        //                            list.Add(stdObj);
        //                            res.Add(student_id, list);
        //                        }

        //                        /* Do something ...*/

        //                    }
        //                    return Ok(res);
        //                }
        //            }
        //            catch (Exception ex)
        //            {

        //                return BadRequest(ex.Message);
        //            }

        //        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
