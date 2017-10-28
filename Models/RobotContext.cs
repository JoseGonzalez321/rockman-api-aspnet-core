using Microsoft.EntityFrameworkCore;

namespace RockManApi.Models
{
    public class RobotContext : DbContext
    {
        public DbSet<Robot> Robots { get; set; }
        public RobotContext(DbContextOptions<RobotContext> options)
            : base(options)
        {
            
        }        
    }
}