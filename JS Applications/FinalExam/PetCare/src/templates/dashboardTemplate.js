import { html } from "../modules.js";
import { getAllAnimals } from "../restFunctions.js";
let dashboardTemplate = (animals) => html`<section id="dashboard">
  <h2 class="dashboard-title">Services for every animal</h2>
  <div class="animals-dashboard">
  ${
    animals && animals.length !== 0
      ? animals.map(oneAnimalTemplate)
      : html` <div>
          <p class="no-pets">No pets in dashboard</p>
        </div>`
  }
    </div>
    <!--If there is no pets in dashboard-->
  </div>
</section>`;

let oneAnimalTemplate = (item) => html` <div class="animals-board">
  <article class="service-img">
    <img class="animal-image-cover" src=${item.image} />
  </article>
  <h2 class="name">${item.name}</h2>
  <h3 class="breed">${item.breed}</h3>
  <div class="action">
    <a class="btn" href="/details/${item._id}">Details</a>
  </div>
</div>`;
export async function dashboardRoute(ctx) {
  let animals = await getAllAnimals();

  return ctx.render(dashboardTemplate(animals));
}
