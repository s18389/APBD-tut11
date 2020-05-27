using apbd_tutorial11.DTOs.Requests;
using apbd_tutorial11.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_tutorial11.Services
{
    public interface IDoctorService
    {

        ShowDoctorDetailsResponse ShowDoctorDetails(ShowDoctorDetailsRequest request);
        AddDoctorResponse AddDoctor(AddDoctorRequest request);
        ModifyDoctorResponse ModifyDoctor(ModifyDoctorRequest request);
        DeleteDoctorResponse DeleteDoctor(DeleteDoctorRequest request);

    }
}
