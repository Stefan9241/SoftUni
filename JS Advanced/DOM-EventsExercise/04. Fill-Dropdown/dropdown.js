function addItem() {
    let html = {
        text: document.getElementById('newItemText'),
        value: document.getElementById('newItemValue'),
        menu: document.getElementById('menu')
    }

    let element = document.createElement('option');
    element.textContent = html.text.value;
    element.value = html.value.value;
    html.text.value = '';
    html.value.value = '';

    html.menu.appendChild(element);
}
