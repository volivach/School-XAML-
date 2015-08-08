namespace StudentsGroup
{
    abstract internal class User
    {
        protected string _firstName;
        protected string _secondName;
        protected string _lastName;
        protected string _imageUri = @"http://www.wageningenur.nl/upload_mm/8/8/e/ee050040-ff95-4b6a-8005-d0089348ba13_student_studeren_bieb_bibliotheek_lezen_640x430_640x430.jpg";
        protected int _age;

        public User()
        {

        }

        public User(string firstName, string lastName, string secondName, string imageUri, int age)
        {
            _firstName = firstName;
            _secondName = secondName;
            _lastName = lastName;
            _imageUri = imageUri;
            _age = age;
        }

        public string FirstName { get { return _firstName; } }
        public string SecondName { get { return _secondName; } }
        public string LastName { get { return _lastName; } }
        public string Uri { get { return _imageUri; } }
        public int Age
        {
            get
            {
                return _age;
            }
        }

        public abstract string CreatePassword();

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", _firstName, _secondName, _lastName, _age);
        }

        static public User CreateUser(string firstName,
    string secondName, string lastName, string imageUri, int age, string type)
        {
            if (type == "Student")
                return new Student(firstName, lastName, secondName, imageUri, age);
            else if (type == "Teacher")
                return new Teacher(firstName, lastName, secondName, imageUri, age);
            //else if (type == "Guest")
            //    return new Guest(firstName, lastName, secondName, imageUri, age);
            //else if (type == "Administrator")
            //    return new Administrator(firstName, lastName, secondName, imageUri, age);

            return null;
        }
    }
}