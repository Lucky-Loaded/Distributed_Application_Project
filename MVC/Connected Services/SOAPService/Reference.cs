﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.SOAPService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SOAPService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        MVC.SOAPService.CompositeType GetDataUsingDataContract(MVC.SOAPService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<MVC.SOAPService.CompositeType> GetDataUsingDataContractAsync(MVC.SOAPService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFilms", ReplyAction="http://tempuri.org/IService1/GetFilmsResponse")]
        ApplicationService.DTOs.FilmDTO[] GetFilms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFilms", ReplyAction="http://tempuri.org/IService1/GetFilmsResponse")]
        System.Threading.Tasks.Task<ApplicationService.DTOs.FilmDTO[]> GetFilmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PostFilm", ReplyAction="http://tempuri.org/IService1/PostFilmResponse")]
        string PostFilm(ApplicationService.DTOs.FilmDTO filmDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PostFilm", ReplyAction="http://tempuri.org/IService1/PostFilmResponse")]
        System.Threading.Tasks.Task<string> PostFilmAsync(ApplicationService.DTOs.FilmDTO filmDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteFilm", ReplyAction="http://tempuri.org/IService1/DeleteFilmResponse")]
        string DeleteFilm(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteFilm", ReplyAction="http://tempuri.org/IService1/DeleteFilmResponse")]
        System.Threading.Tasks.Task<string> DeleteFilmAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        ApplicationService.DTOs.UserDTO[] GetUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        System.Threading.Tasks.Task<ApplicationService.DTOs.UserDTO[]> GetUserAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PostUser", ReplyAction="http://tempuri.org/IService1/PostUserResponse")]
        string PostUser(ApplicationService.DTOs.UserDTO userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PostUser", ReplyAction="http://tempuri.org/IService1/PostUserResponse")]
        System.Threading.Tasks.Task<string> PostUserAsync(ApplicationService.DTOs.UserDTO userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteUser", ReplyAction="http://tempuri.org/IService1/DeleteUserResponse")]
        string DeleteUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteUser", ReplyAction="http://tempuri.org/IService1/DeleteUserResponse")]
        System.Threading.Tasks.Task<string> DeleteUserAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : MVC.SOAPService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<MVC.SOAPService.IService1>, MVC.SOAPService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public MVC.SOAPService.CompositeType GetDataUsingDataContract(MVC.SOAPService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<MVC.SOAPService.CompositeType> GetDataUsingDataContractAsync(MVC.SOAPService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public ApplicationService.DTOs.FilmDTO[] GetFilms() {
            return base.Channel.GetFilms();
        }
        
        public System.Threading.Tasks.Task<ApplicationService.DTOs.FilmDTO[]> GetFilmsAsync() {
            return base.Channel.GetFilmsAsync();
        }
        
        public string PostFilm(ApplicationService.DTOs.FilmDTO filmDto) {
            return base.Channel.PostFilm(filmDto);
        }
        
        public System.Threading.Tasks.Task<string> PostFilmAsync(ApplicationService.DTOs.FilmDTO filmDto) {
            return base.Channel.PostFilmAsync(filmDto);
        }
        
        public string DeleteFilm(int id) {
            return base.Channel.DeleteFilm(id);
        }
        
        public System.Threading.Tasks.Task<string> DeleteFilmAsync(int id) {
            return base.Channel.DeleteFilmAsync(id);
        }
        
        public ApplicationService.DTOs.UserDTO[] GetUser() {
            return base.Channel.GetUser();
        }
        
        public System.Threading.Tasks.Task<ApplicationService.DTOs.UserDTO[]> GetUserAsync() {
            return base.Channel.GetUserAsync();
        }
        
        public string PostUser(ApplicationService.DTOs.UserDTO userDto) {
            return base.Channel.PostUser(userDto);
        }
        
        public System.Threading.Tasks.Task<string> PostUserAsync(ApplicationService.DTOs.UserDTO userDto) {
            return base.Channel.PostUserAsync(userDto);
        }
        
        public string DeleteUser(int id) {
            return base.Channel.DeleteUser(id);
        }
        
        public System.Threading.Tasks.Task<string> DeleteUserAsync(int id) {
            return base.Channel.DeleteUserAsync(id);
        }
    }
}