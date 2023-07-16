using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Model
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public int MedOrgNumber { get; set; }      
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string Speciality { get; set; }
        public int? ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        [Precision(18, 2)]
        public decimal Fee { get; set; }
    }
}
