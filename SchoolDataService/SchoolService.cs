using StudentsGroup;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SchoolDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SchoolService" in both code and config file together.
    public class SchoolService : ISchoolService
    {
        public int GetSumm(int x, int y)
        {
            return x + y;
        }

        private List<Group> _groups = new List<Group>();
        private List<User> _users = new List<User>();

        public SchoolService()
        {
        }

        //public void WriteDataToDatabase()
        //{
        //    using (SchoolEntityModelContainer context = new SchoolEntityModelContainer())
        //    {

        //        context.Groups.Load();
        //        context.Groups.Add(new Groups() { Id = 1, Name = "C#-15-01" });

        //        context.Users.Load();
        //        foreach (var it in _users)
        //        {
        //            Users user = new Users()
        //            {
        //                FirstName = it.FirstName,
        //                SecondName = it.SecondName,
        //                LastName = it.LastName,
        //                imageUri = it.Uri,
        //                Age = (short)it.Age,
        //                GroupsId = 1
        //            };


        //            var roles = context.Roles.Local.ToList();
        //            var currentRole = roles.FirstOrDefault(i => it.GetRoleType() == i.Role);

        //            if (currentRole == null)
        //            {
        //                currentRole = roles.LastOrDefault();
        //                int roleId = currentRole != null ? currentRole.Id + 1 : 1;
        //                context.Roles.Add(new Roles() { Role = it.GetRoleType(), Id = roleId });
        //                user.RolesId = roleId;
        //            }
        //            else
        //                user.RolesId = currentRole.Id;



        //            context.Users.Add(user);
        //        }
        //        context.SaveChanges();
        //    }
        //}


        public List<string> GetGroups()
        {
            using (SchoolEntities context = new SchoolEntities())
            {
                return (from currGroup in context.Groups
                        select currGroup.Name).ToList();
            }
        }

        public string GetUsers()
        {
            using (SchoolEntities context = new SchoolEntities())
            {
                var users = (from user in context.Users
                 select user).ToList();
                string res = JsonConvert.SerializeObject(users);
                return res;
            }
        }
    }
}
