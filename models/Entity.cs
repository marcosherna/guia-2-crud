using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guia_2.models
{
    public class Entity { 
        public string Id { get; set; } = "";
        
        public bool GenerateId(){
            this.Id = $"{Guid.NewGuid()}";
            return (this.Id != "");
        }
    }
}