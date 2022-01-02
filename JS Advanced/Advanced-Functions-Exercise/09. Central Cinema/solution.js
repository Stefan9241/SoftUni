function solve() {
    let [name, hall, ticketPrice] = document.querySelectorAll('#container input');
    let containerButton = document.querySelector("#container button");
    containerButton.addEventListener('click', addMovie);
    let moviesUl = document.querySelector("#movies ul");
    let archivesUl = document.querySelector("#archive ul");

    document.querySelector('#archive button').addEventListener('click', clearAll);

    function clearAll(e) {
        archivesUl.innerHTML = '';
    }
    function addMovie(e) {
        e.preventDefault();
        if (name.value !== '' && hall.value !== '' && !isNaN(Number(ticketPrice.value)) && ticketPrice.value !== '') {
            let li = document.createElement('li');
            let span = document.createElement('span');
            span.textContent = name.value;
            let strong1st = document.createElement('strong');
            strong1st.textContent = `Hall: ${hall.value}`;

            let div = document.createElement('div');
            let strong2nd = document.createElement('strong');
            strong2nd.textContent = Number(ticketPrice.value).toFixed(2);
            let input = document.createElement('input');
            input.setAttribute('placeholder', "Tickets sold");

            let button = document.createElement('button');
            button.textContent = "Archive";
            button.addEventListener('click', addArchive);

            li.appendChild(span);
            li.appendChild(strong1st);
            div.appendChild(strong2nd);
            div.appendChild(input);
            div.appendChild(button);
            li.appendChild(div);

            moviesUl.appendChild(li);
        }

    }

    function addArchive(e) {
        let target = e.target.parentElement.querySelector('input').value;
        if (target !== '' && !isNaN(Number(target))) {
            let li = document.createElement('li');
            let span = document.createElement('span');
            span.textContent = name.value;
            let strong = document.createElement('strong');
            strong.textContent = `Total amount: ${(Number(ticketPrice.value) * Number(target)).toFixed(2)}`;
            let button = document.createElement('button');
            button.textContent = "Delete";
            button.addEventListener('click', remove)
            li.appendChild(span);
            li.appendChild(strong);
            li.appendChild(button);

            archivesUl.appendChild(li);


            name.value = '';
            hall.value = '';
            ticketPrice.value = '';
        }

        e.target.parentElement.parentElement.remove();
    }

    function remove(e) {
        e.target.parentElement.remove();
    }
}