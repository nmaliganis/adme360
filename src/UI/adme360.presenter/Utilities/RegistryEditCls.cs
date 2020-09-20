using System;
using Microsoft.Win32;

namespace dl.wm.presenter.Utilities
{
    public static class RegistryEditCls
    {
        public static string GetStringValue(RegistryKey hiveKey, string strSubKey, string strValue)
        {
            object objData;

            try
            {
                var localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                var subKey = localMachine.OpenSubKey(strSubKey);

                if (subKey == null)
                {
                    return null;
                }
                objData = subKey.GetValue(strValue);
                if (objData == null)
                {
                    return null;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return null;
            }

            return objData.ToString();
        }

        public static uint GetDwordValue(RegistryKey hiveKey, string strSubKey, string dwValue)
        {
            object objData;

            try
            {
                var subKey = hiveKey.OpenSubKey(strSubKey);
                if (subKey == null)
                {
                    return 0;
                }
                objData = subKey.GetValue(dwValue);
                if (objData == null)
                {
                    return 0;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return 0;
            }

            return UInt32.Parse(objData.ToString());
        }

        public static byte[] GetBinaryValue(RegistryKey hiveKey, string strSubKey, string binValue)
        {
            object objData;

            try
            {
                var subKey = hiveKey.OpenSubKey(strSubKey);
                if (subKey == null)
                {
                    return null;
                }
                objData = subKey.GetValue(binValue);
                if (objData == null)
                {
                    return null;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return null;
            }

            return (byte[])objData;
        }

        public static void SetStringValue(RegistryKey hiveKey, string strSubKey, string strValue, string strData)
        {
            try
            {
                var subKey = hiveKey.CreateSubKey(strSubKey);
                if (subKey == null)
                {
                    return;
                }
                subKey.SetValue(strValue, strData);
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return;
            }
        }

        public static void SetDwordValue(RegistryKey hiveKey, string strSubKey, string strValue, int dwData)
        {
            try
            {
                var subKey = hiveKey.CreateSubKey(strSubKey);
                if (subKey == null)
                {
                    return;
                }
                subKey.SetValue(strValue, dwData);
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return;
            }
        }

        public static void SetBinaryValue(RegistryKey hiveKey, string strSubKey, string strValue, byte[] nnData)
        {
            try
            {
                var subKey = hiveKey.CreateSubKey(strSubKey);
                if (subKey == null)
                {
                    return;
                }
                subKey.SetValue(strValue, nnData);
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return;
            }
        }

        public static void CreateSubKey(RegistryKey hiveKey, string strSubKey)
        {
            try
            {
                var subKey = hiveKey.CreateSubKey(strSubKey);
                if (subKey == null)
                {
                    return;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return;
            }
        }

        public static void DeleteSubKeyTree(RegistryKey hiveKey, string strSubKey)
        {
            try
            {
                hiveKey.DeleteSubKeyTree(strSubKey);
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return;
            }
        }

        public static void DeleteValue(RegistryKey hiveKey, string strSubKey, string strValue)
        {
            try
            {
                var subKey = hiveKey.OpenSubKey(strSubKey, true);
                if (subKey == null)
                {
                    return;
                }
                subKey.DeleteValue(strValue);
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return;
            }
        }

        public static Type GetValueType(RegistryKey hiveKey, string strSubKey, string strValue)
        {
            object objData;

            try
            {
                var subKey = hiveKey.OpenSubKey(strSubKey);
                if (subKey == null)
                {
                    return null;
                }
                objData = subKey.GetValue(strValue);
                if (objData == null)
                {
                    return null;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                return null;
            }

            return objData.GetType();
        }
    }
}
