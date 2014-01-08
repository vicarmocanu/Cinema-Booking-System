﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUIEmployee.EmployeeSrv {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/CinemaServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FName {
            get {
                return this.FNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FNameField, value) != true)) {
                    this.FNameField = value;
                    this.RaisePropertyChanged("FName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LName {
            get {
                return this.LNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LNameField, value) != true)) {
                    this.LNameField = value;
                    this.RaisePropertyChanged("LName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeSrv.IEmployeeService")]
    public interface IEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/insertEmployee", ReplyAction="http://tempuri.org/IEmployeeService/insertEmployeeResponse")]
        int insertEmployee(string fName, string lName, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/insertEmployee", ReplyAction="http://tempuri.org/IEmployeeService/insertEmployeeResponse")]
        System.Threading.Tasks.Task<int> insertEmployeeAsync(string fName, string lName, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/updateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/updateEmployeeResponse")]
        int updateEmployee(string fName, string lName, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/updateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/updateEmployeeResponse")]
        System.Threading.Tasks.Task<int> updateEmployeeAsync(string fName, string lName, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/deleteEmployeeByUserName", ReplyAction="http://tempuri.org/IEmployeeService/deleteEmployeeByUserNameResponse")]
        int deleteEmployeeByUserName(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/deleteEmployeeByUserName", ReplyAction="http://tempuri.org/IEmployeeService/deleteEmployeeByUserNameResponse")]
        System.Threading.Tasks.Task<int> deleteEmployeeByUserNameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/getEmployeeByUserName", ReplyAction="http://tempuri.org/IEmployeeService/getEmployeeByUserNameResponse")]
        GUIEmployee.EmployeeSrv.Employee getEmployeeByUserName(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/getEmployeeByUserName", ReplyAction="http://tempuri.org/IEmployeeService/getEmployeeByUserNameResponse")]
        System.Threading.Tasks.Task<GUIEmployee.EmployeeSrv.Employee> getEmployeeByUserNameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/getEmployees", ReplyAction="http://tempuri.org/IEmployeeService/getEmployeesResponse")]
        GUIEmployee.EmployeeSrv.Employee[] getEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/getEmployees", ReplyAction="http://tempuri.org/IEmployeeService/getEmployeesResponse")]
        System.Threading.Tasks.Task<GUIEmployee.EmployeeSrv.Employee[]> getEmployeesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeServiceChannel : GUIEmployee.EmployeeSrv.IEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceClient : System.ServiceModel.ClientBase<GUIEmployee.EmployeeSrv.IEmployeeService>, GUIEmployee.EmployeeSrv.IEmployeeService {
        
        public EmployeeServiceClient() {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int insertEmployee(string fName, string lName, string username, string password) {
            return base.Channel.insertEmployee(fName, lName, username, password);
        }
        
        public System.Threading.Tasks.Task<int> insertEmployeeAsync(string fName, string lName, string username, string password) {
            return base.Channel.insertEmployeeAsync(fName, lName, username, password);
        }
        
        public int updateEmployee(string fName, string lName, string username, string password) {
            return base.Channel.updateEmployee(fName, lName, username, password);
        }
        
        public System.Threading.Tasks.Task<int> updateEmployeeAsync(string fName, string lName, string username, string password) {
            return base.Channel.updateEmployeeAsync(fName, lName, username, password);
        }
        
        public int deleteEmployeeByUserName(string username) {
            return base.Channel.deleteEmployeeByUserName(username);
        }
        
        public System.Threading.Tasks.Task<int> deleteEmployeeByUserNameAsync(string username) {
            return base.Channel.deleteEmployeeByUserNameAsync(username);
        }
        
        public GUIEmployee.EmployeeSrv.Employee getEmployeeByUserName(string username) {
            return base.Channel.getEmployeeByUserName(username);
        }
        
        public System.Threading.Tasks.Task<GUIEmployee.EmployeeSrv.Employee> getEmployeeByUserNameAsync(string username) {
            return base.Channel.getEmployeeByUserNameAsync(username);
        }
        
        public GUIEmployee.EmployeeSrv.Employee[] getEmployees() {
            return base.Channel.getEmployees();
        }
        
        public System.Threading.Tasks.Task<GUIEmployee.EmployeeSrv.Employee[]> getEmployeesAsync() {
            return base.Channel.getEmployeesAsync();
        }
    }
}
