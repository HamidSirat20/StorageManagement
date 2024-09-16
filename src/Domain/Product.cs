using System.Diagnostics.Metrics;
using System.Text;
using StorageManagement.src.Shared;

namespace StorageManagement.src.Domain;

public partial class Product
{
    private int _id;
    private string _name;
    private string? _description;
    private static int _thresholdInStock = 4;

    public int AmountInStock { get; private set; }
    public bool IsAmountBelowLimit { get; private set; }
    public UnitEnum UnitEnum { get; set; }
    public Price Price { get; set; }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value == null)
            {
                _name = string.Empty;
            }
            else
            {
                _name = value.Length > 40 ? value[..40] : value;
            }
        }
    }
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            if (value == null)
            {
                _description = string.Empty;
            }
            else
            {
                _description = value.Length > 250 ? value[..250] : value;
            }
        }
    }
    public static void SetTheThreshold(int threshold)
    {
        if (threshold > 0)
        {
            _thresholdInStock = threshold;
        }
    }
    public Product(int id, string name)
    {
        _id = id;
        _name = name;
    }
    public Product(int id, string name, string? description, UnitEnum unit, int maxAmountStock, Price price)
    : this(id, name)
    {
        _description = description;
        UnitEnum = unit;
        AmountInStock = maxAmountStock;
        Price = price;
        RefillStock();
    }

    public void IncreaseStock()
    {
        AmountInStock++;
    }
    public void UseProduct(int item)
    {
        if (item < AmountInStock)
        {
            AmountInStock -= item;
        }
        else if (item > AmountInStock & AmountInStock > 0)
        {
            Log($"Not enough {_name} in stock, only {AmountInStock} left.");
            RefillStock();
            AmountInStock = 0;
        }
        else if (item == AmountInStock)
        {
            Log($"Zero {_name} left. Refill!");
            RefillStock();
            AmountInStock = 0;
        }
        else
        {
            RefillStock();
            Log($"There is {AmountInStock} in stock left! Refill! ");
        }

    }
    public void Decrease(int amount, string reason)
    {
        if (amount <= AmountInStock)
        {
            AmountInStock -= amount;
        }
    }

    private void Log(string str)
    {
        //In the future if we want to write to a file, only need to change here for all
        System.Console.WriteLine(str);
    }

    private void RefillStock()
    {
        if (AmountInStock < _thresholdInStock)
        {
            IsAmountBelowLimit = true;
        }
    }

    public void ProductDetails()
    {
        System.Console.WriteLine(($"Id: {_id} and name: {_name} Amount: {AmountInStock} and description: {_description}, price{Price}"));
    }

    public string ProductFullDescriptions()
    {
        StringBuilder sb = new();
        sb.Append($"Id: {_id},name: {_name},desc: {_description}, amount: {AmountInStock}, price: {Price.ToString()}");
        if (IsAmountBelowLimit)
        {
            sb.Append("\nLow stock! Refill");
        }
        return sb.ToString();
    }


}
