import { create } from "../api/data.js";
import { html } from "../lib.js";

let createMemeTemplate = (onSubmit) => html` <section id="create-meme">
  <form @submit=${onSubmit} id="create-form">
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

export async function showCreateMeme(ctx) {
  ctx.render(createMemeTemplate(onSubmit));

  async function onSubmit(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let title = formData.get("title").trim();
    let description = formData.get("description").trim();
    let imageUrl = formData.get("imageUrl").trim();

    if (title == "" || description == "" || imageUrl == "") {
      return alert("All fields are required!");
    }

    await create({ title, description, imageUrl });
    ctx.page.redirect("/memes");
  }
}
