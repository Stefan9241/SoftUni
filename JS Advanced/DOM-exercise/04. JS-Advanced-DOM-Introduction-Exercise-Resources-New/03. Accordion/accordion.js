function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let displ = document.getElementById("extra");

    button.textContent = button.textContent == 'More' || button.textContent == 'MORE' ?
        button.textContent = 'Less' :
        button.textContent = 'More';

    displ = displ.style.display == 'none' || displ.style.display == '' ?
        displ.style.display = 'block'
        : displ.style.display = 'none';


}