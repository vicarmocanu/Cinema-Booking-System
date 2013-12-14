﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleTesting.RoomServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Room", Namespace="http://schemas.datacontract.org/2004/07/CinemaServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class Room : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberOfSeatsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoomNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberField;
        
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
        public int NumberOfSeats {
            get {
                return this.NumberOfSeatsField;
            }
            set {
                if ((this.NumberOfSeatsField.Equals(value) != true)) {
                    this.NumberOfSeatsField = value;
                    this.RaisePropertyChanged("NumberOfSeats");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoomNumber {
            get {
                return this.RoomNumberField;
            }
            set {
                if ((this.RoomNumberField.Equals(value) != true)) {
                    this.RoomNumberField = value;
                    this.RaisePropertyChanged("RoomNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number {
            get {
                return this.numberField;
            }
            set {
                if ((this.numberField.Equals(value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoomServiceReference.IRoomService")]
    public interface IRoomService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/insertRoom", ReplyAction="http://tempuri.org/IRoomService/insertRoomResponse")]
        int insertRoom(int roomNumber, int numberOfSeats);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/insertRoom", ReplyAction="http://tempuri.org/IRoomService/insertRoomResponse")]
        System.Threading.Tasks.Task<int> insertRoomAsync(int roomNumber, int numberOfSeats);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/updateRoom", ReplyAction="http://tempuri.org/IRoomService/updateRoomResponse")]
        int updateRoom(int roomNumber, int numberOfSeats);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/updateRoom", ReplyAction="http://tempuri.org/IRoomService/updateRoomResponse")]
        System.Threading.Tasks.Task<int> updateRoomAsync(int roomNumber, int numberOfSeats);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/deleteRoomByNumber", ReplyAction="http://tempuri.org/IRoomService/deleteRoomByNumberResponse")]
        int deleteRoomByNumber(int number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/deleteRoomByNumber", ReplyAction="http://tempuri.org/IRoomService/deleteRoomByNumberResponse")]
        System.Threading.Tasks.Task<int> deleteRoomByNumberAsync(int number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/getRoomByNumber", ReplyAction="http://tempuri.org/IRoomService/getRoomByNumberResponse")]
        ConsoleTesting.RoomServiceReference.Room getRoomByNumber(int number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/getRoomByNumber", ReplyAction="http://tempuri.org/IRoomService/getRoomByNumberResponse")]
        System.Threading.Tasks.Task<ConsoleTesting.RoomServiceReference.Room> getRoomByNumberAsync(int number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/getRooms", ReplyAction="http://tempuri.org/IRoomService/getRoomsResponse")]
        ConsoleTesting.RoomServiceReference.Room[] getRooms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/getRooms", ReplyAction="http://tempuri.org/IRoomService/getRoomsResponse")]
        System.Threading.Tasks.Task<ConsoleTesting.RoomServiceReference.Room[]> getRoomsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoomServiceChannel : ConsoleTesting.RoomServiceReference.IRoomService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoomServiceClient : System.ServiceModel.ClientBase<ConsoleTesting.RoomServiceReference.IRoomService>, ConsoleTesting.RoomServiceReference.IRoomService {
        
        public RoomServiceClient() {
        }
        
        public RoomServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoomServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int insertRoom(int roomNumber, int numberOfSeats) {
            return base.Channel.insertRoom(roomNumber, numberOfSeats);
        }
        
        public System.Threading.Tasks.Task<int> insertRoomAsync(int roomNumber, int numberOfSeats) {
            return base.Channel.insertRoomAsync(roomNumber, numberOfSeats);
        }
        
        public int updateRoom(int roomNumber, int numberOfSeats) {
            return base.Channel.updateRoom(roomNumber, numberOfSeats);
        }
        
        public System.Threading.Tasks.Task<int> updateRoomAsync(int roomNumber, int numberOfSeats) {
            return base.Channel.updateRoomAsync(roomNumber, numberOfSeats);
        }
        
        public int deleteRoomByNumber(int number) {
            return base.Channel.deleteRoomByNumber(number);
        }
        
        public System.Threading.Tasks.Task<int> deleteRoomByNumberAsync(int number) {
            return base.Channel.deleteRoomByNumberAsync(number);
        }
        
        public ConsoleTesting.RoomServiceReference.Room getRoomByNumber(int number) {
            return base.Channel.getRoomByNumber(number);
        }
        
        public System.Threading.Tasks.Task<ConsoleTesting.RoomServiceReference.Room> getRoomByNumberAsync(int number) {
            return base.Channel.getRoomByNumberAsync(number);
        }
        
        public ConsoleTesting.RoomServiceReference.Room[] getRooms() {
            return base.Channel.getRooms();
        }
        
        public System.Threading.Tasks.Task<ConsoleTesting.RoomServiceReference.Room[]> getRoomsAsync() {
            return base.Channel.getRoomsAsync();
        }
    }
}