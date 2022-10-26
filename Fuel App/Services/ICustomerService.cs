using Fuel_App.Models;

namespace Fuel_App.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get List of Customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetListOfCustomers();


        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Customer GetCustomerById(string Id);


        /// <summary>
        /// Add Customer to the Queue
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Customer AddCustomerToTheQueue(Customer customer);


        /// <summary>
        /// Update Departure Time
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="customer"></param>
        void UpdateDepartureTime(string Id, Customer customer);


        /// <summary>
        /// Remove Customer from the Queue
        /// </summary>
        /// <param name="Id"></param>
        void RemoveCustomerFromTheQueue(string Id);


        /// <summary>
        /// Exit Customer from the Queue
        /// </summary>
        /// <param name="Id"></param>
        void ExitCustomerFromTheQueue(string Id);


        /// <summary>
        /// Get Wait Time
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ArrivalTime"></param>
        /// <param name="DepartureTime"></param>
        /// <returns></returns>
        Customer GetWaitTime(string Id, string ArrivalTime, string? DepartureTime);
    }
}
