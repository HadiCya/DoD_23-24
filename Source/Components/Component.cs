namespace DoD_23_24
{
    abstract public class Component
    {
        protected readonly Entity entity;

        protected Component(Entity entity)
        {
            this.entity = entity;
        }
    }
}