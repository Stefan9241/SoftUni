import { html } from "../modules.js";
import { editTheather, getOneTheather } from "../restFunctions.js";
let editTemplate = (submit, item) => html` <section id="editPage">
  <form @submit=${submit} class="theater-form">
    <h1>Edit Theater</h1>
    <div>
      <label for="title">Title:</label>
      <input
        id="title"
        name="title"
        type="text"
        placeholder="Theater name"
        value=${item.title}
      />
    </div>
    <div>
      <label for="date">Date:</label>
      <input
        id="date"
        name="date"
        type="text"
        placeholder="Month Day, Year"
        value=${item.date}
      />
    </div>
    <div>
      <label for="author">Author:</label>
      <input
        id="author"
        name="author"
        type="text"
        placeholder="Author"
        value=${item.author}
      />
    </div>
    <div>
      <label for="description">Theater Description:</label>
      <textarea id="description" name="description" placeholder="Description">${item.description}</textarea
      >
    </div>
    <div>
      <label for="imageUrl">Image url:</label>
      <input
        id="imageUrl"
        name="imageUrl"
        type="text"
        placeholder="Image Url"
        value=${item.imageUrl}
      />
    </div>
    <button class="btn" type="submit">Submit</button>
  </form>
</section>`;
export async function editRoute(ctx) {
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
    await editTheather(ctx.params.id,info);
    ctx.page.redirect(`/details/${ctx.params.id}`);
  }

  let theather = await getOneTheather(ctx.params.id);
  return ctx.render(editTemplate(submit,theather));
}
