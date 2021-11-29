function addItem() {
    let inputText = document.getElementById('newItemText').value;

    let liElement = document.createElement('li');
    liElement.textContent = inputText;

    let hrefElement = document.createElement('a');
    hrefElement.textContent = '[Delete]';
    hrefElement.href = '#';
    hrefElement.addEventListener('click', onClick);

    function onClick(ev) {
        ev.target.parentNode.remove();
    }

    liElement.appendChild(hrefElement);

    let items = document.querySelectorAll('ul');
    items[0].appendChild(liElement);

    document.getElementById('newItemText').value = '';


}