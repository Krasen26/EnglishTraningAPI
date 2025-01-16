using EnglishTraning.Data;
using EnglishTraning.DTO;
using EnglishTraning.Models;
using Microsoft.AspNetCore.Mvc;

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

            List<EnglishTense> englishTenses = _context.EnglishTenses.ToList();

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

            model.SentenceTypeDropDown = GetSentenceTypeDropDown();

            return model;
        }

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

        //// GET: api/<EnglishTensesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<EnglishTensesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<EnglishTensesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<EnglishTensesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EnglishTensesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
