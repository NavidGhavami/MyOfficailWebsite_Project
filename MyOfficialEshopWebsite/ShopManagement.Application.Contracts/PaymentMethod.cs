using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Application.Contract
{
    public class PaymentMethod
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private PaymentMethod(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static List<PaymentMethod> GetList()
        {
            return new List<PaymentMethod>
            {
                new PaymentMethod(1,
                    "پرداخت نقدی",
                    "این روش پرداخت به صورت نقدی درب منزل انجام می گیرد و فعلا فقط برای شهرستان بوکان امکان پذیر می باشد. "),
                new PaymentMethod(2,
                    "پرداخت اینترنتی با استفاده از کارت های شتاب بانکی",
                    "با هر نوع کارت شتاب بانکی می توانید خرید خود را آنلاین، از طریق درگاه پرداخت امن زرین پال انجام دهید ."),

            };
        }

        public PaymentMethod GetBy(long id)
        {
            return GetList().FirstOrDefault(x => x.Id == id);
        }
    }
}
