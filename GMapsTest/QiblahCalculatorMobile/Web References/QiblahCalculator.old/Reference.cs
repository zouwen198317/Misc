﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.3053.
// 
namespace QiblahCalculatorMobile.QiblahCalculator.old {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="QiblahCalculatorWSSoap", Namespace="http://tempuri.org/")]
    public partial class QiblahCalculatorWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public QiblahCalculatorWS() {
            this.Url = "http://localhost:9183/QiblahCalculator.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FindQiblah", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double FindQiblah(string address, bool gpsUsed) {
            object[] results = this.Invoke("FindQiblah", new object[] {
                        address,
                        gpsUsed});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginFindQiblah(string address, bool gpsUsed, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("FindQiblah", new object[] {
                        address,
                        gpsUsed}, callback, asyncState);
        }
        
        /// <remarks/>
        public double EndFindQiblah(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FindQiblahString", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FindQiblahString(string address, bool gpsUsed) {
            object[] results = this.Invoke("FindQiblahString", new object[] {
                        address,
                        gpsUsed});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginFindQiblahString(string address, bool gpsUsed, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("FindQiblahString", new object[] {
                        address,
                        gpsUsed}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndFindQiblahString(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}
