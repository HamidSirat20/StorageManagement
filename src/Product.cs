using System.Text;

namespace StorageManagement.src;

public class Product
{
    private int _id;
    private string _name;
    private string? _description;
    private int _maxAmountStock = 0;

    public int AmountInStock { get; private set; }
    public bool IsAmountBelowLimit { get; private set; }
    public UnitEnum UnitEnum { get; set; }

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
    public Product(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public void IncreaseStock()
    {
        AmountInStock++;
    }
    public void UseProduct(int item)
    {
        if (item <= AmountInStock)
        {
            AmountInStock -= item;
        }
        else
        {
            RefillStock();
            Log($"There is {AmountInStock} in stock left! {ProductDetails()}");
        }

    }
    private void Decrease(int amount, string reason)
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
        if (AmountInStock < _maxAmountStock)
        {
            IsAmountBelowLimit = true;
        }
    }

    private string ProductDetails()
    {
        return ($"Id: {_id} and name: {_name} Amount: {AmountInStock} and description: {_description}");
    }

    public string ProductFullDescriptions()
    {
        StringBuilder sb = new();
        sb.Append($"{_id} {_name} {_description} {AmountInStock}");
        if (IsAmountBelowLimit)
        {
            sb.Append("\nLow stock! Refill");
        }
        return sb.ToString();
    }


}
