namespace Store.ViewModels
{
    public class GadgetViewModel
    {
        public int GadgetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryID { get; set; }
    }
}