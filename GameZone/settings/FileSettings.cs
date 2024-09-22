using static System.Net.Mime.MediaTypeNames;

namespace GameZone.settings
{
    public static class FileSettings
    {
        public const string Imagespath = "/assets/images/games";
        public const string AllowedExtention = ".jpg,.jpeg,.png";
        public const int MaxSizeFileInMB = 3 ;
        public const int MaxSizeFileInBytes = MaxSizeFileInMB*1024*1024;
    }
}
