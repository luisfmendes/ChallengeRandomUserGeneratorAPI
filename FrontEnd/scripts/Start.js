const apiUrl = "https://localhost:5001/api/User";

// Carrega os usuarios da api
export function loadUsers() {
  const userTable = document
    .getElementById("userTable")
    .getElementsByTagName("tbody")[0];

  fetch(`${apiUrl}/all`)
    .then((response) => response.json())
    .then((users) => {
      userTable.innerHTML = "";
      users.forEach((user) => {
        const row = userTable.insertRow();
        row.setAttribute("data-id", user.idUser);
        row.innerHTML = `
                    <td>${user.idUser}</td>
                    <td><span class="editable">${user.name.first}</span></td>
                    <td><span class="editable">${user.name.last}</span></td>
                    <td><span class="editable">${user.email}</span></td>
                    <td>
                        <button class="edit-button">Editar</button>
                    </td>
                `;
      });
      addEventListeners();
    })
    .catch((error) => console.error("Erro ao carregar usuários:", error));
}

export async function loadSpecificUser(id) {
  try {
    const response = await fetch(`${apiUrl}/${id}`);
    if (!response.ok) {
      throw new Error("Network response was not ok");
    }
    const userData = await response.json();
    return userData; 
  } catch (error) {
    console.error("Erro ao carregar o usuário:", error);
    return null; 
  }
}


export async function updateUser(updatedUser) {
  try {
    const response = await fetch(`${apiUrl}/update/${updatedUser.idUser}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updatedUser), 
    });

    if (!response.ok) {
      throw new Error(`Erro ao atualizar usuário: ${response.statusText}`);
    }

    const result = await response.json(); 
    return result; 
  } catch (error) {
    console.error("Erro na função updateUser:", error);
    throw error;
  }
}


function addEventListeners() {
  const editButtons = document.querySelectorAll(".edit-button");

  editButtons.forEach((button) => button.addEventListener("click", editUser));
}

function editUser(event) {
  location.href = `/pages/EditarUsuario.html?id=${event.target.parentElement.parentElement.getAttribute(
    "data-id"
  )}`;
}

