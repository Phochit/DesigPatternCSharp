using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public abstract class OrderProcessor
    {
        // Template Method
        public void ProcessOrder()
        {
            SelectItems();
            MakePayment();
            DeliverOrder();
        }

        // Steps to be implemented by subclasses
        protected abstract void SelectItems();
        protected abstract void MakePayment();
        protected abstract void DeliverOrder();
    }

    // Concrete Class
    public class OnlinePaymentOrder : OrderProcessor
    {
        protected override void SelectItems()
        {
            Console.WriteLine("Items selected from the online catalog.");
        }

        protected override void MakePayment()
        {
            Console.WriteLine("Payment processed using an online payment gateway.");
        }

        protected override void DeliverOrder()
        {
            Console.WriteLine("Order delivered via email with a download link.");
        }
    }

    // Concrete Class
    public class CashOnDeliveryOrder : OrderProcessor
    {
        protected override void SelectItems()
        {
            Console.WriteLine("Items selected from the online catalog.");
        }

        protected override void MakePayment()
        {
            Console.WriteLine("Payment will be collected at the time of delivery.");
        }

        protected override void DeliverOrder()
        {
            Console.WriteLine("Order shipped and will be delivered to the customer's address.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing Online Payment Order:");
            OrderProcessor onlineOrder = new OnlinePaymentOrder();
            onlineOrder.ProcessOrder();

            Console.WriteLine("\nProcessing Cash on Delivery Order:");
            OrderProcessor codOrder = new CashOnDeliveryOrder();
            codOrder.ProcessOrder();
        }
    }
}
