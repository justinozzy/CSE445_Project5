﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yarramsetti_A6_Components.SOAPServicesLikhit {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SOAPServicesLikhit.ISOAPServicesLikhit")]
    public interface ISOAPServicesLikhit {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISOAPServicesLikhit/NewsFocus", ReplyAction="http://tempuri.org/ISOAPServicesLikhit/NewsFocusResponse")]
        string[] NewsFocus(string[] topics);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISOAPServicesLikhit/NewsFocus", ReplyAction="http://tempuri.org/ISOAPServicesLikhit/NewsFocusResponse")]
        System.Threading.Tasks.Task<string[]> NewsFocusAsync(string[] topics);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISOAPServicesLikhit/WebDownload", ReplyAction="http://tempuri.org/ISOAPServicesLikhit/WebDownloadResponse")]
        string WebDownload(string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISOAPServicesLikhit/WebDownload", ReplyAction="http://tempuri.org/ISOAPServicesLikhit/WebDownloadResponse")]
        System.Threading.Tasks.Task<string> WebDownloadAsync(string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISOAPServicesLikhit/RegisterUser", ReplyAction="http://tempuri.org/ISOAPServicesLikhit/RegisterUserResponse")]
        string RegisterUser(string username, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISOAPServicesLikhit/RegisterUser", ReplyAction="http://tempuri.org/ISOAPServicesLikhit/RegisterUserResponse")]
        System.Threading.Tasks.Task<string> RegisterUserAsync(string username, string email, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISOAPServicesLikhitChannel : Yarramsetti_A6_Components.SOAPServicesLikhit.ISOAPServicesLikhit, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SOAPServicesLikhitClient : System.ServiceModel.ClientBase<Yarramsetti_A6_Components.SOAPServicesLikhit.ISOAPServicesLikhit>, Yarramsetti_A6_Components.SOAPServicesLikhit.ISOAPServicesLikhit {
        
        public SOAPServicesLikhitClient() {
        }
        
        public SOAPServicesLikhitClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SOAPServicesLikhitClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SOAPServicesLikhitClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SOAPServicesLikhitClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] NewsFocus(string[] topics) {
            return base.Channel.NewsFocus(topics);
        }
        
        public System.Threading.Tasks.Task<string[]> NewsFocusAsync(string[] topics) {
            return base.Channel.NewsFocusAsync(topics);
        }
        
        public string WebDownload(string url) {
            return base.Channel.WebDownload(url);
        }
        
        public System.Threading.Tasks.Task<string> WebDownloadAsync(string url) {
            return base.Channel.WebDownloadAsync(url);
        }
        
        public string RegisterUser(string username, string email, string password) {
            return base.Channel.RegisterUser(username, email, password);
        }
        
        public System.Threading.Tasks.Task<string> RegisterUserAsync(string username, string email, string password) {
            return base.Channel.RegisterUserAsync(username, email, password);
        }
    }
}