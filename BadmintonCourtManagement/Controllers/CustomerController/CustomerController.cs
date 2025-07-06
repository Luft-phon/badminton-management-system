using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Application.Service;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourtManagement.Controllers.CustomerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAllCustomers([FromBody] PagingRequest request)
        {
            try
            {
                var customer = await _customerService.GetAllCustomers(request.PageNumber, request.PageSize);

                if (customer == null)
                {
                    return BadRequest(ErrorResponse.NotFound());
                }
                return Ok(ApiResponse<IEnumerable<GetCustomerResponseDTO>>.Success(customer));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomerByID(int id)
        {
            try
            {
                var customerDetail = await _customerService.GetCustomerById(id);
                if (customerDetail == null)
                {
                    return BadRequest(ErrorResponse.NotFound());
                }
                return Ok(ApiResponse<GetCustomerByIdDTO>.Success(customerDetail));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequestDTO dto)
        {
            try
            {
                var updateDetail = await _customerService.UpdateCustomerById(dto);
                if (updateDetail == null)
                {
                    return BadRequest(ErrorResponse.NotFound());
                }
                return Ok(ApiResponse<UpdateCustomerRequestDTO>.Success(updateDetail));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }


    }
}
