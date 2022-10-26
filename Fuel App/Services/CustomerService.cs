using Fuel_App.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Fuel_App.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(IFuelStationDbSettings fuelStationDbSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(fuelStationDbSettings.DatabaseName);
            _customers = database.GetCollection<Customer>(fuelStationDbSettings.CustomerDataCollectionName);
        }


        /// <summary>
        /// Get List of Customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetListOfCustomers()
        {
            return _customers.Find(customer => true).ToList();
        }


        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string Id)
        {
            return _customers.Find(customer => customer.Id == Id).FirstOrDefault();
        }


        /// <summary>
        /// Add Customer to the Queue
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer AddCustomerToTheQueue(Customer customer)
        {
            _customers.InsertOne(customer);

            return customer;
        }


        /// <summary>
        /// Update Departure Time
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        public void UpdateDepartureTime(string id, Customer customer)
        {
            _customers.ReplaceOne(customer => customer.Id == id, customer);
        }


        /// <summary>
        /// Remove Customer from the Queue
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveCustomerFromTheQueue(string Id)
        {
            _customers.DeleteOne(customer => customer.Id == Id);
        }


        /// <summary>
        /// Exit Customer from the Queue
        /// </summary>
        /// <param name="Id"></param>
        public void ExitCustomerFromTheQueue(string Id)
        {
            _customers.DeleteOne(customer => customer.Id == Id);
        }


        /// <summary>
        /// Get Wait Time
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="arrivalTime"></param>
        /// <param name="departureTime"></param>
        /// <returns></returns>
        public Customer GetWaitTime(string Id, string arrivalTime, string? departureTime)
        {
            return _customers.Find(customer => customer.Id == Id &&
            customer.ArrivalTime == arrivalTime && customer.DepartureTime == departureTime).FirstOrDefault();
        }
    }
}
