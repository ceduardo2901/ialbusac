﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ialbusac.Sunat1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.sunat.gob.pe", ConfigurationName="Sunat1.billService")]
    public interface billService {
        
        // CODEGEN: El parámetro 'status' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="status")]
        ialbusac.Sunat1.getStatusResponse getStatus(ialbusac.Sunat1.getStatusRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<ialbusac.Sunat1.getStatusResponse> getStatusAsync(ialbusac.Sunat1.getStatusRequest request);
        
        // CODEGEN: El parámetro 'applicationResponse' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendBill", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="applicationResponse")]
        ialbusac.Sunat1.sendBillResponse sendBill(ialbusac.Sunat1.sendBillRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendBill", ReplyAction="*")]
        System.Threading.Tasks.Task<ialbusac.Sunat1.sendBillResponse> sendBillAsync(ialbusac.Sunat1.sendBillRequest request);
        
        // CODEGEN: El parámetro 'ticket' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendPack", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="ticket")]
        ialbusac.Sunat1.sendPackResponse sendPack(ialbusac.Sunat1.sendPackRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendPack", ReplyAction="*")]
        System.Threading.Tasks.Task<ialbusac.Sunat1.sendPackResponse> sendPackAsync(ialbusac.Sunat1.sendPackRequest request);
        
        // CODEGEN: El parámetro 'ticket' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendSummary", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="ticket")]
        ialbusac.Sunat1.sendSummaryResponse sendSummary(ialbusac.Sunat1.sendSummaryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:sendSummary", ReplyAction="*")]
        System.Threading.Tasks.Task<ialbusac.Sunat1.sendSummaryResponse> sendSummaryAsync(ialbusac.Sunat1.sendSummaryRequest request);
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.sunat.gob.pe")]
    public partial class statusResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private byte[] contentField;
        
        private string statusCodeField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", Order=0)]
        public byte[] content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
                this.RaisePropertyChanged("content");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string statusCode {
            get {
                return this.statusCodeField;
            }
            set {
                this.statusCodeField = value;
                this.RaisePropertyChanged("statusCode");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatus", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ticket;
        
        public getStatusRequest() {
        }
        
        public getStatusRequest(string ticket) {
            this.ticket = ticket;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatusResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ialbusac.Sunat1.statusResponse status;
        
        public getStatusResponse() {
        }
        
        public getStatusResponse(ialbusac.Sunat1.statusResponse status) {
            this.status = status;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendBill", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendBillRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] contentFile;
        
        public sendBillRequest() {
        }
        
        public sendBillRequest(string fileName, byte[] contentFile) {
            this.fileName = fileName;
            this.contentFile = contentFile;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendBillResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendBillResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] applicationResponse;
        
        public sendBillResponse() {
        }
        
        public sendBillResponse(byte[] applicationResponse) {
            this.applicationResponse = applicationResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendPack", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendPackRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] contentFile;
        
        public sendPackRequest() {
        }
        
        public sendPackRequest(string fileName, byte[] contentFile) {
            this.fileName = fileName;
            this.contentFile = contentFile;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendPackResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendPackResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ticket;
        
        public sendPackResponse() {
        }
        
        public sendPackResponse(string ticket) {
            this.ticket = ticket;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendSummary", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendSummaryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] contentFile;
        
        public sendSummaryRequest() {
        }
        
        public sendSummaryRequest(string fileName, byte[] contentFile) {
            this.fileName = fileName;
            this.contentFile = contentFile;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendSummaryResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class sendSummaryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ticket;
        
        public sendSummaryResponse() {
        }
        
        public sendSummaryResponse(string ticket) {
            this.ticket = ticket;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface billServiceChannel : ialbusac.Sunat1.billService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class billServiceClient : System.ServiceModel.ClientBase<ialbusac.Sunat1.billService>, ialbusac.Sunat1.billService {
        
        public billServiceClient() {
        }
        
        public billServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public billServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public billServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public billServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ialbusac.Sunat1.getStatusResponse ialbusac.Sunat1.billService.getStatus(ialbusac.Sunat1.getStatusRequest request) {
            return base.Channel.getStatus(request);
        }
        
        public ialbusac.Sunat1.statusResponse getStatus(string ticket) {
            ialbusac.Sunat1.getStatusRequest inValue = new ialbusac.Sunat1.getStatusRequest();
            inValue.ticket = ticket;
            ialbusac.Sunat1.getStatusResponse retVal = ((ialbusac.Sunat1.billService)(this)).getStatus(inValue);
            return retVal.status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ialbusac.Sunat1.getStatusResponse> ialbusac.Sunat1.billService.getStatusAsync(ialbusac.Sunat1.getStatusRequest request) {
            return base.Channel.getStatusAsync(request);
        }
        
        public System.Threading.Tasks.Task<ialbusac.Sunat1.getStatusResponse> getStatusAsync(string ticket) {
            ialbusac.Sunat1.getStatusRequest inValue = new ialbusac.Sunat1.getStatusRequest();
            inValue.ticket = ticket;
            return ((ialbusac.Sunat1.billService)(this)).getStatusAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ialbusac.Sunat1.sendBillResponse ialbusac.Sunat1.billService.sendBill(ialbusac.Sunat1.sendBillRequest request) {
            return base.Channel.sendBill(request);
        }
        
        public byte[] sendBill(string fileName, byte[] contentFile) {
            ialbusac.Sunat1.sendBillRequest inValue = new ialbusac.Sunat1.sendBillRequest();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            ialbusac.Sunat1.sendBillResponse retVal = ((ialbusac.Sunat1.billService)(this)).sendBill(inValue);
            return retVal.applicationResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ialbusac.Sunat1.sendBillResponse> ialbusac.Sunat1.billService.sendBillAsync(ialbusac.Sunat1.sendBillRequest request) {
            return base.Channel.sendBillAsync(request);
        }
        
        public System.Threading.Tasks.Task<ialbusac.Sunat1.sendBillResponse> sendBillAsync(string fileName, byte[] contentFile) {
            ialbusac.Sunat1.sendBillRequest inValue = new ialbusac.Sunat1.sendBillRequest();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            return ((ialbusac.Sunat1.billService)(this)).sendBillAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ialbusac.Sunat1.sendPackResponse ialbusac.Sunat1.billService.sendPack(ialbusac.Sunat1.sendPackRequest request) {
            return base.Channel.sendPack(request);
        }
        
        public string sendPack(string fileName, byte[] contentFile) {
            ialbusac.Sunat1.sendPackRequest inValue = new ialbusac.Sunat1.sendPackRequest();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            ialbusac.Sunat1.sendPackResponse retVal = ((ialbusac.Sunat1.billService)(this)).sendPack(inValue);
            return retVal.ticket;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ialbusac.Sunat1.sendPackResponse> ialbusac.Sunat1.billService.sendPackAsync(ialbusac.Sunat1.sendPackRequest request) {
            return base.Channel.sendPackAsync(request);
        }
        
        public System.Threading.Tasks.Task<ialbusac.Sunat1.sendPackResponse> sendPackAsync(string fileName, byte[] contentFile) {
            ialbusac.Sunat1.sendPackRequest inValue = new ialbusac.Sunat1.sendPackRequest();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            return ((ialbusac.Sunat1.billService)(this)).sendPackAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ialbusac.Sunat1.sendSummaryResponse ialbusac.Sunat1.billService.sendSummary(ialbusac.Sunat1.sendSummaryRequest request) {
            return base.Channel.sendSummary(request);
        }
        
        public string sendSummary(string fileName, byte[] contentFile) {
            ialbusac.Sunat1.sendSummaryRequest inValue = new ialbusac.Sunat1.sendSummaryRequest();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            ialbusac.Sunat1.sendSummaryResponse retVal = ((ialbusac.Sunat1.billService)(this)).sendSummary(inValue);
            return retVal.ticket;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ialbusac.Sunat1.sendSummaryResponse> ialbusac.Sunat1.billService.sendSummaryAsync(ialbusac.Sunat1.sendSummaryRequest request) {
            return base.Channel.sendSummaryAsync(request);
        }
        
        public System.Threading.Tasks.Task<ialbusac.Sunat1.sendSummaryResponse> sendSummaryAsync(string fileName, byte[] contentFile) {
            ialbusac.Sunat1.sendSummaryRequest inValue = new ialbusac.Sunat1.sendSummaryRequest();
            inValue.fileName = fileName;
            inValue.contentFile = contentFile;
            return ((ialbusac.Sunat1.billService)(this)).sendSummaryAsync(inValue);
        }
    }
}
