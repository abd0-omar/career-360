using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDay02_CodeFIrst.Models;

// change table name
// [Table("elmo2lef")]
public class Author
{
    // by default "id" is made primary key
    [Key]
    public int id { get; set; } // it's an identity key (auto increment)
    // specify length (by default nvarcharmax)
    [StringLength(50)]
    public string name { get; set; }
    // to allow null, simply make it nullable
    public DateTime? joinDate { get; set; }
    // in the code nullable and in the database not
    [Required]
    public string? username { get; set; }
    public string password { get; set; }
    // ignore it in the database
    // [NotMapped]
    // public int confirm_password { get; set; }
    // change column name and data type
    // [Column(name: "brefNumber", TypeName = "int")]
    public string bref { get; set; }
    
    // any list initialize it
    // add virtual for lazy loading
    public virtual List<News> news { get; set; } = new List<News>();

    public override string ToString()
    {
        return name;
    }
}