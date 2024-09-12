using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DTOLayer.DTOs.CargoDetailDTO
{
    public class CreateCargoDetailDTO
    {
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public string CompanyId { get; set; }
    }
}
