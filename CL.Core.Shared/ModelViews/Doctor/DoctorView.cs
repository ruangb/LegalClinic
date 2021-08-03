using System.Collections.Generic;

namespace LC.Core.Shared.ModelViews
{
    public class DoctorView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CRM { get; set; }
        public ICollection<SpecialtyView> Specialties { get; set; }
    }
}