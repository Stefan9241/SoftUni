namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
      
        public string Make
        {
            set
            { make = value; }
            get { return make; }
        }

        public string Model
        {
            set
            {
                model = value;
            }
            get
            {
                return model;
            }
        }

        public int Year
        {
            set
            {
                year = value;
            }
            get
            {
                return year;
            }
        }
    }
}
