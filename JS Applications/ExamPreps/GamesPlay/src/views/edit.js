import { editGame, getGameDetails } from "../api/data.js";
import { html } from "../lib.js";

let editTemplate = (game, onSubmit) => html` <section
  id="edit-page"
  class="auth"
>
  <form @submit=${onSubmit} id="edit">
    <div class="container">
      <h1>Edit Game</h1>
      <label for="leg-title">Legendary title:</label>
      <input type="text" id="title" name="title" .value=${game.title} />

      <label for="category">Category:</label>
      <input
        type="text"
        id="category"
        name="category"
        .value=${game.category}
      />

      <label for="levels">MaxLevel:</label>
      <input
        type="number"
        id="maxLevel"
        name="maxLevel"
        min="1"
        .value=${game.maxLevel}
      />

      <label for="game-img">Image:</label>
      <input
        type="text"
        id="imageUrl"
        name="imageUrl"
        .value=${game.imageUrl}
      />

      <label for="summary">Summary:</label>
      <textarea name="summary" id="summary" .value=${game.summary}></textarea>
      <input class="btn submit" type="submit" value="Edit Game" />
    </div>
  </form>
</section>`;

export async function showEdit(ctx) {
  let game = await getGameDetails(ctx.params.id);
  return ctx.render(editTemplate(game, onSubmit));

  async function onSubmit(event) {
    event.preventDefault();

    let formData = new FormData(event.target);
    let title = formData.get("title").trim();
    let category = formData.get("category").trim();
    let imageUrl = formData.get("imageUrl").trim();
    let summary = formData.get("summary").trim();
    let maxLevel = formData.get("maxLevel");

    if (
      category == "" ||
      imageUrl == "" ||
      title == "" ||
      summary == "" ||
      maxLevel == ""
    ) {
      return alert("All fields are required!");
    }

    await editGame(ctx.params.id, {
      title,
      category,
      maxLevel,
      imageUrl,
      summary,
    });

    ctx.page.redirect('/');
  }
}
