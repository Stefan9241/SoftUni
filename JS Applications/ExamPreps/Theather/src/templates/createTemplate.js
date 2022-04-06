import { html } from "../modules.js";
import { createTheather } from "../restFunctions.js";
let createTemplate = (submit) => html`<section id="createPage">
  <form @submit=${submit} class="create-form">
    <h1>Create Theater</h1>
    <div>
      <label for="title">Title:</label>
      <input
        id="title"
        name="title"
        type="text"
        placeholder="Theater name"
        value=""
      />
    </div>
    <div>
      <label for="date">Date:</label>
      <input id="date" name="date" type="text" placeholder="Month Day, Year" />
    </div>
    <div>
      <label for="author">Author:</label>
      <input id="author" name="author" type="text" placeholder="Author" />
    </div>
    <div>
      <label for="description">Description:</label>
      <textarea
        id="description"
        name="description"
        placeholder="Description"
      ></textarea>
    </div>
    <div>
      <label for="imageUrl">Image url:</label>
      <input
        id="imageUrl"
        name="imageUrl"
        type="text"
        placeholder="Image Url"
        value=""
      />
    </div>
    <button class="btn" type="submit">Submit</button>
  </form>
</section>`;

export function createRoute(ctx) {
  async function submit(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let title = formData.get("title").trim();
    let date = formData.get("date").trim();
    let author = formData.get("author").trim();
    let description = formData.get("description").trim();
    let imageUrl = formData.get("imageUrl").trim();
    if (
      title == "" ||
      date == "" ||
      author == "" ||
      description == "" ||
      imageUrl == ""
    ) {
      return alert("all fields are required!");
    }

    let info = {
      title,
      date,
      author,
      description,
      imageUrl,
    };
    await createTheather(info);
    ctx.page.redirect("/");
  }
  return ctx.render(createTemplate(submit));
}
