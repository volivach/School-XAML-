using ClassEnrolment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGroup
{
    class SchoolController
    {
        private List<Group> _groups = new List<Group>();
        private List<User> _users = new List<User>();
        private AuthentificationManager _authManager = new AuthentificationManager();
        static SchoolController _instance;

        private SchoolController()
        {
            _groups.Add(new Group("C#-15-01"));
        }

        public static SchoolController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SchoolController();

                return _instance;
            }
        }

        public List<Group> Groups
        {
            get
            {
                return _groups;
            }
        }

        public List<User> Users
        {
            get
            {
                return _users;
            }
        }

        public void AddStudent(UserInfo userInfo, GroupID id)
        {
            var group = _groups.Find(it => it.Id == id);
            if (group == null)
                throw new GroupNotFoundException(String.Format("Can't find group : {0}", id.Id));

            Student st = new Student(userInfo.FirstName, userInfo.LastName, userInfo.SecondName, userInfo.Uri, userInfo.Age);
            group.AddStudent(st);
            AddUser(st, "Student");
        }

        public void AddTeacher(UserInfo userInfo)
        {
            Teacher st = new Teacher(userInfo.FirstName, userInfo.LastName, userInfo.SecondName, userInfo.Uri, userInfo.Age);
            AddUser(st, "Teacher");
        }

        public Student FindStudentByString(string st)
        {
            return null;
        }

        private void AddUser(User user, string type)
        {
            _authManager.RegisterNewUser(user, type);
            _users.Add(user);
        }
    }
}
