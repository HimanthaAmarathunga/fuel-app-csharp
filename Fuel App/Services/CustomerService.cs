/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
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
        /// <returns>
        /// customer list
        /// </returns>
        public List<Customer> GetListOfCustomers()
        {
            return _customers.Find(customer => true).ToList();
        }


        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// customer details
        /// </returns>
        public Customer GetCustomerById(string Id)
        {
            return _customers.Find(customer => customer.Id == Id).FirstOrDefault();
        }


        /// <summary>
        /// Add Customer to the Queue
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Add to the queue
        /// </returns>
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
        ///  <returns>
        /// depature time update
        /// </returns>
        public void UpdateDepartureTime(string id, Customer customer)
        {
            _customers.ReplaceOne(customer => customer.Id == id, customer);
        }


        /// <summary>
        /// Remove Customer from the Queue
        /// </summary>
        /// <param name="Id"></param>
        ///  <returns>
        /// Remove from queue
        /// </returns>
        public void RemoveCustomerFromTheQueue(string Id)
        {
            _customers.DeleteOne(customer => customer.Id == Id);
        }


        /// <summary>
        /// Exit Customer from the Queue
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// Exit from queue
        /// </returns>
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
        /// <returns>
        /// Wait time</returns>
        public Customer GetWaitTime(string Id, string arrivalTime, string? departureTime)
        {
            return _customers.Find(customer => customer.Id == Id &&
            customer.ArrivalTime == arrivalTime && customer.DepartureTime == departureTime).FirstOrDefault();
        }
    }
}
