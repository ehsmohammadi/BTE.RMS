namespace BTE.RMS.Model.Attendees
{
    public class Attendee
    {
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        #endregion

        #region Constructors
        protected Attendee()
        {
            
        }

        public Attendee(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
        #endregion
    }
}
