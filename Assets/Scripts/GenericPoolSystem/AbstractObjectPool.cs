namespace GenericPoolSystem
{
    public abstract class AbstractObjectPool
    {
        public abstract int GetPoolCurrentSize();
        public abstract bool GetPoolIsDynamic();
    }
}