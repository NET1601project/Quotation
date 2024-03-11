﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateQuoteV2
    {
        [Required]

        public Guid ProjectID { get; set; }

        public List<CreateQuoteDetail> CreateQuoteDetails { get; set; }
    }
}
