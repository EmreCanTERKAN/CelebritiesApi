using CelebritiesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CelebritiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CelebritiesController : ControllerBase
    {
        private static readonly List<Celebrity> _celebrities = new()
        {
            new Celebrity {Id = 1 , Name = "Tarkan" , Profession = "Pop Müzik Sanatçısı"},
            new Celebrity {Id = 2 , Name = "Sıla" , Profession = "Pop Müzik Sanatçısı" },
            new Celebrity {Id = 3 , Name = "Kıvanç Tatlıtuğ" , Profession = "Dizi Oyuncusu"},
            new Celebrity {Id = 4 , Name = "Beren Saat", Profession = "Dizi Oyuncusu"}
        };
        // GET : api/celebrities
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_celebrities);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var celebrity = _celebrities.FirstOrDefault(x => x.Id == id);
            if (celebrity is null)
            {
                return NotFound();
            }
            return Ok(celebrity);
        }
        // POST : api/celebrities
        [HttpPost]
        public IActionResult Post([FromBody] Celebrity celebrity)
        {
            celebrity.Id = _celebrities.Max(x => x.Id) + 1;
            _celebrities.Add(celebrity);
            return  CreatedAtAction(nameof(Get), new {id =  celebrity.Id}, celebrity); 
        }


        // PUT api/celebrities/5
        [HttpPut]
        public IActionResult Put (int id, [FromBody]Celebrity updatedCelebrity)
        {

            var celebrity = _celebrities.FirstOrDefault (x => x.Id == id);

            if (celebrity is null)
            {
                return NotFound();
            }
            celebrity.Name = updatedCelebrity.Name;
            celebrity.Profession = updatedCelebrity.Profession;
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete (int id)
        {
            var deletedcelebrity = _celebrities.FirstOrDefault(x => x.Id == id);
            if (deletedcelebrity is null)
            {
                return NotFound();
            }
            _celebrities.Remove(deletedcelebrity);
            return NoContent();

        }


    }


}
