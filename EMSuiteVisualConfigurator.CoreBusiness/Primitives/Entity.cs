namespace EMSuiteVisualConfigurator.CoreBusiness.Primitives
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        protected Entity(int id) => Id = id;

        protected Entity()
        {

        }
    }
}
