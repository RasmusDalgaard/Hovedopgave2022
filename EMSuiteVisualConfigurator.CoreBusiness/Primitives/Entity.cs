using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSuiteVisualConfigurator.CoreBusiness.Primitives
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }
        protected Entity(int id) => Id = id;

        protected Entity()
        {

        }
    }
}
