using System.ComponentModel.DataAnnotations;

namespace MySpace.DomainModel
{
    public class Permisions
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }
    }
}
