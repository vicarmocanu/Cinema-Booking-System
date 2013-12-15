﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUIEmployee.SeatSrv {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Seat", Namespace="http://schemas.datacontract.org/2004/07/CinemaServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class Seat : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GUIEmployee.SeatSrv.Room RoomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RowNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SeatIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SeatNumberField;
        
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
        public GUIEmployee.SeatSrv.Room Room {
            get {
                return this.RoomField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomField, value) != true)) {
                    this.RoomField = value;
                    this.RaisePropertyChanged("Room");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RowNumber {
            get {
                return this.RowNumberField;
            }
            set {
                if ((this.RowNumberField.Equals(value) != true)) {
                    this.RowNumberField = value;
                    this.RaisePropertyChanged("RowNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SeatId {
            get {
                return this.SeatIdField;
            }
            set {
                if ((this.SeatIdField.Equals(value) != true)) {
                    this.SeatIdField = value;
                    this.RaisePropertyChanged("SeatId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SeatNumber {
            get {
                return this.SeatNumberField;
            }
            set {
                if ((this.SeatNumberField.Equals(value) != true)) {
                    this.SeatNumberField = value;
                    this.RaisePropertyChanged("SeatNumber");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SeatSrv.ISeatService")]
    public interface ISeatService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/insertSeat", ReplyAction="http://tempuri.org/ISeatService/insertSeatResponse")]
        int insertSeat(int seatNumber, int rowNumber, int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/insertSeat", ReplyAction="http://tempuri.org/ISeatService/insertSeatResponse")]
        System.Threading.Tasks.Task<int> insertSeatAsync(int seatNumber, int rowNumber, int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/updateSeat", ReplyAction="http://tempuri.org/ISeatService/updateSeatResponse")]
        int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/updateSeat", ReplyAction="http://tempuri.org/ISeatService/updateSeatResponse")]
        System.Threading.Tasks.Task<int> updateSeatAsync(int seatID, int seatNumber, int rowNumber, int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/deleteSeat", ReplyAction="http://tempuri.org/ISeatService/deleteSeatResponse")]
        int deleteSeat(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/deleteSeat", ReplyAction="http://tempuri.org/ISeatService/deleteSeatResponse")]
        System.Threading.Tasks.Task<int> deleteSeatAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/deleteRoomSeats", ReplyAction="http://tempuri.org/ISeatService/deleteRoomSeatsResponse")]
        int deleteRoomSeats(int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/deleteRoomSeats", ReplyAction="http://tempuri.org/ISeatService/deleteRoomSeatsResponse")]
        System.Threading.Tasks.Task<int> deleteRoomSeatsAsync(int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/insertSeatMatrix", ReplyAction="http://tempuri.org/ISeatService/insertSeatMatrixResponse")]
        int[] insertSeatMatrix(int rows, int columns, int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/insertSeatMatrix", ReplyAction="http://tempuri.org/ISeatService/insertSeatMatrixResponse")]
        System.Threading.Tasks.Task<int[]> insertSeatMatrixAsync(int rows, int columns, int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/deleteSeatById", ReplyAction="http://tempuri.org/ISeatService/deleteSeatByIdResponse")]
        int deleteSeatById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/deleteSeatById", ReplyAction="http://tempuri.org/ISeatService/deleteSeatByIdResponse")]
        System.Threading.Tasks.Task<int> deleteSeatByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/getSeat", ReplyAction="http://tempuri.org/ISeatService/getSeatResponse")]
        GUIEmployee.SeatSrv.Seat getSeat(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/getSeat", ReplyAction="http://tempuri.org/ISeatService/getSeatResponse")]
        System.Threading.Tasks.Task<GUIEmployee.SeatSrv.Seat> getSeatAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/getSeats", ReplyAction="http://tempuri.org/ISeatService/getSeatsResponse")]
        GUIEmployee.SeatSrv.Seat[] getSeats();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/getSeats", ReplyAction="http://tempuri.org/ISeatService/getSeatsResponse")]
        System.Threading.Tasks.Task<GUIEmployee.SeatSrv.Seat[]> getSeatsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/getRoomSeats", ReplyAction="http://tempuri.org/ISeatService/getRoomSeatsResponse")]
        GUIEmployee.SeatSrv.Seat[] getRoomSeats(int roomNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeatService/getRoomSeats", ReplyAction="http://tempuri.org/ISeatService/getRoomSeatsResponse")]
        System.Threading.Tasks.Task<GUIEmployee.SeatSrv.Seat[]> getRoomSeatsAsync(int roomNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISeatServiceChannel : GUIEmployee.SeatSrv.ISeatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SeatServiceClient : System.ServiceModel.ClientBase<GUIEmployee.SeatSrv.ISeatService>, GUIEmployee.SeatSrv.ISeatService {
        
        public SeatServiceClient() {
        }
        
        public SeatServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SeatServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeatServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeatServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int insertSeat(int seatNumber, int rowNumber, int roomNumber) {
            return base.Channel.insertSeat(seatNumber, rowNumber, roomNumber);
        }
        
        public System.Threading.Tasks.Task<int> insertSeatAsync(int seatNumber, int rowNumber, int roomNumber) {
            return base.Channel.insertSeatAsync(seatNumber, rowNumber, roomNumber);
        }
        
        public int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber) {
            return base.Channel.updateSeat(seatID, seatNumber, rowNumber, roomNumber);
        }
        
        public System.Threading.Tasks.Task<int> updateSeatAsync(int seatID, int seatNumber, int rowNumber, int roomNumber) {
            return base.Channel.updateSeatAsync(seatID, seatNumber, rowNumber, roomNumber);
        }
        
        public int deleteSeat(int id) {
            return base.Channel.deleteSeat(id);
        }
        
        public System.Threading.Tasks.Task<int> deleteSeatAsync(int id) {
            return base.Channel.deleteSeatAsync(id);
        }
        
        public int deleteRoomSeats(int roomNumber) {
            return base.Channel.deleteRoomSeats(roomNumber);
        }
        
        public System.Threading.Tasks.Task<int> deleteRoomSeatsAsync(int roomNumber) {
            return base.Channel.deleteRoomSeatsAsync(roomNumber);
        }
        
        public int[] insertSeatMatrix(int rows, int columns, int roomNumber) {
            return base.Channel.insertSeatMatrix(rows, columns, roomNumber);
        }
        
        public System.Threading.Tasks.Task<int[]> insertSeatMatrixAsync(int rows, int columns, int roomNumber) {
            return base.Channel.insertSeatMatrixAsync(rows, columns, roomNumber);
        }
        
        public int deleteSeatById(int id) {
            return base.Channel.deleteSeatById(id);
        }
        
        public System.Threading.Tasks.Task<int> deleteSeatByIdAsync(int id) {
            return base.Channel.deleteSeatByIdAsync(id);
        }
        
        public GUIEmployee.SeatSrv.Seat getSeat(int id) {
            return base.Channel.getSeat(id);
        }
        
        public System.Threading.Tasks.Task<GUIEmployee.SeatSrv.Seat> getSeatAsync(int id) {
            return base.Channel.getSeatAsync(id);
        }
        
        public GUIEmployee.SeatSrv.Seat[] getSeats() {
            return base.Channel.getSeats();
        }
        
        public System.Threading.Tasks.Task<GUIEmployee.SeatSrv.Seat[]> getSeatsAsync() {
            return base.Channel.getSeatsAsync();
        }
        
        public GUIEmployee.SeatSrv.Seat[] getRoomSeats(int roomNumber) {
            return base.Channel.getRoomSeats(roomNumber);
        }
        
        public System.Threading.Tasks.Task<GUIEmployee.SeatSrv.Seat[]> getRoomSeatsAsync(int roomNumber) {
            return base.Channel.getRoomSeatsAsync(roomNumber);
        }
    }
}
