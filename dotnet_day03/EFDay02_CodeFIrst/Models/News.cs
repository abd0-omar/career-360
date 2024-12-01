using System.ComponentModel.DataAnnotations.Schema;

namespace EFDay02_CodeFIrst.Models;

public class News
{
    // to remove the default action of having identity id (auto increment)
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int id { get; set; }
    public string title { get; set; }
    public string bref { get; set; }
    public string desc { get; set; }
    public DateTime datetime { get; set; }
    
    // add virtual for lazy loading
    public virtual Author author { get; set; }
    public virtual Catalog catalog { get; set; }
    
    // not necessary but it makes it easier and improve performance
    // by default it will know that this is a foreign key because of it's name that maps the
    // class name with id -> "author+id"
    // but if you want to infer it, add [ForeignKey("wow")]
    public int AuthorId { get; set; }
    public int CatalogId { get; set; }
}