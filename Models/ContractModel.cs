﻿using System.ComponentModel.DataAnnotations;

namespace xRootServices.Models
{
    public class ContractModel
    {
        [Required]
        public string? Name { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Description { get; set; }


    }
}
