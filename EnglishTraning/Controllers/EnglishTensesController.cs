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

        [HttpGet()]
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

            return model;   
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
