﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleTesting.CustomerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.datacontract.org/2004/07/CinemaServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class Customer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerCityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerEmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerFirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerLastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerPasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerPhoneNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerUsernameField;
        
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
        public string CustomerAddress {
            get {
                return this.CustomerAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerAddressField, value) != true)) {
                    this.CustomerAddressField = value;
                    this.RaisePropertyChanged("CustomerAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerCity {
            get {
                return this.CustomerCityField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerCityField, value) != true)) {
                    this.CustomerCityField = value;
                    this.RaisePropertyChanged("CustomerCity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerEmail {
            get {
                return this.CustomerEmailField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerEmailField, value) != true)) {
                    this.CustomerEmailField = value;
                    this.RaisePropertyChanged("CustomerEmail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerFirstName {
            get {
                return this.CustomerFirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerFirstNameField, value) != true)) {
                    this.CustomerFirstNameField = value;
                    this.RaisePropertyChanged("CustomerFirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerLastName {
            get {
                return this.CustomerLastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerLastNameField, value) != true)) {
                    this.CustomerLastNameField = value;
                    this.RaisePropertyChanged("CustomerLastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerPassword {
            get {
                return this.CustomerPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerPasswordField, value) != true)) {
                    this.CustomerPasswordField = value;
                    this.RaisePropertyChanged("CustomerPassword");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerPhoneNo {
            get {
                return this.CustomerPhoneNoField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerPhoneNoField, value) != true)) {
                    this.CustomerPhoneNoField = value;
                    this.RaisePropertyChanged("CustomerPhoneNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerUsername {
            get {
                return this.CustomerUsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerUsernameField, value) != true)) {
                    this.CustomerUsernameField = value;
                    this.RaisePropertyChanged("CustomerUsername");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerServiceReference.ICustomerService")]
    public interface ICustomerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/insertCustomer", ReplyAction="http://tempuri.org/ICustomerService/insertCustomerResponse")]
        int insertCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/insertCustomer", ReplyAction="http://tempuri.org/ICustomerService/insertCustomerResponse")]
        System.Threading.Tasks.Task<int> insertCustomerAsync(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/updateCustomer", ReplyAction="http://tempuri.org/ICustomerService/updateCustomerResponse")]
        int updateCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/updateCustomer", ReplyAction="http://tempuri.org/ICustomerService/updateCustomerResponse")]
        System.Threading.Tasks.Task<int> updateCustomerAsync(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/deleteCustomerByName", ReplyAction="http://tempuri.org/ICustomerService/deleteCustomerByNameResponse")]
        int deleteCustomerByName(string fName, string lName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/deleteCustomerByName", ReplyAction="http://tempuri.org/ICustomerService/deleteCustomerByNameResponse")]
        System.Threading.Tasks.Task<int> deleteCustomerByNameAsync(string fName, string lName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/deleteCustomerByUserName", ReplyAction="http://tempuri.org/ICustomerService/deleteCustomerByUserNameResponse")]
        int deleteCustomerByUserName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/deleteCustomerByUserName", ReplyAction="http://tempuri.org/ICustomerService/deleteCustomerByUserNameResponse")]
        System.Threading.Tasks.Task<int> deleteCustomerByUserNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/getCustomerByName", ReplyAction="http://tempuri.org/ICustomerService/getCustomerByNameResponse")]
        ConsoleTesting.CustomerServiceReference.Customer getCustomerByName(string fName, string lName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/getCustomerByName", ReplyAction="http://tempuri.org/ICustomerService/getCustomerByNameResponse")]
        System.Threading.Tasks.Task<ConsoleTesting.CustomerServiceReference.Customer> getCustomerByNameAsync(string fName, string lName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/getCustomerByUsername", ReplyAction="http://tempuri.org/ICustomerService/getCustomerByUsernameResponse")]
        ConsoleTesting.CustomerServiceReference.Customer getCustomerByUsername(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/getCustomerByUsername", ReplyAction="http://tempuri.org/ICustomerService/getCustomerByUsernameResponse")]
        System.Threading.Tasks.Task<ConsoleTesting.CustomerServiceReference.Customer> getCustomerByUsernameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/getCustomers", ReplyAction="http://tempuri.org/ICustomerService/getCustomersResponse")]
        ConsoleTesting.CustomerServiceReference.Customer[] getCustomers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/getCustomers", ReplyAction="http://tempuri.org/ICustomerService/getCustomersResponse")]
        System.Threading.Tasks.Task<ConsoleTesting.CustomerServiceReference.Customer[]> getCustomersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerServiceChannel : ConsoleTesting.CustomerServiceReference.ICustomerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<ConsoleTesting.CustomerServiceReference.ICustomerService>, ConsoleTesting.CustomerServiceReference.ICustomerService {
        
        public CustomerServiceClient() {
        }
        
        public CustomerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int insertCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password) {
            return base.Channel.insertCustomer(fName, lName, city, address, email, phoneNo, username, password);
        }
        
        public System.Threading.Tasks.Task<int> insertCustomerAsync(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password) {
            return base.Channel.insertCustomerAsync(fName, lName, city, address, email, phoneNo, username, password);
        }
        
        public int updateCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password) {
            return base.Channel.updateCustomer(fName, lName, city, address, email, phoneNo, username, password);
        }
        
        public System.Threading.Tasks.Task<int> updateCustomerAsync(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password) {
            return base.Channel.updateCustomerAsync(fName, lName, city, address, email, phoneNo, username, password);
        }
        
        public int deleteCustomerByName(string fName, string lName) {
            return base.Channel.deleteCustomerByName(fName, lName);
        }
        
        public System.Threading.Tasks.Task<int> deleteCustomerByNameAsync(string fName, string lName) {
            return base.Channel.deleteCustomerByNameAsync(fName, lName);
        }
        
        public int deleteCustomerByUserName(string userName) {
            return base.Channel.deleteCustomerByUserName(userName);
        }
        
        public System.Threading.Tasks.Task<int> deleteCustomerByUserNameAsync(string userName) {
            return base.Channel.deleteCustomerByUserNameAsync(userName);
        }
        
        public ConsoleTesting.CustomerServiceReference.Customer getCustomerByName(string fName, string lName) {
            return base.Channel.getCustomerByName(fName, lName);
        }
        
        public System.Threading.Tasks.Task<ConsoleTesting.CustomerServiceReference.Customer> getCustomerByNameAsync(string fName, string lName) {
            return base.Channel.getCustomerByNameAsync(fName, lName);
        }
        
        public ConsoleTesting.CustomerServiceReference.Customer getCustomerByUsername(string username) {
            return base.Channel.getCustomerByUsername(username);
        }
        
        public System.Threading.Tasks.Task<ConsoleTesting.CustomerServiceReference.Customer> getCustomerByUsernameAsync(string username) {
            return base.Channel.getCustomerByUsernameAsync(username);
        }
        
        public ConsoleTesting.CustomerServiceReference.Customer[] getCustomers() {
            return base.Channel.getCustomers();
        }
        
        public System.Threading.Tasks.Task<ConsoleTesting.CustomerServiceReference.Customer[]> getCustomersAsync() {
            return base.Channel.getCustomersAsync();
        }
    }
}
