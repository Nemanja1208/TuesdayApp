using Microsoft.AspNetCore.Mvc;

namespace TuesdayApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollerCoarstersController : ControllerBase
    {
        // LET US HAVE A FAKE DB of RollerCoaster
        private static List<RollerCoaster> costerList = new List<RollerCoaster>
        {
            new RollerCoaster { Id = 1, Name = "Thunderbolt", Location = "Luna Park, New York", MaxSpeed = 72.0, YearOpened = 2014, Description = "A steel roller coaster with intense drops and twists." },
            new RollerCoaster { Id = 2, Name = "Steel Vengeance", Location = "Cedar Point, Ohio", MaxSpeed = 74.0, YearOpened = 2018, Description = "Hybrid coaster known for airtime and high speed." },
            new RollerCoaster { Id = 3, Name = "Kingda Ka", Location = "Six Flags Great Adventure, New Jersey", MaxSpeed = 128.0, YearOpened = 2005, Description = "Tallest roller coaster in the world with a hydraulic launch." },
            new RollerCoaster { Id = 4, Name = "Millennium Force", Location = "Cedar Point, Ohio", MaxSpeed = 93.0, YearOpened = 2000, Description = "First giga coaster and award-winning steel monster." },
            new RollerCoaster { Id = 5, Name = "Fury 325", Location = "Carowinds, North Carolina", MaxSpeed = 95.0, YearOpened = 2015, Description = "Gigantic steel coaster themed after a hornet’s fury." },
            new RollerCoaster { Id = 6, Name = "Nemesis", Location = "Alton Towers, UK", MaxSpeed = 50.0, YearOpened = 1994, Description = "Inverted coaster famous for its terrain-hugging layout." },
            new RollerCoaster { Id = 7, Name = "Expedition GeForce", Location = "Holiday Park, Germany", MaxSpeed = 75.0, YearOpened = 2001, Description = "Top-rated coaster with strong airtime moments." },
            new RollerCoaster { Id = 8, Name = "Taron", Location = "Phantasialand, Germany", MaxSpeed = 72.7, YearOpened = 2016, Description = "Multi-launch coaster with immersive theming." },
            new RollerCoaster { Id = 9, Name = "The Smiler", Location = "Alton Towers, UK", MaxSpeed = 52.8, YearOpened = 2013, Description = "Record-breaking coaster with 14 inversions." },
            new RollerCoaster { Id = 10, Name = "Leviathan", Location = "Canada's Wonderland, Ontario", MaxSpeed = 92.0, YearOpened = 2012, Description = "Massive B&M giga coaster with sweeping turns." }
        };


        [HttpGet("get-all-rollercoasters")]
        public IEnumerable<RollerCoaster> GetAllOfTheRollerCoastersFromFakeDB()
        {
            return costerList;
        }

        [HttpGet("get-rollercoaster-by-id/{id}")]
        public ActionResult<RollerCoaster> GetRollerCoasterById(int id)
        {
            Console.WriteLine($"This is the ID > {id}");

            var rollerCoasterThatWeAreTryingToFindById = costerList.FirstOrDefault(rollercoaster => rollercoaster.Id == id);

            if(rollerCoasterThatWeAreTryingToFindById == null)
            {
                return NotFound($"Rollercoaster with id {id} is not found");
            }
            return Ok(rollerCoasterThatWeAreTryingToFindById);
        }


        [HttpPost("create-a-new-rollercoaster")]
        public IActionResult CreateARollerCoaster([FromBody] RollerCoaster newRollerCoasterToCreate)
        {
            // WE want to create a rollercoaster - what we need is all of the properties, attributes that the RollerCoaster class has
            costerList.Add(newRollerCoasterToCreate);
            return Ok($"RollerCoaster with name {newRollerCoasterToCreate.Name} is created");
        }

        // UPDATE
        [HttpPatch("update-a-rollercoaster-name/{id}")]
        public IActionResult UpdateRollerCoasterName(int id, [FromBody] string rollerCoasterNameUpdated)
        {
            var rollerCoasterThatWeAreTryingToFindById = costerList.FirstOrDefault(rollercoaster => rollercoaster.Id == id);

            if (rollerCoasterThatWeAreTryingToFindById == null)
            {
                return NotFound($"Rollercoaster with id {id} is not found");
            }

            rollerCoasterThatWeAreTryingToFindById.Name = rollerCoasterNameUpdated;

            return Ok($"RollerCoaster with name {rollerCoasterThatWeAreTryingToFindById.Name} is updated");
        }

        // DELETE api/<RollerCoarstersController>/5
        [HttpDelete("delete-a-rollercoaster/{id}")]
        public IActionResult Delete(int id)
        {
            var rollerCoasterThatWeAreTryingToDeleteById = costerList.FirstOrDefault(rollercoaster => rollercoaster.Id == id);

            if (rollerCoasterThatWeAreTryingToDeleteById == null)
            {
                return NotFound($"Rollercoaster with id {id} is not found");
            }

            costerList.Remove(rollerCoasterThatWeAreTryingToDeleteById);

            return NoContent();
        }
    }
}
