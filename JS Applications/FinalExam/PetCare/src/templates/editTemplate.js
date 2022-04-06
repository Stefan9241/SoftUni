import { html } from "../modules.js";
import { editPet, getOnePet } from "../restFunctions.js";
let editTemplate = (submitFunction, currPet) => html` <section id="editPage">
  <form @submit=${submitFunction} class="editForm">
    <img src="./images/editpage-dog.jpg" />
    <div>
      <h2>Edit PetPal</h2>
      <div class="name">
        <label for="name">Name:</label>
        <input name="name" id="name" type="text" value=${currPet.name} />
      </div>
      <div class="breed">
        <label for="breed">Breed:</label>
        <input name="breed" id="breed" type="text" value=${currPet.breed} />
      </div>
      <div class="Age">
        <label for="age">Age:</label>
        <input name="age" id="age" type="text" value="${currPet.age} years" />
      </div>
      <div class="weight">
        <label for="weight">Weight:</label>
        <input
          name="weight"
          id="weight"
          type="text"
          value="${currPet.weight}kg"
        />
      </div>
      <div class="image">
        <label for="image">Image:</label>
        <input name="image" id="image" type="text" value=${currPet.image} />
      </div>
      <button class="btn" type="submit">Edit Pet</button>
    </div>
  </form>
</section>`;
export async function editRoute(ctx) {
  let currPet = await getOnePet(ctx.params.id);

  async function submitFunction(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let name = formData.get("name");
    let breed = formData.get("breed");
    let age = formData.get("age");
    let weight = formData.get("weight");
    let image = formData.get("image");
    if (name == "" || breed == "" || age == "" || weight == "" || image == "") {
      return alert("all fields are required!");
    }
    let newPetInfo = { name, breed, age, weight, image };
    await editPet(ctx.params.id, newPetInfo);
    ctx.page.redirect(`/details/${ctx.params.id}`);
  }
  return ctx.render(editTemplate(submitFunction, currPet));
}
