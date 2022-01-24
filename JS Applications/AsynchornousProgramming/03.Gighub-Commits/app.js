async function loadCommits() {
  let userName = document.getElementById("username");
  let repo = document.getElementById("repo");
  let ul = document.getElementById("commits");

  ul.innerHTML = "";

  try {
    let response =
      await fetch(`https://api.github.com/repos/${userName.value}/${repo.value}/commits
    `);
    if (!response.ok) {
      throw new Error(`${data.status} (${data.statusText})`);
    }
    let data = await response.json();

    data.forEach(({ commit }) => {
      let li = document.createElement("li");
      li.innerHTML = `${commit.author.name}: ${commit.message}`;

      ul.appendChild(li);
    });
  } catch (error) {
    {
      let li = document.createElement("li");
      li.innerHTML = error;

      ul.appendChild(li);
    }
  }
}
