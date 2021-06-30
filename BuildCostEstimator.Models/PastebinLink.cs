﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.Models.CustomValidations;

namespace BuildCostEstimator.Models
{
    public class PastebinLink
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Pastebin Link")]
        [Required(ErrorMessage = "Please enter a pastebin link.")]
        [Url, ValidPastebinLinkFormat]
        [MinLength(28)]
        [MaxLength(29)] // Length of "https://pastebin.com/FWxkVUqG"
        public string PastebinUrl { get; set; }
    }
}
