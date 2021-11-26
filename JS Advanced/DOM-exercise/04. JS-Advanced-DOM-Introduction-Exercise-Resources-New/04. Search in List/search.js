function search() {
   let towns = Array.from(document.querySelectorAll('ul li'));
   let search = document.getElementById("searchText").value;

   let matches = 0;

   towns.forEach((el) => {
      if (el.textContent.includes(search)) {
         matches++;
         el.style.fontWeight = 'bold';
         el.style.textDecoration = "underline";
      }
      else{
         el.style.fontWeight = 'normal';
         el.style.textDecoration = '';
      }
   })

   document.getElementById("result").textContent =`${matches} matches found`;
}
