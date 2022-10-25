using Fuel_App.Models;

namespace Fuel_App.Services
{
    public interface ICustomerService
    {
        List<Customer> GetListOfCustomers();

        Customer GetCustomerById(string Id);

        Customer AddCustomerToTheQueue(Customer customer);

        void UpdateDepartureTime(string Id, Customer customer);

        void RemoveCustomerFromTheQueue(string Id);

        void ExitCustomerFromTheQueue(string Id);
    }
}
