async function getInfo() {
  let stopInputElement = document.getElementById("stopId");
  let stopNameElement = document.getElementById("stopName");
  let busesElement = document.getElementById("buses");

  let response = await fetch(
    `http://localhost:3030/jsonstore/bus/businfo/${stopInputElement.value}`
  );

  try {
    busesElement.innerHTML = "";
    if (response.status != 200) {
      throw new Error("Error");
    }
    let data = await response.json();
    
    stopNameElement.innerText = data.name;

    Object.entries(data.buses).forEach((x) => {
      let li = document.createElement("li");
      li.textContent = `Bus ${x[0]} arrives in ${x[1]} minutes`;

      busesElement.appendChild(li);
    });
  } catch {
    stopNameElement.innerText = "Error";
  }
}
