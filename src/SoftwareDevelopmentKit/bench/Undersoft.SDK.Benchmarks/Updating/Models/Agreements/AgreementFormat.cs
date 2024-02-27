namespace Undersoft.SDK.Benchmarks.Updating.Models.Agreements
{
    public class AgreementFormat : Identifiable
    {
        public string Name { get; set; }

        public virtual Agreements Agreements { get; } = new Agreements();
    }


}
