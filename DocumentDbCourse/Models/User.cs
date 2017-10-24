using Newtonsoft.Json;
using System;

namespace DocumentDbCourse.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string EmailId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }


        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string ZipCode { get; set; }

        [JsonProperty("geo")]
        public GeoLocation GeoLocation { get; set; }
    }

    public class GeoLocation
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }

    public class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string BuisinessStructure { get; set; }
    }
}