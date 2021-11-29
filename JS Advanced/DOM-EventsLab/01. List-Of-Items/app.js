function addItem() {
    let inputText = document.getElementById('newItemText').value;

    let liElement = document.createElement('li');

    liElement.textContent = inputText;

    let items = document.querySelectorAll('ul');
    items[0].appendChild(liElement);

    document.getElementById('newItemText').value = '';
}