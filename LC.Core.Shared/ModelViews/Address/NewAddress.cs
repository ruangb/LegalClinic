namespace LC.Core.Shared.ModelViews.Address
{
    public class NewAddress
    {
        ///<example>01010555</example>
        public string ZipCode { get; set; }

        ///<example>SP</example>
        public StateView State { get; set; }

        ///<example>Santo André</example>
        public string City { get; set; }

        ///<example>Rua 10 de Outubro</example>
        public string PublicPlace { get; set; }

        ///<example>30</example>
        public string Number { get; set; }

        ///<example>Apto. 22</example>
        public string Complement { get; set; }
    }
}