using LC.Core.Domain;
using System;
using System.Collections.Generic;

namespace LC.Core.Shared.ModelViews
{
    /// <summary>
    /// Object used to create a new customer
    /// </summary>
    public class NewCustomer
    {
        /// <summary>
        /// Customer name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer birth date 
        /// </summary>
        /// <example>1980-01-01</example>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Customer gender
        /// </summary>
        /// <example>M</example>
        public GenderView Gender { get; set; }

        /// <summary>
        /// Customer document
        /// </summary>
        public string Document { get; set; }

        public NewAddress Address{ get; set; }
        
        public ICollection<NewPhone> Phones { get; set; }

    }
}
