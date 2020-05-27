using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_tutorial11.DTOs.Requests;
using apbd_tutorial11.DTOs.Responses;
using apbd_tutorial11.Entities;
using apbd_tutorial11.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tutorial11.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService _serviceDoctor;

        public DoctorController(IDoctorService service)
        {
            _serviceDoctor = service;
        }

        [HttpGet("addDoctor")]
        public IActionResult AddDoctor(AddDoctorRequest request)
        {
            Doctor newDoctor = new Doctor();
            newDoctor.FirstName = "Jakub";
            newDoctor.LastName= "Michalski";
            newDoctor.Email = "1234@wp.pl";
            request.doctor = newDoctor;

            var response = _serviceDoctor.AddDoctor(request);
            return Ok(response.message);
        }

        [HttpGet("ShowDoctor")]
        public IActionResult ShowDoctorDetails(ShowDoctorDetailsRequest request)
        {
            request.doctorId = 1;
            var response = _serviceDoctor.ShowDoctorDetails(request);
            return Ok(response.message);
        }


        [HttpGet("UpdateDoctor")]
        public IActionResult UpdateDoctor(ModifyDoctorRequest request)
        {
            Doctor updateDoctor = new Doctor();
            updateDoctor.IdDoctor = 1;
            updateDoctor.FirstName = "Jakub";
            updateDoctor.LastName = "Michalski";
            updateDoctor.Email = "4321@wp.pl";
            request.doctor = updateDoctor;

            var response = _serviceDoctor.ModifyDoctor(request);
            return Ok(response.message);
        }

        [HttpGet("DaleteDoctor")]
        public IActionResult DaleteDoctor(DeleteDoctorRequest request)
        {
            request.IdDoctor = 1;

            var response = _serviceDoctor.DeleteDoctor(request);
            return Ok(response.message);
        }
    }
}