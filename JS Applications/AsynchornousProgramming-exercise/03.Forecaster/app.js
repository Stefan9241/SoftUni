function attachEvents() {
  document.getElementById("submit").addEventListener("click", getWeather);
}
let error = false;
const symbols = {
  Sunny: "\u2600",
  "Partly sunny": "\u26C5",
  Overcast: "\u2601",
  Rain: "\u2614",
  Degrees: "\u00B0",
};

async function getWeather() {
  let labels = document.querySelectorAll("#current");
  let currentElement = labels[0];

  let futureLabel = document.querySelectorAll("#upcoming");
  let futureElement = futureLabel[0];

  currentElement.replaceChildren();
  futureElement.replaceChildren();
  let [name, today, upcoming] = await getAllData();
  
  document.getElementById("forecast").style.display = "block";

  let label1 = e("div", { className: "label" }, "Current conditions");
  currentElement.appendChild(label1);
  let todayDiv = e(
    "div",
    { className: "forecasts" },
    e(
      "span",
      { className: "condition symbol" },
      `${symbols[today.forecast.condition]}`
    ),
    e(
      "span",
      { className: "condition" },
      e("span", { className: "forecast-data" }, name),
      e(
        "span",
        { className: "forecast-data" },
        `${today.forecast.low}\u00B0/${today.forecast.high}\u00B0`
      ),
      e("span", { className: "forecast-data" }, `${today.forecast.condition}`)
    )
  );
  currentElement.appendChild(todayDiv);

  let label = e("div", { className: "label" }, "Three-day forecast");
  futureElement.appendChild(label);

  let futureDiv = document.createElement("div");
  futureDiv.className = "forecast-info";

  upcoming.forecast.forEach((x) => {
    let curr = e(
      "span",
      { className: "upcoming" },
      e("span", { className: "symbol" }, symbols[x.condition]),
      e("span", { className: "forecast-data" }, `${x.low}/${x.high}`),
      e("span", { className: "forecast-data" }, `${x.condition}`)
    );
    futureDiv.appendChild(curr);
  });

  futureElement.appendChild(futureDiv);
}

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
async function getAllData() {
  let name = document.getElementById("location");

  let cityResponse = await fetch(
    `http://localhost:3030/jsonstore/forecaster/locations/`
  );
  let cityData = await cityResponse.json();
  cityData = cityData.find((x) => x.name === name.value);

  if(cityData == undefined || cityResponse.status != 200){
      document.getElementById('forecast').textContent = 'Error';
      error = true;
  }
  let todayResponse =
    await fetch(`http://localhost:3030/jsonstore/forecaster/today/${cityData.code}
      `);
  let todayForecast = await todayResponse.json();

  let upcomingResponse =
    await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${cityData.code}
    `);
  let upcomingForecast = await upcomingResponse.json();

  let result = [name.value, todayForecast, upcomingForecast];

  return result;
}
attachEvents();
