function solve() {
   let addButtons = Array.from(document.getElementsByClassName('add-product'));
   addButtons.forEach(x => x.addEventListener('click', addProduct));

   let checkoutButton = document.getElementsByClassName('checkout')[0];
   checkoutButton.addEventListener('click', checkout);

   let totalPrice = 0;
   let products = [];

   function addProduct(event) {
      let productEl = event.target.parentElement.parentElement;
      let productName = productEl.getElementsByClassName('product-title')[0].textContent;
      if (!products.includes(productName)) {
         products.push(productName);
      }

      let productPrice = Number(productEl.getElementsByClassName('product-line-price')[0].textContent);
      totalPrice += productPrice;
      let cart = document.getElementsByTagName('textarea')[0];
      cart.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`
   }

   function checkout(event) {
      document.getElementsByTagName('textarea')[0].textContent += `You bought ${products.join(', ')} for ${totalPrice.toFixed(2)}.`;
      let buttons = Array.from(document.getElementsByTagName('button'));
      buttons.forEach(x => x.disabled = true);
   }
}