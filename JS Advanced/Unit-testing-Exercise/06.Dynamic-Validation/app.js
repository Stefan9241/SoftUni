function validate() {
    let inputValue = document.getElementById('email');
    let pattern = /(^[a-z]+@[a-z]+.[a-z]+$)/;
    inputValue.addEventListener('change', () => {
        if(!pattern.test(inputValue.value)){
            inputValue.classList.add('error');
        }else{
            inputValue.classList.remove('error');
        }
    })
}