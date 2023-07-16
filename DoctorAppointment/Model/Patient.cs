using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Model
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }
        public int PatientNumber { get; set; }        
        public string NationalCode { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }        
        public DateTime AppointmentDateTime { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
    }
}
