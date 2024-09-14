using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagement.src.Domain;

public class Order
{
    public int Id { get; private set; }
    public DateTime OrderDate { get; private set; }
    public List<OrderItem> OrderItems { get; set; }
    public bool OrderStatus { get; set; } = false;
}
