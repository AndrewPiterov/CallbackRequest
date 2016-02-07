using CallbackRequest.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CallbackRequest.Web.ViewModels
{
    public class CallbackViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }
        [StringLength(20, MinimumLength = 6)]
        public string Phone { get; set; }

        public DateTime? CeatedAt { get; set; }


    }

    public static class Exts
    {
        public static CallbackModel ToModel(this CallbackViewModel vm)
        {
            return new CallbackModel
            {
                Name = vm.Name,
                Phone = vm.Phone,
                CreatedAt = vm.CeatedAt ?? DateTime.UtcNow
            };
        }
    }
}