namespace RamenApi.Models

{

    public class Ramen

    {

        public string Id { get; set; }

        public string Name { get; set; }

        public bool Sale { get; set; }

        public decimal Price { get; set; }

        public string Photo { get; set; }

        public List<string> Category { get; set; }

        public Ramen()

        {

            Category = new List<string>();

        }

    }

}
