namespace contracts.Models
{
    public class Contractor
    {
        public Contractor()
        {

        }
        public Contractor(string name, int yearsInProf)
        {
      Name = name;
      YearsInProf = yearsInProf;

    }
    public string Name { get; set;}
    public int YearsInProf { get; set;}
    public int Id { get; set; }

  }
    public class ContractViewModel : Contractor
  {
    public int ContractId { get; set; }
  }
}
