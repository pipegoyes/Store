using System;
using System.Collections.Generic;

namespace Store.Model.Dto
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual List<Gadget> Gadgets { get; set; }

        public Category()
        {
            DateCreated = DateTime.Now;
        }
    }
}