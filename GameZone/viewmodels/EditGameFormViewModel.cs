using GameZone.Attributes;

namespace GameZone.viewmodels
{
    public class EditGameFormViewModel:GameFormViewModel
    {
        public int Id { get; set; }

        public string? currentcover{ get; set; }


        [ AllowedExtention(FileSettings.AllowedExtention),   
            MaxFileSize(FileSettings.MaxSizeFileInBytes)]
    
        public IFormFile? cover { get; set; } = default!;
    }
}
