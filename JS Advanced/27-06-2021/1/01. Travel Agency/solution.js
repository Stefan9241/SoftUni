window.addEventListener("load", solution);

function solution() {
  let fullNameElement = document.getElementById("fname");
  let emailElement = document.getElementById("email");
  let phoneElement = document.getElementById("phone");
  let addressElement = document.getElementById("address");
  let codeElement = document.getElementById("code");

  let block = document.getElementById('block');
  let previewElement = document.getElementById("infoPreview");
  let editBTN = document.getElementById("editBTN");
  let continueBTN = document.getElementById("continueBTN");
  let submitBtn = document.getElementById('submitBTN');
  submitBtn.addEventListener("click", onSubmit);
  function onSubmit(e) {
    let fname = fullNameElement.value;
    let email = emailElement.value;
    let phone = phoneElement.value;
    let address = addressElement.value;
    let code = codeElement.value;

    if (fname != "" && email != "") {
      let fNameLi = e("li", {}, `Full Name: ${fname}`);
      let emailLi = e("li", {}, `Email: ${email}`);
      let phoneLi = e("li", {}, `Phone Number: ${phone}`);
      let addressLi = e("li", {}, `Address: ${address}`);
      let codeLi = e("li", {}, `Postal Code: ${code}`);

      previewElement.appendChild(fNameLi);
      previewElement.appendChild(emailLi);
      previewElement.appendChild(phoneLi);
      previewElement.appendChild(addressLi);
      previewElement.appendChild(codeLi);

      submitBtn.disabled = true;
      editBTN.disabled = false;
      continueBTN.disabled = false;
    }

    fullNameElement.value = "";
    phoneElement.value = "";
    addressElement.value = "";
    codeElement.value = "";
    emailElement.value = "";

    function e(type, props, ...content) {
      const element = document.createElement(type);

      for (let prop in props) {
        element[prop] = props[prop];
      }

      for (let entry of content) {
        if (typeof entry == "string" || typeof entry == "number") {
          entry = document.createTextNode(entry);
        }

        element.appendChild(entry);
      }

      return element;
    }
  }

  editBTN.addEventListener('click', onEdit);

  function onEdit(e){
    console.log(e);
    let allInfo = Array.from(document.querySelectorAll('#infoPreview'));

    let fNameArr = allInfo[0].children[0].innerText.split(':');
    let fName = fNameArr[1].trim();
    fullNameElement.value = fName;


    let emailArr = allInfo[0].children[1].innerText.split(':');
    let email = emailArr[1].trim();
    emailElement.value = email;

    let phoneArr = allInfo[0].children[2].innerText.split(':');
    let phone = phoneArr[1].trim();
    phoneElement.value = phone;

    let addressArr = allInfo[0].children[3].innerText.split(':');
    let adress = addressArr[1].trim();
    addressElement.value = adress;

    let codeArr = allInfo[0].children[4].innerText.split(':');
    let code = codeArr[1].trim();
    codeElement.value = code;
    
    submitBtn.disabled = false;
    editBTN.disabled = true;
    continueBTN.disabled = true;
    previewElement.innerHTML = '';
  }

  continueBTN.addEventListener('click', onContinue);

  function onContinue(e){
    block.innerHTML = `<h3>Thank you for your reservation!</h3>`;
  }
}
