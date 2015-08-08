﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestConnection.SchoolDataProvider {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SchoolDataProvider.ISchoolService")]
    public interface ISchoolService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISchoolService/GetSumm", ReplyAction="http://tempuri.org/ISchoolService/GetSummResponse")]
        int GetSumm(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISchoolService/GetSumm", ReplyAction="http://tempuri.org/ISchoolService/GetSummResponse")]
        System.Threading.Tasks.Task<int> GetSummAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISchoolService/GetGroups", ReplyAction="http://tempuri.org/ISchoolService/GetGroupsResponse")]
        string[] GetGroups();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISchoolService/GetGroups", ReplyAction="http://tempuri.org/ISchoolService/GetGroupsResponse")]
        System.Threading.Tasks.Task<string[]> GetGroupsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISchoolService/GetUsers", ReplyAction="http://tempuri.org/ISchoolService/GetUsersResponse")]
        string[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISchoolService/GetUsers", ReplyAction="http://tempuri.org/ISchoolService/GetUsersResponse")]
        System.Threading.Tasks.Task<string[]> GetUsersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISchoolServiceChannel : TestConnection.SchoolDataProvider.ISchoolService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SchoolServiceClient : System.ServiceModel.ClientBase<TestConnection.SchoolDataProvider.ISchoolService>, TestConnection.SchoolDataProvider.ISchoolService {
        
        public SchoolServiceClient() {
        }
        
        public SchoolServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SchoolServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SchoolServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SchoolServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetSumm(int x, int y) {
            return base.Channel.GetSumm(x, y);
        }
        
        public System.Threading.Tasks.Task<int> GetSummAsync(int x, int y) {
            return base.Channel.GetSummAsync(x, y);
        }
        
        public string[] GetGroups() {
            return base.Channel.GetGroups();
        }
        
        public System.Threading.Tasks.Task<string[]> GetGroupsAsync() {
            return base.Channel.GetGroupsAsync();
        }
        
        public string[] GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<string[]> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
    }
}
