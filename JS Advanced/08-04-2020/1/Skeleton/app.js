function solve() {
    let taskElement = document.getElementById('task');
    let descriptionElement = document.getElementById('description');
    let dateElement = document.getElementById('date');
    let divOpen = document.querySelector('.orange').parentElement.nextElementSibling;
    let divComplete = document.querySelector('.green').parentElement.nextElementSibling;
    let inProgresElement = document.getElementById('in-progress');
    let btnElement = document.getElementById('add');
    btnElement.addEventListener('click', (e)=> {
        e.preventDefault();
        let task = taskElement.value;
        let description = descriptionElement.value;
        let date = dateElement.value;

        if(task === '' || description === '' || date === ''){
            return;
        }
        let articleEl = document.createElement('article');
        let h3 = document.createElement('h3');
        h3.textContent = task;
        let pElementDescr = document.createElement('p');
        pElementDescr.textContent = `Description: ${description}`;
        let pElementDate = document.createElement('p');
        pElementDate.textContent = `Due Date: ${date}`;
        let divBtnsFlex = document.createElement('div');
        divBtnsFlex.classList.add('flex');
        let startBtn = document.createElement('button');
        startBtn.textContent = 'Start';
        startBtn.classList.add('green');
        startBtn.addEventListener('click',(e)=> {
            let artic = e.target.parentElement.parentElement.cloneNode(true);
            e.target.parentElement.parentElement.remove();
            artic.querySelector('.flex').remove();
            let div = document.createElement('div');
            div.classList.add('flex');
            let delBtn = document.createElement('button');
            delBtn.textContent = 'Delete';
            delBtn.classList.add('red');
            delBtn.addEventListener('click', (e)=> {
                e.target.parentElement.parentElement.remove();
            })
            let finishBtn = document.createElement('button');
            finishBtn.textContent = 'Finish';
            finishBtn.classList.add('orange');
            finishBtn.addEventListener('click',(e)=>{
                let articFinish = e.target.parentElement.parentElement;
                articFinish.querySelector('.flex').remove();

                divComplete.appendChild(articFinish);
            })
            div.appendChild(delBtn);
            div.appendChild(finishBtn);
            artic.appendChild(div);
            inProgresElement.appendChild(artic);
        })

        let deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.classList.add('red');
        deleteBtn.addEventListener('click', (e)=> {
            e.target.parentElement.parentElement.remove();
        })
        articleEl.appendChild(h3);
        articleEl.appendChild(pElementDescr);
        articleEl.appendChild(pElementDate);
        divBtnsFlex.appendChild(startBtn);
        divBtnsFlex.appendChild(deleteBtn);
        articleEl.appendChild(divBtnsFlex);

        divOpen.appendChild(articleEl);

        taskElement.value = '';
        descriptionElement.value = ''
        dateElement.value = '';
    })
}