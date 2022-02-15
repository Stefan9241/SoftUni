function solution() {
  let btnElement = document.querySelector("div button");
  let giftNameElement = document.querySelector('input[type="text"]');
  let sections = Array.from(document.querySelectorAll("section"));
  let arrayStrings = [];
  btnElement.addEventListener("click", (e) => {
    e.preventDefault();
    let name = giftNameElement.value;
    arrayStrings.push(name);
    arrayStrings = arrayStrings.sort((a, b) => a.localeCompare(b));
    sections[1].querySelector("ul").innerHTML = "";

    arrayStrings.forEach((element) => {
      let li = document.createElement("li");
      li.classList.add("gift");
      li.textContent = element;

      let sendBtn = document.createElement("button");
      sendBtn.textContent = "Send";
      sendBtn.id = "sendButton";
      li.appendChild(sendBtn);
      sendBtn.addEventListener("click", (e) => {
        let name = Array.from(e.currentTarget.parentElement.childNodes)[0].textContent;

        let li = document.createElement("li");
        li.classList.add("gift");
        li.textContent = name;

        sections[2].querySelector("ul").appendChild(li);
        e.target.parentElement.remove();

        arrayStrings = arrayStrings.filter(x=> x !== name);
      });
      let discard = document.createElement("button");
      discard.textContent = "Discard";
      discard.id = "discardButton";
      discard.addEventListener("click", (e) => {
        let name = Array.from(e.currentTarget.parentElement.childNodes)[0].textContent;

        let li = document.createElement("li");
        li.classList.add("gift");
        li.textContent = name;

        sections[3].querySelector("ul").appendChild(li);
        e.target.parentElement.remove();
        
        arrayStrings = arrayStrings.filter(x=> x !== name);
      });
      li.appendChild(discard);

      sections[1].querySelector("ul").appendChild(li);
    });
    giftNameElement.value = "";
  });
}
