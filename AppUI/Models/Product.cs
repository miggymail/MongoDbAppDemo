using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppUI.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ProductId")]
        [JsonProperty("ProductId")]
        [DisplayName("Id")]
        public string ProductId { get; set; }
        [Required(), MaxLength(10), MinLength(6)]
        public string SKU { get; set; }
        [DisplayName("Product Name")]
        [Required(), MaxLength(50), MinLength(5)]
        public string ProductName { get; set; }
        [Required()]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(), MaxLength(10), MinLength(3)]
        public string UOM { get; set; }
        [DisplayName("Price")]
        [Required(), Range(0.1, 100)]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
    }
}
