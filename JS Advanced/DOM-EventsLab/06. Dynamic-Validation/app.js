function validate() {
    document.getElementById('email').addEventListener('change', onChange);

    function onChange(ev) {
        const regex = /^[a-z]+@[a-z]+\.[a-z]+$/;
        
        if (!regex.test(ev.target.value)) {
            ev.target.classList.add('error');
        } else {
            ev.target.classList.remove('error');
        }
    }
}