﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace McdoCalendarCreatorNative.Config {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.0.0.0")]
    internal sealed partial class McdoParser : global::System.Configuration.ApplicationSettingsBase {
        
        private static McdoParser defaultInstance = ((McdoParser)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new McdoParser())));
        
        public static McdoParser Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Familial")]
        public string calendar {
            get {
                return ((string)(this["calendar"]));
            }
            set {
                this["calendar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4926")]
        public string EmpCode {
            get {
                return ((string)(this["EmpCode"]));
            }
            set {
                this["EmpCode"] = value;
            }
        }
    }
}
