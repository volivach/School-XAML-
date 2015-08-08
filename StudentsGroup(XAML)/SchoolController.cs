using ClassEnrolment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsGroup_XAML_.SchoolDataProvider;
using Newtonsoft.Json;

namespace StudentsGroup
{
    class UserDTO
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string imageUri { get; set; }
        public short Age { get; set; }
        public int RolesId { get; set; }
        public int GroupsId { get; set; }
    }

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
                {
                    _instance = new SchoolController();
                }

                return _instance;
            }
        }

        public AuthentificationManager AuthManager { get { return _authManager; } }

        internal async Task LoadData()
        {
            var client = new SchoolServiceClient(SchoolServiceClient.EndpointConfiguration.BasicHttpBinding_ISchoolService);

            string jsonStringResp = await client.GetUsersAsync();
            var listUsers = JsonConvert.DeserializeObject<List<UserDTO>>(jsonStringResp);

            _users.Clear();
            foreach (var it in listUsers)
            {
                string uri = string.IsNullOrEmpty(it.imageUri) ?
                    @"http://www.wageningenur.nl/upload_mm/8/8/e/ee050040-ff95-4b6a-8005-d0089348ba13_student_studeren_bieb_bibliotheek_lezen_640x430_640x430.jpg" :
                    it.imageUri;
                _users.Add(User.CreateUser(it.FirstName, it.SecondName, it.LastName, uri, it.Age, "Student"));
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
