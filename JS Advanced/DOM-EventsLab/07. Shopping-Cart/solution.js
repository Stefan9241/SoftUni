function solve() {
   document.getElementsByClassName('shopping-cart')[0].addEventListener('click', onClick);
   document.getElementsByClassName('checkout')[0].addEventListener('click', checkout);

   let output = document.getElementsByTagName('textarea')[0];

   const cart = [];
   function onClick(ev) {
      if (ev.target.tagName == 'BUTTON' && ev.target.classList.contains('add-product')) {
         const product = ev.target.parentNode.parentNode;
         let name = product.querySelector('.product-title').textContent;
         let price = Number(product.querySelector('.product-line-price').textContent);

         cart.push({
            name,
            price
         })

         output.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
      }
   }


   function checkout(ev) {
      let products = new Set();

      cart.forEach(p => products.add(p.name));

      let total = cart.reduce((el, curr) => el + curr.price, 0);

      output.value += `You bought ${Array.from(products.keys()).join(', ')} for ${total.toFixed(2)}.`;

      document.getElementsByClassName('shopping-cart')[0].removeEventListener('click', onClick);
      document.getElementsByClassName('checkout')[0].removeEventListener('click', checkout);
   }
}