namespace NSubDemo.TestObjects
{
    public interface IDataSource<T> where T : class
    {
        T Get(int id);
    }
}