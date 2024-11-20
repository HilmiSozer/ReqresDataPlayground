
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReqresDataPlayground.Models;
using ReqresDataPlayground.Repositories;



namespace ReqresDataPlayground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReqresController : ControllerBase
    {
        private readonly ReqresTableCreator _context;
        public ReqresController(ReqresTableCreator context)
        { _context = context; }



        [HttpGet(Name ="AllUsers")]

        public async Task<ReqresAllUsersModel> GetReqresAllUsersModels()
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://reqres.in/api/users");
            string responsebody = await response.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<ReqresAllUsersModel>(responsebody);

            return output; }

       


        [HttpGet("{id}")]
        public async Task<ReqresOneUserModel> GetReqresOneUser(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://reqres.in/api/users?id={id}");
            string responsebody = await response.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<ReqresOneUserModel>(responsebody);

            return output; }

        

        [HttpPost]

        public async Task<List<UserModel>> PostReqresAllUser(UserModel user)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://reqres.in/api/users");
            string responsebody = await response.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<ReqresAllUsersModel>(responsebody);

            List<UserModel> usersToAdd = new List<UserModel>();

            foreach (var item in output.Data)
            {
                var newUser = new UserModel
                {
                    Avatar = item.Avatar,
                    LastName = item.LastName,
                    FirstName = item.FirstName,
                    Email = item.Email
                };
                usersToAdd.Add(newUser);
            }
            await _context.ReqresUser.AddRangeAsync(usersToAdd);
            await _context.SaveChangesAsync();

            return usersToAdd;
        }


        [HttpPost("{userid}")]
        public async Task<UserModel> PostReqresOneUser(int userid,UserModel user)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://reqres.in/api/users?id={userid}");
            string responsebody = await response.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<ReqresOneUserModel>(responsebody);

            user.Avatar = output.Data.Avatar;  
            user.LastName = output.Data.LastName;
            user.FirstName = output.Data.FirstName;    
            user.Email = output.Data.Email;

            await _context.ReqresUser.AddAsync(user);
            await _context.SaveChangesAsync();

            var result = new UserModel
            {
                Id = user.Id,
                Avatar = user.Avatar,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email
            };
            return result;   }


      




    }
}
