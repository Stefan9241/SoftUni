function extractText() {
    let items = Array.from(document.getElementById('items').children);

    let result = [];

    for (const iterator of items) {
        result.push(iterator.textContent);
    }

    document.getElementById('result').textContent = result.join('\n');
}