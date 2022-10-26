/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
using Fuel_App.Models;
using Fuel_App.Services;
using Microsoft.AspNetCore.Mvc;



namespace Fuel_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        /// <summary>
        /// Get List of Customers
        /// </summary>
        /// <returns>
        /// Customer List
        /// </returns>
        [HttpGet("GetListOfCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Customer>> GetListOfCustomers()
        {
            return customerService.GetListOfCustomers();
        }


        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Customer by Id
        /// </returns>
        [HttpGet("{id}/GetCustomerById")]
        public ActionResult<Customer> GetCustomerById(string id)
        {
            var customer = customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }
            string time = DateTime.Now.ToString("h:mm:ss tt");

            return Ok(new {customer, time});
        }


        /// <summary>
        /// Add a Customer to the Queue
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// New queue member 
        /// </returns>
        [HttpPost("AddCustomerToTheQueue")]
        public ActionResult<Customer> AddCustomerToTheQueue([FromBody] Customer customer)
        {
            customerService.AddCustomerToTheQueue(customer);

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }


        /// <summary>
        /// Update Departure Time
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns>
        /// Updated departure time of the customer
        /// </returns>
        [HttpPut("{id}/UpdateDepartureTime")]
        public ActionResult UpdateDepartureTime(string id, [FromBody] Customer customer)
        {
            var excistingCustomer = customerService.GetCustomerById(id);

            if (excistingCustomer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerService.UpdateDepartureTime(id, customer);

            return NoContent();
        }


        /// <summary>
        /// Remove Customer from the Queue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}/RemoveCustomerFromTheQueue")]
        public ActionResult<Customer> RemoveCustomerFromTheQueue(string id)
        {
            var customer = customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerService.RemoveCustomerFromTheQueue(customer.Id);

            return Ok($"Customer with Id = {id} deleted");
        }


        /// <summary>
        /// Exit Customer from the Queue
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Customer exits from the queue without pumping fuel
        /// </returns>
        [HttpDelete("{id}/ExitCustomerFromTheQueue")]
        public ActionResult<Customer> ExitCustomerFromTheQueue(string id)
        {
            var customer = customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerService.ExitCustomerFromTheQueue(customer.Id);

            return Ok($"Customer with Id = {id} deleted");
        }


        /// <summary>
        /// Get Wait Time
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetWaitTime")]
        public ActionResult<int> GetWaitTime()
        {
            return customerService.GetWaitTime();
        }
    }
}
