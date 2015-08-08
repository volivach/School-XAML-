using System;

namespace StudentsGroup.Group
{
    internal class Guest : User
    {
        public Guest(string firstName, string lastName, string secondName, string imageUri, int age) : base(firstName, lastName, secondName, imageUri, age)
        {
        }

        public override string CreatePassword()
        {
            throw new NotImplementedException();
        }
    }
}