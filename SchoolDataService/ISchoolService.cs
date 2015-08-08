using StudentsGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SchoolDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISchoolService" in both code and config file together.
    [ServiceContract]
    public interface ISchoolService
    {
        [OperationContract]
        int GetSumm(int x, int y);
        [OperationContract]
        List<string> GetGroups();
        [OperationContract]
        string GetUsers();
        //[OperationContract]
        //void AddStudent(UserInfo userInfo, GroupID id);
        //[OperationContract]
        //void AddTeacher(UserInfo userInfo);
    }
}
