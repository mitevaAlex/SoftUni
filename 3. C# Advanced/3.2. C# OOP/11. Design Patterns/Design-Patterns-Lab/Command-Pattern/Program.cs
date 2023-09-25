using System;

namespace Command_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Phone", 500);

            Execute(product, modifyPrice, new ProductCommand(product, PriceActionEnum.Increase, 100));
            Execute(product, modifyPrice, new ProductCommand(product, PriceActionEnum.Increase, 50));
            Execute(product, modifyPrice, new ProductCommand(product, PriceActionEnum.Decrease, 25));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
