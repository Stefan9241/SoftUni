function focused() {
   let divs =  Array.from(document.querySelectorAll('div')[0].children);
   
   for (const div of divs) {
       div.children[1].addEventListener('focus', onClick);
       div.children[1].addEventListener('blur', onBlur);
   }

   function onClick(ev){
       ev.target.parentNode.classList.add('focused');
   }

   function onBlur(ev){
    ev.target.parentNode.classList.remove('focused');
}
}