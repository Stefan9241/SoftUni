function deleteByEmail() {
    let inputText = document.querySelector('label input').value;
    let table = document.querySelectorAll('tbody tr');
    let rows = Array.from(table);

    let isDeleted = false;
    for (const row of rows) {
        let email = row.children[1].innerHTML;
        
        if(email == inputText){
            document.getElementById('result').textContent = 'Deleted.';
            isDeleted = true;
            row.remove();
        }
    }

    if(isDeleted == false){
        document.getElementById('result').textContent = 'Not found.';
    }
}