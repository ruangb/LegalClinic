using System.Collections.Generic;

namespace LC.Core
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CRM { get; set; }
        public ICollection<Specialty> Specialties { get; set; }
    }
}