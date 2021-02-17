using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contract.Slider
{
    public class CreateSlider
    {
        [FileExtensionLimitation(new string[] { "jpeg", "jpg", "png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Heading { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Text { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string BtnText { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string UrlLink { get; set; }

        public bool IsRemoved { get; set; }
    }
}
