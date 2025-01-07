import {loadSpecificUser, updateUser} from "./Start.js";

const urlParams = new URLSearchParams(window.location.search);
var user;

window.addEventListener("load", async (event) => {
  user = await loadSpecificUser(urlParams.get("id"));

  if (user) {
    loadUserData(user);
  } else {
    console.error("Usuário não encontrado");
  }
});

// Carrega os dados no formulário
function loadUserData(user) {
  document.getElementById("title").value = user.name.title;
  document.getElementById("first").value = user.name.first;
  document.getElementById("last").value = user.name.last;
  document.getElementById("streetNumber").value = user.location.street.number;
  document.getElementById("streetName").value = user.location.street.name;
  document.getElementById("city").value = user.location.city;
  document.getElementById("state").value = user.location.state;
  document.getElementById("country").value = user.location.country;
  document.getElementById("postcode").value = user.location.postcode;
  document.getElementById("latitude").value = user.location.coordinates.latitude;
  document.getElementById("longitude").value = user.location.coordinates.longitude;
  document.getElementById("email").value = user.email;
  document.getElementById("phone").value = user.phone;
  document.getElementById("cell").value = user.cell;
}

// Salvar o formulário
document
  .getElementById("userForm")
  .addEventListener("submit", function (event) {
    event.preventDefault(); // Impede o envio padrão do formulário

    // Aqui você pode manipular os dados do formulário como quiser, por exemplo, enviá-los para uma API
    const updatedUser = {
      idUser: user.idUser,
      gender: user.gender,
      name: {
        title: document.getElementById("title").value,
        first: document.getElementById("first").value,
        last: document.getElementById("last").value,
      },
      location: {
        street: {
          number: document.getElementById("streetNumber").value,
          name: document.getElementById("streetName").value,
        },
        city: document.getElementById("city").value,
        state: document.getElementById("state").value,
        country: document.getElementById("country").value,
        postcode: document.getElementById("postcode").value,
        coordinates: {
          latitude: document.getElementById("latitude").value,
          longitude: document.getElementById("longitude").value,
        },
        timezone: {
          offset: user.location.timezone.offset,
          description: user.location.timezone.description,
        },
      },
      email: document.getElementById("email").value,
      phone: document.getElementById("phone").value,
      cell: document.getElementById("cell").value,
      login: {
        uuid: user.login.uuid,
        username: user.login.username,
        password: user.login.password,
        salt: user.login.salt,
        md5: user.login.md5,
        sha1: user.login.sha1,
        sha256: user.login.sha256,
      },
      dob: {
        date: user.dob.date,
        age: user.dob.age,
      },
      registered: {
        dateRegistered: user.registered.dateRegistered,
        ageRegistered: user.registered.ageRegistered,
      },
      id: {
        nameId: user.id.nameId,
        valueId: user.id.valueId,
      },
      picture: {
        large: user.picture.large,
        medium: user.picture.medium,
        thumbnail: user.picture.thumbnail,
      },
      nat: user.nat,
    };

    console.log("Usuário atualizado:", updatedUser);

    updateUser(updatedUser);

    alert("Dados salvos com sucesso!");

    location.href = "/index.html";
  });

// Carregar os dados do usuário ao abrir a página
window.onload = loadUserData;
