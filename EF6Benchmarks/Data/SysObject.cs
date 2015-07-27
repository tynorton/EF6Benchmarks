using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6Benchmarks.Data
{
    [Table("SysObjectsView", Schema = "dbo")]
    public sealed class SysObject
    {
        [Column("name")]
        public string Name { get; set; }

        [Key]
        [Column("object_id")]
        public int ObjectId { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("type_desc")]
        public string TypeDescription { get; set; }
    }
}
