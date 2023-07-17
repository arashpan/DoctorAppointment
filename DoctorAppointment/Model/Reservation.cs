namespace DoctorAppointment.Model
{
    public class Reservation
    {
        public DateTime ReservationDate { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Patient Patient { get; set; }
        public ICollection<Doctor> doctors { get; set; }
    }
}
