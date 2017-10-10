namespace Football.Business
{
    class Ticket
    {
        public int PriceInEuros { get; set; }
        public string Category { get; set; } //tribuna, peluza blabla
        public int Row { get; set; }
        public int Seat { get; set; }
        public int TicketName { get; set; } //numele matchului

        public string SeatDetails
        {
            get
            {
                return Seat + "/" + Row + "/" + Category;
            }
            set { }
        }
    }
}
