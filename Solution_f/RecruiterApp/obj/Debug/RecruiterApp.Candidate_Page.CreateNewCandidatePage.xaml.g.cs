//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecruiterApp {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class CreateNewCandidatePage : global::Xamarin.Forms.ContentPage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidateFirstName;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidateLastName;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidateEmail;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidatePhone;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidateStreet;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidateStreet2;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidateCity;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidateState;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry candidateZip;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Picker PickerPositions;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Editor positionName;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(CreateNewCandidatePage));
            candidateFirstName = this.FindByName<global::Xamarin.Forms.Entry>("candidateFirstName");
            candidateLastName = this.FindByName<global::Xamarin.Forms.Entry>("candidateLastName");
            candidateEmail = this.FindByName<global::Xamarin.Forms.Entry>("candidateEmail");
            candidatePhone = this.FindByName<global::Xamarin.Forms.Entry>("candidatePhone");
            candidateStreet = this.FindByName<global::Xamarin.Forms.Entry>("candidateStreet");
            candidateStreet2 = this.FindByName<global::Xamarin.Forms.Entry>("candidateStreet2");
            candidateCity = this.FindByName<global::Xamarin.Forms.Entry>("candidateCity");
            candidateState = this.FindByName<global::Xamarin.Forms.Entry>("candidateState");
            candidateZip = this.FindByName<global::Xamarin.Forms.Entry>("candidateZip");
            PickerPositions = this.FindByName<global::Xamarin.Forms.Picker>("PickerPositions");
            positionName = this.FindByName<global::Xamarin.Forms.Editor>("positionName");
        }
    }
}
