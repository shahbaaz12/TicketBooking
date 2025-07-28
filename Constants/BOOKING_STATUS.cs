namespace TicketBooking.Constants
{
    public enum BOOKING_STATUS
    {
        PENDING,    // Booking is pending confirmation
        CONFIRMED,  // Booking has been confirmed
        CANCELLED,  // Booking has been cancelled
        COMPLETED,  // Booking has been completed
        REFUNDED,   // Booking has been refunded
        FAILED      // Booking has failed
    }
}
