namespace TecnoStore.Core.Interfaces
{
    public interface ITokenManager<T>
    {
        public string TokenGenerator(T t);

    }
}
