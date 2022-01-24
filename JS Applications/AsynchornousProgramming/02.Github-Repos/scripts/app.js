async function loadRepos() {
  let userName = document.getElementById("username").value;
  let listElement = document.getElementById("repos");

  let response = await fetch(`https://api.github.com/users/${userName}/repos`);

  let data = await response.json();

  listElement.innerHTML = "";
  data.forEach(({ full_name, html_url }) => {
    let li = document.createElement("li");
    let a = document.createElement("a");
    a.href = html_url;
    a.innerHTML = full_name;

    li.appendChild(a);
    listElement.appendChild(li);
  });
}
