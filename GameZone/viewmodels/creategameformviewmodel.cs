using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace GameZone.viewmodels
{
    public class creategameformviewmodel:GameFormViewModel
    {

        [AllowedExtention(FileSettings.AllowedExtention),   
            MaxFileSize(FileSettings.MaxSizeFileInBytes)]
    
        public IFormFile cover { get; set; } = default!;
    }
}
