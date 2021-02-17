using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Contract.Product
{
    public class EditProduct:CreateProduct
    {
        public long Id { get; set; }
    }
}
