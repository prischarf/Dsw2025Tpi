using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities;

public class Product : EntityBase
{
    public string? Sku {  get; set; }
    public string? Name { get; set; }
    public string? InternalCode { get; set; }
    public string? Description { get; set; }
    public decimal CurrentUnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
    public Product() { }
    public Product(string _sku, string _name, string? _internalCode, string? _description, decimal _currentUnitPrice, int _stockQuantity)
    {
        Sku = _sku;
        Name = _name;
        InternalCode = _internalCode;
        Description = _description;
        CurrentUnitPrice = _currentUnitPrice;
        StockQuantity = _stockQuantity;
        IsActive = true;
    }
    public bool ValidateStock(int _quantity)
    {
        return StockQuantity >= _quantity;
    }
    public void ReduceStock(int _quantity)
    {
        if (_quantity < 0) throw new InvalidOperationException("La cantidad ingresada debe ser mayor que cero.");
        if(!ValidateStock(_quantity)) throw new InvalidOperationException("No hay suficiente stock.");
        StockQuantity -= _quantity;
    }
}
