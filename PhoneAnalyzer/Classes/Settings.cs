﻿using System;
using System.Linq;

namespace PhoneAnalyzer.Classes
{
    public partial class Setting
    {
        private static readonly PaDbDataContext Db = DataBase.Context;
        public static string Host
        {
            get { return GetValue("Host"); }
            set { SetValue("Host", value); }
        }

        public static int Port
        {
            get
            {
                int value = 0;
                Int32.TryParse(GetValue("Port"), out value);
                return value;
            }
            set { SetValue("Port", value.ToString()); }
        }

        public static string PopHost
        {
            get { return GetValue("PopHost"); }
            set { SetValue("PopHost", value); }
        }

        public static int PopPort
        {
            get
            {
                int value = 0;
                Int32.TryParse(GetValue("PopPort"), out value);
                return value;
            }
            set { SetValue("PopPort", value.ToString()); }
        }

        public static string Login
        {
            get { return GetValue("Login"); }
            set { SetValue("Login", value); }
        }

        public static string Password
        {
            get { return GetValue("Password"); }
            set { SetValue("Password", value); }
        }

       
        
        public static string FinEmail
        {
            get { return GetValue("FinEmail"); }
            set { SetValue("FinEmail", value); }
        }




        public static decimal TariffOne
        {
            get
            {
                decimal value = 0;
                decimal.TryParse(GetValue("TariffOne"), out value);
                return value;
            }
            set { SetValue("TariffOne", value.ToString()); }
        }


        public static decimal TariffTwo
        {
            get
            {
                decimal value = 0;
                decimal.TryParse(GetValue("TariffTwo"), out value);
                return value;
            }
            set { SetValue("TariffTwo", value.ToString()); }
        }


        public static decimal TariffThree
        {
            get
            {
                decimal value = 0;
                decimal.TryParse(GetValue("TariffThree"), out value);
                return value;
            }
            set { SetValue("TariffThree", value.ToString()); }
        }





        public static decimal TaxSite
        {
            get
            {
                decimal value = 0;
                decimal.TryParse(GetValue("TaxSite"), out value);
                return value;
            }
            set { SetValue("TaxSite", value.ToString()); }
        }


        public static decimal TaxIn
        {
            get
            {
                decimal value = 0;
                decimal.TryParse(GetValue("TaxIn"), out value);
                return value;
            }
            set { SetValue("TaxIn", value.ToString()); }
        }

        public static decimal TaxOne
        {
            get
            {
                decimal value = 0;
                decimal.TryParse(GetValue("TaxOne"), out value);
                return value;
            }
            set { SetValue("TaxOne", value.ToString()); }
        }


        public static decimal TaxTwo
        {
            get
            {
                decimal value = 0;
                decimal.TryParse(GetValue("TaxTwo"), out value);
                return value;
            }
            set { SetValue("TaxTwo", value.ToString()); }
        }


        public static decimal TaxThree
        {
            get
            {
                decimal value = 0;
                decimal.TryParse(GetValue("TaxThree"), out value);
                return value;
            }
            set { SetValue("TaxThree", value.ToString()); }
        }





        private static string GetValue(string name)
        {
            var setting = Db.Settings.FirstOrDefault(p => p.Name == name);
            return (setting == null) ? "" : setting.Value;
        }

        private static void SetValue(string name, string value)
        {
            var setting = Db.Settings.FirstOrDefault(p => p.Name == name);

            if (setting == null)
            {
                setting = new Setting { Name = name, Value = value };
                Db.Settings.InsertOnSubmit(setting);
            }
            else
            {
                setting.Value = value;
            }

            Db.SubmitChanges();
        }
    }
}
