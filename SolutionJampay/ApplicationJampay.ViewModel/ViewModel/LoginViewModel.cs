﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationJampay.Model.DAL;
using ApplicationJampay.Model.DAL.Usager;
using ApplicationJampay.Model.Service;
using ApplicationJampay.ViewModel.Command;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand LoginCommand { get; private set; }
        private UserBusinessLayer _userBusinessLayer;


        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(() => Login(), o => true);
            _userBusinessLayer = new UserBusinessLayer();            
        }

        private string _matricule;
        public string Matricule
        {
            get { return _matricule; }
            set
            {
                _matricule = value;
                OnPropertyChanged(nameof(Matricule));
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private SecureString _password;
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        

        public string SecureStringToSHA256(SecureString secureString)
        {
            IntPtr intPtr = IntPtr.Zero;

            try
            {
                intPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                string clearPassword = Marshal.PtrToStringUni(intPtr);

                using(SHA256 hash = SHA256Managed.Create())
                {
                    Encoding encoding = Encoding.UTF8;
                    StringBuilder finalHash = new StringBuilder();

                    byte[] result = hash.ComputeHash(encoding.GetBytes(clearPassword));

                    foreach (byte theByte in result)
                    {
                        finalHash.Append(theByte.ToString("x2"));
                    }

                    return finalHash.ToString();

                }
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
            }
        }


        public void Login()
        {
            try
            {
                string role = _userBusinessLayer.GetUser(Matricule, SecureStringToSHA256(Password));

                switch(role)
                {
                    case "Gérant":
                        DialogService.ShowGerantWindow();
                        break;

                    case "Caissier":
                        DialogService.ShowCaissierWindow();
                        break;
                }
                                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


       
    }
}
