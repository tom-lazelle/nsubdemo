namespace NSubDemo.TestObjects
{
    public class CustomerRepository
    {
        private readonly IDataSource<Customer> _dataSource;

        public CustomerRepository(IDataSource<Customer> dataSource)
        {
            _dataSource = dataSource;
        }

        public Customer Get(int id)
        {
            return _dataSource.Get(id);
        }
    }
}