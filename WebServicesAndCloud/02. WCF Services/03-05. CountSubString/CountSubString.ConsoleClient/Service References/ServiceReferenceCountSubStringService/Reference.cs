﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CountSubString.ConsoleClient.ServiceReferenceCountSubStringService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceCountSubStringService.ICountSubStringService")]
    public interface ICountSubStringService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountSubStringService/CountSubString", ReplyAction="http://tempuri.org/ICountSubStringService/CountSubStringResponse")]
        int CountSubString(string text, string subString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountSubStringService/CountSubString", ReplyAction="http://tempuri.org/ICountSubStringService/CountSubStringResponse")]
        System.Threading.Tasks.Task<int> CountSubStringAsync(string text, string subString);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICountSubStringServiceChannel : CountSubString.ConsoleClient.ServiceReferenceCountSubStringService.ICountSubStringService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CountSubStringServiceClient : System.ServiceModel.ClientBase<CountSubString.ConsoleClient.ServiceReferenceCountSubStringService.ICountSubStringService>, CountSubString.ConsoleClient.ServiceReferenceCountSubStringService.ICountSubStringService {
        
        public CountSubStringServiceClient() {
        }
        
        public CountSubStringServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CountSubStringServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CountSubStringServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CountSubStringServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CountSubString(string text, string subString) {
            return base.Channel.CountSubString(text, subString);
        }
        
        public System.Threading.Tasks.Task<int> CountSubStringAsync(string text, string subString) {
            return base.Channel.CountSubStringAsync(text, subString);
        }
    }
}