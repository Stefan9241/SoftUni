import { html } from "../modules.js";
import { editCar, getOneCar } from "../restFunctions.js";
let editTemplate = (car, submit) => html` <section id="edit-listing">
  <div class="container">
    <form @submit=${submit} id="edit-form">
      <h1>Edit Car Listing</h1>
      <p>Please fill in this form to edit an listing.</p>
      <hr />

      <p>Car Brand</p>
      <input
        type="text"
        placeholder="Enter Car Brand"
        name="brand"
        value=${car.brand}
      />

      <p>Car Model</p>
      <input
        type="text"
        placeholder="Enter Car Model"
        name="model"
        value=${car.model}
      />

      <p>Description</p>
      <input
        type="text"
        placeholder="Enter Description"
        name="description"
        value=${car.description}
      />

      <p>Car Year</p>
      <input
        type="number"
        placeholder="Enter Car Year"
        name="year"
        value=${car.year}
      />

      <p>Car Image</p>
      <input
        type="text"
        placeholder="Enter Car Image"
        name="imageUrl"
        value=${car.imageUrl}
      />

      <p>Car Price</p>
      <input
        type="number"
        placeholder="Enter Car Price"
        name="price"
        value=${car.price}
      />

      <hr />
      <input type="submit" class="registerbtn" value="Edit Listing" />
    </form>
  </div>
</section>`;
export async function editRoute(ctx) {
  let currCar = await getOneCar(ctx.params.id);
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

    let newData = { brand, model, description, year, imageUrl, price };

    await editCar(ctx.params.id, newData);
    ctx.page.redirect(`/details/${ctx.params.id}`);
  }
  return ctx.render(editTemplate(currCar, submit));
}
