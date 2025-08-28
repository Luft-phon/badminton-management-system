using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.Service;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourtManagement.Controllers.CustomerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize(Roles = "Staff, Owner")]
        [HttpGet]
        [Route("getCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customer = await _customerService.GetAllCustomers();

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

        [Authorize(Roles = "Staff, Owner")]
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

        [Authorize(Roles = "Staff, Owner, Member")]
        [HttpPut]
        [Route("update-customer")]
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

        [Authorize(Roles = "Staff, Member, Owner")]
        [HttpGet("user-detail/{email}")]
        public async Task<IActionResult> GetUserDetail([FromRoute] string email)
        {
            try
            {
                var userDetail = await _customerService.GetUserDetail(email); 
                return Ok(ApiResponse<GetUserDetailResponseDTO>.Success(userDetail));
            }
            catch (Exception ex) {
                return BadRequest(ErrorResponse.InternalError(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        
    }
}
