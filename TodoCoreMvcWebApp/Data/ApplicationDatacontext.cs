using Microsoft.EntityFrameworkCore;
using Task = TodoCoreMvcWebApp.Models.Task;

namespace TodoCoreMvcWebApp.Data
{
    public class ApplicationDatacontext : DbContext
    {
        public ApplicationDatacontext(DbContextOptions<ApplicationDatacontext> options):base(options)
        {
                
        }
        public DbSet<Task> Tasks { get; set; }
    }
}
