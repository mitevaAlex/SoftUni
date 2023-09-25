using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Pattern
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceActionEnum priceAction;
        private readonly int amount;

        public ProductCommand(Product product, PriceActionEnum priceAction, int amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }

        public void ExecuteAction()
        {
            switch (this.priceAction)
            {
                case PriceActionEnum.Increase:
                    this.product.IncreasePrice(this.amount);
                    break;
                case PriceActionEnum.Decrease:
                    this.product.DecreasePrice(this.amount);
                    break;
            }
        }
    }
}
