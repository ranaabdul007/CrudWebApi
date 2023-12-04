
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudWebApi.Models
{
    public class TblItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        
        [StringLength(100)]
        public string ItemName { get; set; }

        [StringLength(250)]
        public string ItemDescription { get; set; }

        [StringLength(20)]
        public string ItemStatus { get; set; }
       
    }
}
