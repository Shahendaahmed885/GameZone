namespace GameZone.viewmodels
{
    public class GameFormViewModel
    {

        [MaxLength(length: 250)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int categoryid { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]
        public List<int> selecteddevices { get; set; } = default!;
        public IEnumerable<SelectListItem> devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(length: 2500)]
        public string description { get; set; } = string.Empty;
    }
}
