function solve() {
  let information = document.querySelector("#info span");
  let departButtonElement = document.getElementById("depart");
  let arriveButtonElement = document.getElementById("arrive");

  let stop = {
    next: "depot",
  };

  async function depart() {
    let response = await fetch(
      `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`
    );

    if (response.status != 200) {
      information.textContent = `Error`;
      departButtonElement.disabled = true;
      arriveButtonElement.disabled = true;
    }

    stop = await response.json();

    information.textContent = `Next stop ${stop.name}`;
    departButtonElement.disabled = true;
    arriveButtonElement.disabled = false;
  }

  function arrive() {
    information.textContent = `Arriving at ${stop.name}`;

    departButtonElement.disabled = false;
    arriveButtonElement.disabled = true;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
