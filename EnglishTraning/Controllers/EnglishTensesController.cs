using EnglishTraning.Data;
using EnglishTraning.DTO;
using EnglishTraning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnglishTraning.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnglishTensesController : ControllerBase
    {
        private readonly EnglishTraningContext _context; 
        public EnglishTensesController(EnglishTraningContext context)
        {
            _context = context;
        }

        [HttpGet]
        public EnglishTenesesModel GetEnglishTenses()
        {
            EnglishTenesesModel model = new EnglishTenesesModel();  

            List<EnglishTense> englishTenses = _context.EnglishTenses.Where(x=>x.IsDeleted == false).ToList();

            foreach (var item in englishTenses)
            {
                EnglishTenesesItem EnglishTenesesItem = new EnglishTenesesItem
                {
                    Id = item.Id,
                    BulgarianSentence = item.BulgarianSentence,
                    EnglishSentence = item.EnglishSentence,
                    TensesType = item.TensesType
                };

                model.EnglishTenesesItems.Add(EnglishTenesesItem);
            }

            model.TensesDropDown = GetTensesDropDown();

            model.SentenceTypeDropDown = GetSentenceTypeDropDown();

            return model;   
        }


        [HttpGet]
        public UploadModel GetUploadData()
        {
            UploadModel model = new UploadModel();

            model.TensesDropDown = GetTensesDropDown();

            model.TensesDropDown.TensesItems = model.TensesDropDown.TensesItems.Where(x=>x.Id > 0).ToList();

            model.SentenceTypeDropDown = GetSentenceTypeDropDown();

            model.SentenceTypeDropDown.SentenceTypes = model.SentenceTypeDropDown.SentenceTypes.Where(x => x.Id > 0).ToList();

            return model;
        }

        [HttpPost]
        public EnglishTenesesResult Edit(EnglishTenesesItem item)
        {
            EnglishTenesesResult result = new EnglishTenesesResult();

            try
            {
                EnglishTense? englishTense = _context.EnglishTenses.Where(x => x.Id == item.Id).FirstOrDefault();

                if (englishTense != null)
                {
                    englishTense.EnglishSentence = item.EnglishSentence;

                    englishTense.BulgarianSentence = item.BulgarianSentence;

                    _context.SaveChanges();

                    result.SuccessMessage = "The item was changed successfully.";
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;  
        }

        [HttpPost]
        public EnglishTenesesResult Delete(EnglishTenesesItem item)
        {
            EnglishTenesesResult result = new EnglishTenesesResult();

            result.Id = item.Id;

            try
            {
                EnglishTense? englishTense = _context.EnglishTenses.Where(x => x.Id == item.Id).FirstOrDefault();

                if (englishTense != null)
                {
                    englishTense.IsDeleted = true;

                    _context.SaveChanges();

                    result.SuccessMessage = "The item was deleted successfully.";

                   
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        //[HttpPost]
        //public EnglishTenesesResult DeleteAll(EnglishTenesesItem item)
        //{
        //    EnglishTenesesResult result = new EnglishTenesesResult();

        //    try
        //    {
        //        EnglishTense? englishTense = _context.EnglishTenses.Where(x => x.Id == item.Id).FirstOrDefault();

        //        if (englishTense != null)
        //        {
        //            englishTense.IsDeleted = true;

        //            _context.SaveChanges();

        //            result.SuccessMessage = "The item was deleted successfully.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;
        //}

        public static TensesDropDown GetTensesDropDown()
        {
            TensesDropDown tensesDropDown = new TensesDropDown();

            List<DropDownItem> list = new List<DropDownItem>
            {
                new DropDownItem { Id = 0, Name = "All"},
                new DropDownItem { Id = 1, Name = "Present Simple"},
                new DropDownItem { Id = 2, Name = "Present Continuous"},
                new DropDownItem { Id = 3, Name = "Present Perfect Simple"},
                new DropDownItem { Id = 4, Name = "Past Simple"},
                new DropDownItem { Id = 5, Name = "Future Simple"},
            };

            tensesDropDown.TensesItems.AddRange(list);

            return tensesDropDown;
        }

        public static SentenceTypeDropDown GetSentenceTypeDropDown()
        {
            SentenceTypeDropDown sentenceTypeDropDown = new SentenceTypeDropDown();

            List<DropDownItem> list = new List<DropDownItem>
            {
                 new DropDownItem { Id = 0, Name = "All"},
                 new DropDownItem { Id = 1, Name = "Утвърдителни изречения (Affirmative Sentences)"},
                 new DropDownItem { Id = 2, Name = "Отрицателни изречения (Negative Sentences)"},
                 new DropDownItem { Id = 3, Name = "Въпросителни изречения (Interrogative Sentences)"},
            };

            sentenceTypeDropDown.SentenceTypes.AddRange(list);

            return sentenceTypeDropDown;
        }

        [HttpPost("{id}/{tensesType}/{sentenceType}")]
        public IActionResult UploadCsv(int id, int tensesType, int sentenceType)
         {
            UploadDataResult uploadDataResult = new UploadDataResult();

            try
            {
                List<EnglishTense> items = new List<EnglishTense>(); 

                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];

                    // Провери дали файлът не е празен
                    if (file.Length > 0)
                    {
                        using (var stream = new StreamReader(file.OpenReadStream()))
                        {
                            string line;

                            List<string[]> csvData = new List<string[]>();

                            // Чети редовете от CSV файла
                            while ((line = stream.ReadLine()) != null)
                            {
                                // Разделяне на колоните (пример: ако са разделени със запетая)
                                var columns = line.Split(',');

                                if (columns.Length == 4)
                                {
                                    // Добави редовете в списъка
                                    EnglishTense item = new EnglishTense();

                                    item.BulgarianSentence = columns[0];

                                    item.EnglishSentence = columns[1];

                                    int type = 0;
                                    int.TryParse(columns[2], out type);
                                    item.TensesType = type;

                                    int sType = 0;
                                    int.TryParse(columns[3], out sType);
                                    item.SentenceType = sType;

                                    EnglishTense? englishTense = _context.EnglishTenses.Where(x => x.BulgarianSentence.Equals(item.BulgarianSentence) && x.EnglishSentence.Equals(item.EnglishSentence)).FirstOrDefault();

                                    if (englishTense == null && item.TensesType > 0 && item.SentenceType > 0)
                                    {
                                        items.Add(item);
                                    }
                                }
                            }

                            if (items.Count > 0)
                            {
                                _context.AddRange(items);   

                                _context.SaveChanges();
                            }

                           uploadDataResult.SuccessMessage = $"{csvData.Count} rows uploaded successfully.";
                        }
                    }
                    else
                    {
                        uploadDataResult.ErrorMessage = "Uploaded file is empty.";
                    }
                }
                else
                {
                   uploadDataResult.ErrorMessage = "No file was uploaded.";
                }

                return Ok(uploadDataResult);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
