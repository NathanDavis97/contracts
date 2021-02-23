namespace contracts.Models
{
    public class Job
    {
        
        public Job()
        {

        }
        public Job(string title, float pay)
        {
      Title = title;
      Pay = pay;

    }
    public string Title { get; set;}
    public float Pay { get; set;}
    public int Id { get; set; }

    }
}