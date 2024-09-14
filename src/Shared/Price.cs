using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagement.src.Shared;

public partial class Price
{
    public double ItemPrice { get; set; }
    public Currency currency { get; set; }
    public Price(double price, Currency currency)
    {
        ItemPrice = price;
        this.currency = currency;
    }
    public override string ToString()
    {
        return $"{ItemPrice} {currency}";
    }

}
