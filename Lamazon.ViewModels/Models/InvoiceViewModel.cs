﻿using Lamazon.ViewModels.Enums;

namespace Lamazon.ViewModels.Models
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public OrderViewModel Order { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public UserViewModel User { get; set; }
        public InvoiceStatusEnum InvoiceStatus { get; set; }

        public List<InvoiceLineItemViewModel> InvoiceLineItems { get; set; }
    }
}
