﻿using System.Collections.Generic;

namespace LC.Core.Shared.ModelViews
{
    public class NewDoctor
    {
        public string Name { get; set; }
        public string CRM { get; set; }
        public ICollection<SpecialtyReference> Specialties { get; set; }
    }
}