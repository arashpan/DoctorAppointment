using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Model
{
    public class Clinic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; } = new List<Doctor>();
        public ICollection<Patient> Patients { get; } = new List<Patient>();
    }
}
