using System;
using System.Configuration;
using System.Linq;

namespace DocumentDbCourse.Configuration
{
    public interface IConfigurationReader
    {
        T GetValue<T>(string key);
    }

    public class ConfigurationReader : IConfigurationReader
    {
        public T GetValue<T>(string key)
        {
           try
           {
                var readData =  ConfigurationManager.AppSettings[key];
                    try
                    {
                        return (T)Convert.ChangeType(readData, typeof(T));
                    }
                    catch (InvalidCastException)
                    {
                        return default(T);
                    }
        
           }
           catch (Exception)
           {
                throw;
           }
        }
    }
}