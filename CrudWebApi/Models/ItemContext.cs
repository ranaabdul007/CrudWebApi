using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Models
{
    public class ItemContext : DbContext
    {
      
            public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }
        /// <summary>
        /// Contructor Dependency Injection 
        /// </summary>
            public DbSet<TblItem> TblItem { get; set; }

     



    }
}
