using System.Collections.Generic;

namespace LC.Core.Domain
{
    public class Specialty
    {
        public int Id{ get; set; } 
        public string Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}