namespace StudentsGroup
{
    abstract internal class User
    {
        protected string _firstName;
        protected string _secondName;
        protected string _lastName;
        protected int _age;

        public User()
        {

        }

        public User(string firstName, string lastName, string secondName, int age)
        {
            _firstName = firstName;
            _secondName = secondName;
            _lastName = lastName;
            _age = age;
        }

        public string FirstName { get { return _firstName; } }
        public string SecondName { get { return _secondName; } }
        public string LastName { get { return _lastName; } }
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
    }
}