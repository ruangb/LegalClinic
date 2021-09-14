using System;

namespace LC.Core.Shared.ModelViews
{
    public class PhoneView : ICloneable
    {
        public int Id { get; set; }
        public string Number { get; set; }
    
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}