function create(words) {
   let originalDiv = document.getElementById('content');

   function reveal(ev) {
      ev.currentTarget.children[0].style.display = 'block';
   }

   for (let i = 0; i < words.length; i++) {
      let newDiv = document.createElement('div');
      let newP = document.createElement('p');
      newP.textContent = words[i];
      newP.style.display = 'none';
      newDiv.appendChild(newP);

      newDiv.addEventListener('click', reveal);

      originalDiv.appendChild(newDiv);
   }
}