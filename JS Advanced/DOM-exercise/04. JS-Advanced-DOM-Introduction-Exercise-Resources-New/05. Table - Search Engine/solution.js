function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let names = Array.from(document.querySelectorAll("tbody tr"));

      let input = document.getElementById("searchField");
      let inputText = input.value.toLowerCase();
      names.forEach((el) => {
         let text = el.textContent.toLowerCase()
         if (text.includes(inputText)) {
            el.classList.add("select");
         }
         else {
            el.classList.remove("select");
         }
      })

      input.value = '';
   }
}