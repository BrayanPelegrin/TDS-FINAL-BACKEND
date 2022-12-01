namespace TecnoStore.Core.Interfaces
{
    public interface ITokenManager<T>
    {
        public Task<string> TokenGenerator(T t);

    }
}
