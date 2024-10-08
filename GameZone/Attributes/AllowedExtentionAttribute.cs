﻿using System.Reflection.Metadata.Ecma335;

namespace GameZone.Attributes
{
    public class AllowedExtentionAttribute : ValidationAttribute
    {
        private readonly string _allowedExtentions;
        public AllowedExtentionAttribute(string allowedExtentions)
        {
            _allowedExtentions= allowedExtentions;

        }
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {

                var extention = Path.GetExtension(file.FileName);

                var isAllowed = _allowedExtentions.Split(separator:',').Contains(extention,StringComparer.OrdinalIgnoreCase);
                if (!isAllowed)
                {
                    return new ValidationResult(errorMessage: $"only{_allowedExtentions}are allowed");
                        }
                
            }
            return ValidationResult.Success;
        }
        
    }
}
