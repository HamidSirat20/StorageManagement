using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagement.src.Domain;

public partial class Product
{
    public void Print()
    {
        System.Console.WriteLine($"{Price}");
    }
}
