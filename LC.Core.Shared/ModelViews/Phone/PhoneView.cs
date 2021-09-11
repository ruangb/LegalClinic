namespace LC.Core.Shared.ModelViews
{
    public class PhoneView
    {
        public int Id { get; set; }
        public string Number { get; set; }
    
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}