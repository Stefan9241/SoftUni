function sumTable() {
    let rows = document.querySelectorAll('table tr');

    let sum = 0;

    for (let index = 1; index < rows.length - 1; index++) {
        const cell = rows[index].lastElementChild;
        sum += Number(cell.textContent);
    }

    document.getElementById('sum').textContent = sum;
}