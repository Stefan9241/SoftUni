import { html } from "../modules.js";
import { createCar } from "../restFunctions.js";
let createTemplate = (submit) => html`<section id="create-listing">
  <div class="container">
    <form @submit=${submit} id="create-form">
      <h1>Create Car Listing</h1>
      <p>Please fill in this form to create an listing.</p>
      <hr />

      <p>Car Brand</p>
      <input type="text" placeholder="Enter Car Brand" name="brand" />

      <p>Car Model</p>
      <input type="text" placeholder="Enter Car Model" name="model" />

      <p>Description</p>
      <input type="text" placeholder="Enter Description" name="description" />

      <p>Car Year</p>
      <input type="number" placeholder="Enter Car Year" name="year" />

      <p>Car Image</p>
      <input type="text" placeholder="Enter Car Image" name="imageUrl" />

      <p>Car Price</p>
      <input type="number" placeholder="Enter Car Price" name="price" />

      <hr />
      <input type="submit" class="registerbtn" value="Create Listing" />
    </form>
  </div>
</section> `;
export function createRoute(ctx) {
  async function submit(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let brand = formData.get("brand").trim();
    let model = formData.get("model").trim();
    let description = formData.get("description").trim();
    let year = Number(formData.get("year"));
    let imageUrl = formData.get("imageUrl").trim();
    let price = Number(formData.get("price"));

    if (
      brand == "" ||
      model == "" ||
      description == "" ||
      year == "" ||
      imageUrl == "" ||
      price == ""
    ) {
      return alert("all fields are required!");
    }

    let carInfo = {
      brand,
      model,
      description,
      year,
      imageUrl,
      price,
    };

    await createCar(carInfo);
    ctx.page.redirect("/all-listings");
    ctx.updateNav();
  }
  return ctx.render(createTemplate(submit));
}
