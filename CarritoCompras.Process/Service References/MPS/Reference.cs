﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarritoCompras.Process.MPS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MedioPagoEntidad", Namespace="http://schemas.datacontract.org/2004/07/CarritoCompras.Entidad")]
    [System.SerializableAttribute()]
    public partial class MedioPagoEntidad : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Cod_MedioPagoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Nom_MedioPagoField;
        
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
        public int Cod_MedioPago {
            get {
                return this.Cod_MedioPagoField;
            }
            set {
                if ((this.Cod_MedioPagoField.Equals(value) != true)) {
                    this.Cod_MedioPagoField = value;
                    this.RaisePropertyChanged("Cod_MedioPago");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((this.EstadoField.Equals(value) != true)) {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Foto {
            get {
                return this.FotoField;
            }
            set {
                if ((object.ReferenceEquals(this.FotoField, value) != true)) {
                    this.FotoField = value;
                    this.RaisePropertyChanged("Foto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nom_MedioPago {
            get {
                return this.Nom_MedioPagoField;
            }
            set {
                if ((object.ReferenceEquals(this.Nom_MedioPagoField, value) != true)) {
                    this.Nom_MedioPagoField = value;
                    this.RaisePropertyChanged("Nom_MedioPago");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MPS.IMedioPagoService")]
    public interface IMedioPagoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMedioPagoService/ListarMediosPago", ReplyAction="http://tempuri.org/IMedioPagoService/ListarMediosPagoResponse")]
        System.Collections.Generic.List<CarritoCompras.Process.MPS.MedioPagoEntidad> ListarMediosPago();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMedioPagoService/ListarMediosPago", ReplyAction="http://tempuri.org/IMedioPagoService/ListarMediosPagoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<CarritoCompras.Process.MPS.MedioPagoEntidad>> ListarMediosPagoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMedioPagoServiceChannel : CarritoCompras.Process.MPS.IMedioPagoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MedioPagoServiceClient : System.ServiceModel.ClientBase<CarritoCompras.Process.MPS.IMedioPagoService>, CarritoCompras.Process.MPS.IMedioPagoService {
        
        public MedioPagoServiceClient() {
        }
        
        public MedioPagoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MedioPagoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MedioPagoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MedioPagoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<CarritoCompras.Process.MPS.MedioPagoEntidad> ListarMediosPago() {
            return base.Channel.ListarMediosPago();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<CarritoCompras.Process.MPS.MedioPagoEntidad>> ListarMediosPagoAsync() {
            return base.Channel.ListarMediosPagoAsync();
        }
    }
}
