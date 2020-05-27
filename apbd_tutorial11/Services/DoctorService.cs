using apbd_tutorial11.DTOs.Requests;
using apbd_tutorial11.DTOs.Responses;
using apbd_tutorial11.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_tutorial11.Services
{
    public class DoctorService : ControllerBase, IDoctorService
    {
        public AddDoctorResponse AddDoctor(AddDoctorRequest request)
        {
            var response = new AddDoctorResponse();

            using (var doctorContext = new DoctorDbContext())
            {
                doctorContext.Doctors.Add(request.doctor);
                try
                {
                    doctorContext.SaveChanges();
                    response.message = "INSERT SUCCESSFUL";
                }
                catch (Exception)
                {
                    response.message = "INSERT FAILED";
                }
            }
            return response;
        }

        public DeleteDoctorResponse DeleteDoctor(DeleteDoctorRequest request)
        {
            var response = new DeleteDoctorResponse();

            using (var doctorDbContext = new DoctorDbContext())
            {
                var doctorToDelete = doctorDbContext.Doctors.SingleOrDefault(doctor => doctor.IdDoctor.Equals(request.IdDoctor));
                if (doctorToDelete != null)
                {
                    try
                    {
                        doctorDbContext.Doctors.Remove(doctorToDelete);
                        doctorDbContext.SaveChanges();
                        response.message = "Doctor " + request.IdDoctor + " deleted successful";
                    }
                    catch (Exception)
                    {
                        response.message = "Doctor delete FAILED";
                    }
                }
                else
                {
                    response.message = "There is no such a doctor to delete!";
                }
            }
            return response;
        }

        public ModifyDoctorResponse ModifyDoctor(ModifyDoctorRequest request)
        {
            var response = new ModifyDoctorResponse();

            using (var doctorDbContext = new DoctorDbContext())
            {
                var entity = doctorDbContext.Doctors.FirstOrDefault(item => item.IdDoctor == request.doctor.IdDoctor);
                if (entity != null)
                {
                    entity.FirstName = request.doctor.FirstName;
                    entity.LastName = request.doctor.LastName;
                    entity.Email = request.doctor.Email;

                    try
                    {
                        doctorDbContext.SaveChanges();
                        response.message = "UPDATE SUCCESSFULL";
                    }
                    catch (Exception)
                    {
                        response.message = "UPDATE FAILED";
                    }
                }
                else
                {
                    response.message = "There is no doctor with this index!";
                }
            }
            return response;
        }

        public ShowDoctorDetailsResponse ShowDoctorDetails(ShowDoctorDetailsRequest request)
        {
            var response = new ShowDoctorDetailsResponse();
            DoctorDbContext doctorDbContext = new DoctorDbContext();

            var entity = doctorDbContext.Doctors.FirstOrDefault(item => item.IdDoctor == request.doctorId);
            if (entity != null)
            {
                response.message = entity.FirstName + " " + entity.LastName + " " + entity.Email;
            }
            else
            {
                response.message = "There is no such doctor with this id";
            }

            return response;
        }
    }
}
