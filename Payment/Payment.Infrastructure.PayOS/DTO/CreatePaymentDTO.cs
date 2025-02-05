﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.PayOS.DTO
{
    public class CreatePaymentDTO
    {
        public int RequiredAmount { get; set; }
        public string Content { get; set; }
        public long OrderCode { get; set; }
    }
}
