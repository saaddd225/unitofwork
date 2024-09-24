using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uniofwork.Models
{
    public class Orders
    {
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Product { get; set; }
    public Customer Customer { get; set; }
    }
}