import { html } from "../modules.js";
import { createMeme } from "../restFunctions.js";
let createTemplate = (submitFunction) => html`<section id="create-meme">
  <form @submit=${submitFunction} id="create-form">
    <div class="container">
      <h1>Create Meme</h1>
      <label for="title">Title</label>
      <input id="title" type="text" placeholder="Enter Title" name="title" />
      <label for="description">Description</label>
      <textarea
        id="description"
        placeholder="Enter Description"
        name="description"
      ></textarea>
      <label for="imageUrl">Meme Image</label>
      <input
        id="imageUrl"
        type="text"
        placeholder="Enter meme ImageUrl"
        name="imageUrl"
      />
      <input type="submit" class="registerbtn button" value="Create Meme" />
    </div>
  </form>
</section>`;
export function createRoute(ctx) {
  async function submitFunction(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let title = formData.get("title");
    let description = formData.get("description");
    let imageUrl = formData.get("imageUrl");
    if (title == "" || description == "" || imageUrl == "") {
      return alert("all fields are required!");
    }

    let info = { title, description, imageUrl };
    await createMeme(info);
    ctx.page.redirect("/all-memes");
  }

  return ctx.render(createTemplate(submitFunction));
}
