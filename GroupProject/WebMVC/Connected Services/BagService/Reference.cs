﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMVC.BagService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Bag", Namespace="http://schemas.datacontract.org/2004/07/WCF.Entities")]
    [System.SerializableAttribute()]
    public partial class Bag : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BagCIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BagIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BagNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OriginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sizeField;
        
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
        public string BagCID {
            get {
                return this.BagCIDField;
            }
            set {
                if ((object.ReferenceEquals(this.BagCIDField, value) != true)) {
                    this.BagCIDField = value;
                    this.RaisePropertyChanged("BagCID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BagID {
            get {
                return this.BagIDField;
            }
            set {
                if ((object.ReferenceEquals(this.BagIDField, value) != true)) {
                    this.BagIDField = value;
                    this.RaisePropertyChanged("BagID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BagName {
            get {
                return this.BagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.BagNameField, value) != true)) {
                    this.BagNameField = value;
                    this.RaisePropertyChanged("BagName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Image {
            get {
                return this.ImageField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageField, value) != true)) {
                    this.ImageField = value;
                    this.RaisePropertyChanged("Image");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Origin {
            get {
                return this.OriginField;
            }
            set {
                if ((object.ReferenceEquals(this.OriginField, value) != true)) {
                    this.OriginField = value;
                    this.RaisePropertyChanged("Origin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string size {
            get {
                return this.sizeField;
            }
            set {
                if ((object.ReferenceEquals(this.sizeField, value) != true)) {
                    this.sizeField = value;
                    this.RaisePropertyChanged("size");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BagService.IWCFBagService")]
    public interface IWCFBagService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/GetAllBooksForUser", ReplyAction="http://tempuri.org/IWCFBagService/GetAllBooksForUserResponse")]
        WebMVC.BagService.Bag[] GetAllBooksForUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/GetAllBooksForUser", ReplyAction="http://tempuri.org/IWCFBagService/GetAllBooksForUserResponse")]
        System.Threading.Tasks.Task<WebMVC.BagService.Bag[]> GetAllBooksForUserAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/GetAllBooksForAdmin", ReplyAction="http://tempuri.org/IWCFBagService/GetAllBooksForAdminResponse")]
        WebMVC.BagService.Bag[] GetAllBooksForAdmin();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/GetAllBooksForAdmin", ReplyAction="http://tempuri.org/IWCFBagService/GetAllBooksForAdminResponse")]
        System.Threading.Tasks.Task<WebMVC.BagService.Bag[]> GetAllBooksForAdminAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/AddNewBag", ReplyAction="http://tempuri.org/IWCFBagService/AddNewBagResponse")]
        bool AddNewBag(WebMVC.BagService.Bag bag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/AddNewBag", ReplyAction="http://tempuri.org/IWCFBagService/AddNewBagResponse")]
        System.Threading.Tasks.Task<bool> AddNewBagAsync(WebMVC.BagService.Bag bag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/UpdateBag", ReplyAction="http://tempuri.org/IWCFBagService/UpdateBagResponse")]
        bool UpdateBag(WebMVC.BagService.Bag bag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/UpdateBag", ReplyAction="http://tempuri.org/IWCFBagService/UpdateBagResponse")]
        System.Threading.Tasks.Task<bool> UpdateBagAsync(WebMVC.BagService.Bag bag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/DeleteBag", ReplyAction="http://tempuri.org/IWCFBagService/DeleteBagResponse")]
        bool DeleteBag(string bagID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/DeleteBag", ReplyAction="http://tempuri.org/IWCFBagService/DeleteBagResponse")]
        System.Threading.Tasks.Task<bool> DeleteBagAsync(string bagID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/GetBagByID", ReplyAction="http://tempuri.org/IWCFBagService/GetBagByIDResponse")]
        WebMVC.BagService.Bag GetBagByID(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/GetBagByID", ReplyAction="http://tempuri.org/IWCFBagService/GetBagByIDResponse")]
        System.Threading.Tasks.Task<WebMVC.BagService.Bag> GetBagByIDAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/GetLastBagID", ReplyAction="http://tempuri.org/IWCFBagService/GetLastBagIDResponse")]
        string GetLastBagID();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFBagService/GetLastBagID", ReplyAction="http://tempuri.org/IWCFBagService/GetLastBagIDResponse")]
        System.Threading.Tasks.Task<string> GetLastBagIDAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFBagServiceChannel : WebMVC.BagService.IWCFBagService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFBagServiceClient : System.ServiceModel.ClientBase<WebMVC.BagService.IWCFBagService>, WebMVC.BagService.IWCFBagService {
        
        public WCFBagServiceClient() {
        }
        
        public WCFBagServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCFBagServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFBagServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFBagServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebMVC.BagService.Bag[] GetAllBooksForUser() {
            return base.Channel.GetAllBooksForUser();
        }
        
        public System.Threading.Tasks.Task<WebMVC.BagService.Bag[]> GetAllBooksForUserAsync() {
            return base.Channel.GetAllBooksForUserAsync();
        }
        
        public WebMVC.BagService.Bag[] GetAllBooksForAdmin() {
            return base.Channel.GetAllBooksForAdmin();
        }
        
        public System.Threading.Tasks.Task<WebMVC.BagService.Bag[]> GetAllBooksForAdminAsync() {
            return base.Channel.GetAllBooksForAdminAsync();
        }
        
        public bool AddNewBag(WebMVC.BagService.Bag bag) {
            return base.Channel.AddNewBag(bag);
        }
        
        public System.Threading.Tasks.Task<bool> AddNewBagAsync(WebMVC.BagService.Bag bag) {
            return base.Channel.AddNewBagAsync(bag);
        }
        
        public bool UpdateBag(WebMVC.BagService.Bag bag) {
            return base.Channel.UpdateBag(bag);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateBagAsync(WebMVC.BagService.Bag bag) {
            return base.Channel.UpdateBagAsync(bag);
        }
        
        public bool DeleteBag(string bagID) {
            return base.Channel.DeleteBag(bagID);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteBagAsync(string bagID) {
            return base.Channel.DeleteBagAsync(bagID);
        }
        
        public WebMVC.BagService.Bag GetBagByID(string id) {
            return base.Channel.GetBagByID(id);
        }
        
        public System.Threading.Tasks.Task<WebMVC.BagService.Bag> GetBagByIDAsync(string id) {
            return base.Channel.GetBagByIDAsync(id);
        }
        
        public string GetLastBagID() {
            return base.Channel.GetLastBagID();
        }
        
        public System.Threading.Tasks.Task<string> GetLastBagIDAsync() {
            return base.Channel.GetLastBagIDAsync();
        }
    }
}
