﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI.srvMascotas {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TVET_Mascotas", Namespace="http://schemas.datacontract.org/2004/07/Entidades")]
    [System.SerializableAttribute()]
    public partial class TVET_Mascotas : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_NombreMascotaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TN_IdClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TN_IdMascotaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVET_Citas[] TVET_CitasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVET_DetalleMascota TVET_DetalleMascotaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVE_Clientes TVE_ClientesField;
        
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
        public string TC_NombreMascota {
            get {
                return this.TC_NombreMascotaField;
            }
            set {
                if ((object.ReferenceEquals(this.TC_NombreMascotaField, value) != true)) {
                    this.TC_NombreMascotaField = value;
                    this.RaisePropertyChanged("TC_NombreMascota");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> TN_IdCliente {
            get {
                return this.TN_IdClienteField;
            }
            set {
                if ((this.TN_IdClienteField.Equals(value) != true)) {
                    this.TN_IdClienteField = value;
                    this.RaisePropertyChanged("TN_IdCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TN_IdMascota {
            get {
                return this.TN_IdMascotaField;
            }
            set {
                if ((this.TN_IdMascotaField.Equals(value) != true)) {
                    this.TN_IdMascotaField = value;
                    this.RaisePropertyChanged("TN_IdMascota");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVET_Citas[] TVET_Citas {
            get {
                return this.TVET_CitasField;
            }
            set {
                if ((object.ReferenceEquals(this.TVET_CitasField, value) != true)) {
                    this.TVET_CitasField = value;
                    this.RaisePropertyChanged("TVET_Citas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVET_DetalleMascota TVET_DetalleMascota {
            get {
                return this.TVET_DetalleMascotaField;
            }
            set {
                if ((object.ReferenceEquals(this.TVET_DetalleMascotaField, value) != true)) {
                    this.TVET_DetalleMascotaField = value;
                    this.RaisePropertyChanged("TVET_DetalleMascota");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVE_Clientes TVE_Clientes {
            get {
                return this.TVE_ClientesField;
            }
            set {
                if ((object.ReferenceEquals(this.TVE_ClientesField, value) != true)) {
                    this.TVE_ClientesField = value;
                    this.RaisePropertyChanged("TVE_Clientes");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TVET_DetalleMascota", Namespace="http://schemas.datacontract.org/2004/07/Entidades")]
    [System.SerializableAttribute()]
    public partial class TVET_DetalleMascota : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_ColorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_RazaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TN_IdMascotaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TN_PesoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVET_Mascotas TVET_MascotasField;
        
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
        public string TC_Color {
            get {
                return this.TC_ColorField;
            }
            set {
                if ((object.ReferenceEquals(this.TC_ColorField, value) != true)) {
                    this.TC_ColorField = value;
                    this.RaisePropertyChanged("TC_Color");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TC_Raza {
            get {
                return this.TC_RazaField;
            }
            set {
                if ((object.ReferenceEquals(this.TC_RazaField, value) != true)) {
                    this.TC_RazaField = value;
                    this.RaisePropertyChanged("TC_Raza");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TN_IdMascota {
            get {
                return this.TN_IdMascotaField;
            }
            set {
                if ((this.TN_IdMascotaField.Equals(value) != true)) {
                    this.TN_IdMascotaField = value;
                    this.RaisePropertyChanged("TN_IdMascota");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TN_Peso {
            get {
                return this.TN_PesoField;
            }
            set {
                if ((this.TN_PesoField.Equals(value) != true)) {
                    this.TN_PesoField = value;
                    this.RaisePropertyChanged("TN_Peso");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVET_Mascotas TVET_Mascotas {
            get {
                return this.TVET_MascotasField;
            }
            set {
                if ((object.ReferenceEquals(this.TVET_MascotasField, value) != true)) {
                    this.TVET_MascotasField = value;
                    this.RaisePropertyChanged("TVET_Mascotas");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TVE_Clientes", Namespace="http://schemas.datacontract.org/2004/07/Entidades")]
    [System.SerializableAttribute()]
    public partial class TVE_Clientes : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_Ap1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_Ap2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_CorreoElectronicoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_NumTelefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TN_IdClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVET_Citas[] TVET_CitasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVET_Mascotas[] TVET_MascotasField;
        
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
        public string TC_Ap1 {
            get {
                return this.TC_Ap1Field;
            }
            set {
                if ((object.ReferenceEquals(this.TC_Ap1Field, value) != true)) {
                    this.TC_Ap1Field = value;
                    this.RaisePropertyChanged("TC_Ap1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TC_Ap2 {
            get {
                return this.TC_Ap2Field;
            }
            set {
                if ((object.ReferenceEquals(this.TC_Ap2Field, value) != true)) {
                    this.TC_Ap2Field = value;
                    this.RaisePropertyChanged("TC_Ap2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TC_CorreoElectronico {
            get {
                return this.TC_CorreoElectronicoField;
            }
            set {
                if ((object.ReferenceEquals(this.TC_CorreoElectronicoField, value) != true)) {
                    this.TC_CorreoElectronicoField = value;
                    this.RaisePropertyChanged("TC_CorreoElectronico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TC_Nombre {
            get {
                return this.TC_NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.TC_NombreField, value) != true)) {
                    this.TC_NombreField = value;
                    this.RaisePropertyChanged("TC_Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TC_NumTelefono {
            get {
                return this.TC_NumTelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TC_NumTelefonoField, value) != true)) {
                    this.TC_NumTelefonoField = value;
                    this.RaisePropertyChanged("TC_NumTelefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TN_IdCliente {
            get {
                return this.TN_IdClienteField;
            }
            set {
                if ((this.TN_IdClienteField.Equals(value) != true)) {
                    this.TN_IdClienteField = value;
                    this.RaisePropertyChanged("TN_IdCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVET_Citas[] TVET_Citas {
            get {
                return this.TVET_CitasField;
            }
            set {
                if ((object.ReferenceEquals(this.TVET_CitasField, value) != true)) {
                    this.TVET_CitasField = value;
                    this.RaisePropertyChanged("TVET_Citas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVET_Mascotas[] TVET_Mascotas {
            get {
                return this.TVET_MascotasField;
            }
            set {
                if ((object.ReferenceEquals(this.TVET_MascotasField, value) != true)) {
                    this.TVET_MascotasField = value;
                    this.RaisePropertyChanged("TVET_Mascotas");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TVET_Citas", Namespace="http://schemas.datacontract.org/2004/07/Entidades")]
    [System.SerializableAttribute()]
    public partial class TVET_Citas : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TF_FecCitaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TN_IdCitaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TN_IdClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TN_IdMascotaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVET_Diagnostico[] TVET_DiagnosticoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVET_Mascotas TVET_MascotasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVE_Clientes TVE_ClientesField;
        
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
        public System.DateTime TF_FecCita {
            get {
                return this.TF_FecCitaField;
            }
            set {
                if ((this.TF_FecCitaField.Equals(value) != true)) {
                    this.TF_FecCitaField = value;
                    this.RaisePropertyChanged("TF_FecCita");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TN_IdCita {
            get {
                return this.TN_IdCitaField;
            }
            set {
                if ((this.TN_IdCitaField.Equals(value) != true)) {
                    this.TN_IdCitaField = value;
                    this.RaisePropertyChanged("TN_IdCita");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> TN_IdCliente {
            get {
                return this.TN_IdClienteField;
            }
            set {
                if ((this.TN_IdClienteField.Equals(value) != true)) {
                    this.TN_IdClienteField = value;
                    this.RaisePropertyChanged("TN_IdCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> TN_IdMascota {
            get {
                return this.TN_IdMascotaField;
            }
            set {
                if ((this.TN_IdMascotaField.Equals(value) != true)) {
                    this.TN_IdMascotaField = value;
                    this.RaisePropertyChanged("TN_IdMascota");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVET_Diagnostico[] TVET_Diagnostico {
            get {
                return this.TVET_DiagnosticoField;
            }
            set {
                if ((object.ReferenceEquals(this.TVET_DiagnosticoField, value) != true)) {
                    this.TVET_DiagnosticoField = value;
                    this.RaisePropertyChanged("TVET_Diagnostico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVET_Mascotas TVET_Mascotas {
            get {
                return this.TVET_MascotasField;
            }
            set {
                if ((object.ReferenceEquals(this.TVET_MascotasField, value) != true)) {
                    this.TVET_MascotasField = value;
                    this.RaisePropertyChanged("TVET_Mascotas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVE_Clientes TVE_Clientes {
            get {
                return this.TVE_ClientesField;
            }
            set {
                if ((object.ReferenceEquals(this.TVE_ClientesField, value) != true)) {
                    this.TVE_ClientesField = value;
                    this.RaisePropertyChanged("TVE_Clientes");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TVET_Diagnostico", Namespace="http://schemas.datacontract.org/2004/07/Entidades")]
    [System.SerializableAttribute()]
    public partial class TVET_Diagnostico : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TC_DscDiagnosticoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TN_IdCitaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TN_IdDiagnosticoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UI.srvMascotas.TVET_Citas TVET_CitasField;
        
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
        public string TC_DscDiagnostico {
            get {
                return this.TC_DscDiagnosticoField;
            }
            set {
                if ((object.ReferenceEquals(this.TC_DscDiagnosticoField, value) != true)) {
                    this.TC_DscDiagnosticoField = value;
                    this.RaisePropertyChanged("TC_DscDiagnostico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> TN_IdCita {
            get {
                return this.TN_IdCitaField;
            }
            set {
                if ((this.TN_IdCitaField.Equals(value) != true)) {
                    this.TN_IdCitaField = value;
                    this.RaisePropertyChanged("TN_IdCita");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TN_IdDiagnostico {
            get {
                return this.TN_IdDiagnosticoField;
            }
            set {
                if ((this.TN_IdDiagnosticoField.Equals(value) != true)) {
                    this.TN_IdDiagnosticoField = value;
                    this.RaisePropertyChanged("TN_IdDiagnostico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UI.srvMascotas.TVET_Citas TVET_Citas {
            get {
                return this.TVET_CitasField;
            }
            set {
                if ((object.ReferenceEquals(this.TVET_CitasField, value) != true)) {
                    this.TVET_CitasField = value;
                    this.RaisePropertyChanged("TVET_Citas");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="srvMascotas.IsrvMascotas")]
    public interface IsrvMascotas {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/DoWork", ReplyAction="http://tempuri.org/IsrvMascotas/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/DoWork", ReplyAction="http://tempuri.org/IsrvMascotas/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/obtenerMascotas_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/obtenerMascotas_ENTResponse")]
        UI.srvMascotas.TVET_Mascotas[] obtenerMascotas_ENT();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/obtenerMascotas_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/obtenerMascotas_ENTResponse")]
        System.Threading.Tasks.Task<UI.srvMascotas.TVET_Mascotas[]> obtenerMascotas_ENTAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/obtenerMascotasXId_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/obtenerMascotasXId_ENTResponse")]
        UI.srvMascotas.TVET_Mascotas obtenerMascotasXId_ENT(int pIdMascotas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/obtenerMascotasXId_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/obtenerMascotasXId_ENTResponse")]
        System.Threading.Tasks.Task<UI.srvMascotas.TVET_Mascotas> obtenerMascotasXId_ENTAsync(int pIdMascotas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/agregaMascotas_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/agregaMascotas_ENTResponse")]
        bool agregaMascotas_ENT(UI.srvMascotas.TVET_Mascotas pMascotas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/agregaMascotas_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/agregaMascotas_ENTResponse")]
        System.Threading.Tasks.Task<bool> agregaMascotas_ENTAsync(UI.srvMascotas.TVET_Mascotas pMascotas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/modificaMascotas_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/modificaMascotas_ENTResponse")]
        bool modificaMascotas_ENT(UI.srvMascotas.TVET_Mascotas pMascotas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/modificaMascotas_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/modificaMascotas_ENTResponse")]
        System.Threading.Tasks.Task<bool> modificaMascotas_ENTAsync(UI.srvMascotas.TVET_Mascotas pMascotas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/eliminaMascotas_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/eliminaMascotas_ENTResponse")]
        bool eliminaMascotas_ENT(UI.srvMascotas.TVET_Mascotas pMascotas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsrvMascotas/eliminaMascotas_ENT", ReplyAction="http://tempuri.org/IsrvMascotas/eliminaMascotas_ENTResponse")]
        System.Threading.Tasks.Task<bool> eliminaMascotas_ENTAsync(UI.srvMascotas.TVET_Mascotas pMascotas);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IsrvMascotasChannel : UI.srvMascotas.IsrvMascotas, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IsrvMascotasClient : System.ServiceModel.ClientBase<UI.srvMascotas.IsrvMascotas>, UI.srvMascotas.IsrvMascotas {
        
        public IsrvMascotasClient() {
        }
        
        public IsrvMascotasClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IsrvMascotasClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IsrvMascotasClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IsrvMascotasClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public UI.srvMascotas.TVET_Mascotas[] obtenerMascotas_ENT() {
            return base.Channel.obtenerMascotas_ENT();
        }
        
        public System.Threading.Tasks.Task<UI.srvMascotas.TVET_Mascotas[]> obtenerMascotas_ENTAsync() {
            return base.Channel.obtenerMascotas_ENTAsync();
        }
        
        public UI.srvMascotas.TVET_Mascotas obtenerMascotasXId_ENT(int pIdMascotas) {
            return base.Channel.obtenerMascotasXId_ENT(pIdMascotas);
        }
        
        public System.Threading.Tasks.Task<UI.srvMascotas.TVET_Mascotas> obtenerMascotasXId_ENTAsync(int pIdMascotas) {
            return base.Channel.obtenerMascotasXId_ENTAsync(pIdMascotas);
        }
        
        public bool agregaMascotas_ENT(UI.srvMascotas.TVET_Mascotas pMascotas) {
            return base.Channel.agregaMascotas_ENT(pMascotas);
        }
        
        public System.Threading.Tasks.Task<bool> agregaMascotas_ENTAsync(UI.srvMascotas.TVET_Mascotas pMascotas) {
            return base.Channel.agregaMascotas_ENTAsync(pMascotas);
        }
        
        public bool modificaMascotas_ENT(UI.srvMascotas.TVET_Mascotas pMascotas) {
            return base.Channel.modificaMascotas_ENT(pMascotas);
        }
        
        public System.Threading.Tasks.Task<bool> modificaMascotas_ENTAsync(UI.srvMascotas.TVET_Mascotas pMascotas) {
            return base.Channel.modificaMascotas_ENTAsync(pMascotas);
        }
        
        public bool eliminaMascotas_ENT(UI.srvMascotas.TVET_Mascotas pMascotas) {
            return base.Channel.eliminaMascotas_ENT(pMascotas);
        }
        
        public System.Threading.Tasks.Task<bool> eliminaMascotas_ENTAsync(UI.srvMascotas.TVET_Mascotas pMascotas) {
            return base.Channel.eliminaMascotas_ENTAsync(pMascotas);
        }
    }
}
