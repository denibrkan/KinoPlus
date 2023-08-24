﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinoPlus.Common.Resources.Strings {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KinoPlus.Common.Resources.Strings.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Greška prilikom učitavanja. Nastavite dalje sa radom..
        /// </summary>
        public static string LoadingError {
            get {
                return ResourceManager.GetString("LoadingError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pogrešno korisničko ime ili password.
        /// </summary>
        public static string LoginError {
            get {
                return ResourceManager.GetString("LoginError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lozinka je obavezno polje.
        /// </summary>
        public static string PasswordRequired {
            get {
                return ResourceManager.GetString("PasswordRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nije pronađen niti jedan odabrani dan u sedmici za vremenski interval..
        /// </summary>
        public static string ProjectionDatesEmptyError {
            get {
                return ResourceManager.GetString("ProjectionDatesEmptyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Postoji vremensko i lokacijsko preklapanje sa postojećim projekcijama. 
        ///
        ///Obratite pažnju na odabrane lokacije i dvorane projekcije. 
        ///
        ///Napomena: Obavezni razmak između projekcija je 15 minuta!.
        /// </summary>
        public static string ProjectionOverlapError {
            get {
                return ResourceManager.GetString("ProjectionOverlapError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uspješna registracija.
        /// </summary>
        public static string RegistrationSuccess {
            get {
                return ResourceManager.GetString("RegistrationSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Obavezno polje.
        /// </summary>
        public static string RequiredField {
            get {
                return ResourceManager.GetString("RequiredField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Korisničko ime već postoji.
        /// </summary>
        public static string UsernameExists {
            get {
                return ResourceManager.GetString("UsernameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Korisničko ime je obavezno polje.
        /// </summary>
        public static string UsernameRequired {
            get {
                return ResourceManager.GetString("UsernameRequired", resourceCulture);
            }
        }
    }
}
