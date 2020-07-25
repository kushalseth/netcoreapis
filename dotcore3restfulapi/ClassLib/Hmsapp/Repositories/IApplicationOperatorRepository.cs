using Hmsapp.Models;

namespace Hmsapp.Repositories
{
    public interface IApplicationOperatorRepository
    {
        ApplicationOperator GetDoctorDetails(string emailAddress);

        bool SaveDoctorProfile(DoctorProfileModel doctorProfileModel, string userId);
    }
}