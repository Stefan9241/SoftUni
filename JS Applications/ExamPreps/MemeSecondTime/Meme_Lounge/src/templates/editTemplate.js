import { html } from "../modules.js";
import { editMeme, getOneMeme } from "../restFunctions.js";
let editTemplate = (item, submitFunction) => html`<section id="edit-meme">
  <form @submit=${submitFunction} id="edit-form">
    <h1>Edit Meme</h1>
    <div class="container">
      <label for="title">Title</label>
      <input
        id="title"
        type="text"
        placeholder="Enter Title"
        name="title"
        .value=${item.title}
      />
      <label for="description">Description</label>
      <textarea
        id="description"
        placeholder="Enter Description"
        name="description"
        .value=${item.description}
      >
      </textarea>
      <label for="imageUrl">Image Url</label>
      <input
        id="imageUrl"
        type="text"
        placeholder="Enter Meme ImageUrl"
        name="imageUrl"
        .value=${item.imageUrl}
      />
      <input type="submit" class="registerbtn button" value="Edit Meme" />
    </div>
  </form>
</section>`;
export async function editRoute(ctx) {
  let meme = await getOneMeme(ctx.params.id);

  async function submitFunction(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let title = formData.get("title").trim();
    let imageUrl = formData.get("imageUrl").trim();
    let description = formData.get("description").trim();
    if (title == "" || imageUrl == "" || description == "") {
      return alert("all fields are required!");
    }

    let newInfo = { title, description, imageUrl };
    await editMeme(ctx.params.id, newInfo);
    ctx.page.redirect(`/details/${ctx.params.id}`);
  }
  return ctx.render(editTemplate(meme, submitFunction));
}
