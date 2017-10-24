using System;
using System.Configuration;
using System.Linq;

namespace DocumentDbCourse.Configuration
{
    public interface IConfigurationReader<T> 
    {
        T GetValue(string key);
    }

    public class ConfigurationReader<T> : IConfigurationReader<T>
    {
        public T GetValue(string key)
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