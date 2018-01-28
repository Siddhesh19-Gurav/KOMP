using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenOnMyPlate.Classes
{
    public class OrderList
    {
        public List<OrderDTO> orders { get; set; }        
    }

    public class OrderDTO
    {
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetailList { get; set; }
        public Payment payment { get; set; }
    }

    //Summary with price date product name in confirmation page

    public class RequestSummary
    {
        public int orderId { get; set; }
        public string productDetails { get; set; }
        public Decimal  subTotal { get; set; }
        public Decimal deliveryCharges { get; set; }
        public Decimal transCharges { get; set; }
        public Decimal grandTotal { get; set; }
        public int nonCustomized { get; set; }
        public int IsTiffin { get; set; }
        public List<OrderedItems> orderedItems { get; set; }        
    }

    
    public class OrderedItems
    {   
        public string ProductId {get;set;}
        public string ProductName {get;set;}
        public string Price {get;set;}
        public string DeliverDate {get;set;}

    }


    public class JobPostDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Phone { get; set; }        
        public string email { get; set; }        
        public string CategoryName { get; set; }
        public string CVPath { get; set; }
    }

    public class PaymentResponse
    {
        public string RequestId { get; set; }//OrderId
        public string PaymentDone { get; set; }
        public string PaymentMethod { get; set; }
        public string customerId { get; set; }
        
    }
}