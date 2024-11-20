using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReqresDataPlayground.Models;
using ReqresDataPlayground.Repositories;

namespace ReqresDataPlayground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBuserController : ControllerBase
    {
        private readonly ReqresTableCreator _context;
        public DBuserController(ReqresTableCreator context)
        { _context = context; }

        [HttpGet]

        public async Task<List<UserModel>> GetAllUserDB()
        { 
        
       var usersDB = _context.ReqresUser.ToList();
            return usersDB;
        
        }

        [HttpGet("{id}")]

        public IActionResult GetOneUser(int id)
        {
            var wantedUser = _context.ReqresUser.Where(x => x.Id.Equals(id)).SingleOrDefault();

            if (wantedUser == null){

                return NotFound(); }
            return Ok(wantedUser);

        }

        [HttpPost]
        public  IActionResult PostNewUser(UserModel model)
        {
            try {

                if (model == null) { return BadRequest(); }

               _context.ReqresUser.Add(model);
                _context.SaveChanges();
                return Ok(model);

            }
            catch (Exception ex) {
            return BadRequest(ex);
            
            }




        }
        [HttpDelete]
        public IActionResult DeleteOneUser(int id)
        {

            var wantedUser = _context.ReqresUser.Where(x => x.Id.Equals(id)).SingleOrDefault();

            if (wantedUser == null) { 
            
            return NotFound();
            
            }

            _context.ReqresUser.Remove(wantedUser);
            _context.SaveChanges();

            
           
            return Ok(wantedUser) ;



        }


    }
}
