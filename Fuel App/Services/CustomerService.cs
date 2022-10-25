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

        public List<Customer> GetListOfCustomers()
        {
            return _customers.Find(customer => true).ToList();
        }

        public Customer GetCustomerById(string Id)
        {
            return _customers.Find(customer => customer.Id == Id).FirstOrDefault();
        }

        public Customer AddCustomerToTheQueue(Customer customer)
        {
            _customers.InsertOne(customer);

            return customer;
        }

        public void UpdateDepartureTime(string id, Customer customer)
        {
            _customers.ReplaceOne(customer => customer.Id == id, customer);
        }

        public void RemoveCustomerFromTheQueue(string Id)
        {
            _customers.DeleteOne(customer => customer.Id == Id);
        }

        public void ExitCustomerFromTheQueue(string Id)
        {
            _customers.DeleteOne(customer => customer.Id == Id);
        }
    }
}
