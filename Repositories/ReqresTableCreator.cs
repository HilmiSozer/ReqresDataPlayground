using Microsoft.EntityFrameworkCore;
using ReqresDataPlayground.Models;

namespace ReqresDataPlayground.Repositories
{
    public class ReqresTableCreator : DbContext
    {


        public ReqresTableCreator(DbContextOptions options) : base(options) 
        {  }

        public DbSet<UserModel> ReqresUser { get; set; }
    }
 }

