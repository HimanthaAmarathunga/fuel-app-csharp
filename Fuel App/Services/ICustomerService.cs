/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
using Fuel_App.Models;

namespace Fuel_App.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get List of Customers
        /// </summary>
        List<Customer> GetListOfCustomers();


        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="Id"></param>
        Customer GetCustomerById(string Id);


        /// <summary>
        /// Add Customer to the Queue
        /// </summary>
        /// <param name="customer"></param>
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
        Customer GetWaitTime(string Id, string ArrivalTime, string? DepartureTime);
    }
}
