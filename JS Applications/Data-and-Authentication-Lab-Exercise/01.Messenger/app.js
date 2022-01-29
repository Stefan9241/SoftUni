function attachEvents() {
  document.getElementById("refresh").addEventListener("click", loadMsgs);
  document.getElementById("submit").addEventListener("click", send);
}

let msgElement = document.getElementById("messages");
let contentElement = document.querySelector('[name="content"]');
let nameElement = document.querySelector('[name="author"]');

async function loadMsgs() {
  msgElement.value = "";
  let response = await fetch("http://localhost:3030/jsonstore/messenger");
  let desData = await response.json();

  let result = Object.values(desData);
  let msg = result.map((x) => `${x.author}: ${x.content}`);
  msgElement.value += msg.join("\n");
}

async function send() {
  let inputText = contentElement.value;
  let name = nameElement.value;

  let options = { author: name, content: inputText };

  await fetch("http://localhost:3030/jsonstore/messenger", {
    method: "post",
    headers: { "Content-Type": "aplication-json" },
    body: JSON.stringify(options),
  });

  await loadMsgs();

  contentElement.value = '';
  nameElement.value = '';
}
attachEvents();
