<template>
  <div id="app">
    <Nav />
    <div class="marginPrincipal">
      <router-view :key="$route.fullPath" />
    </div>
  </div>
</template>

<script>
import Nav from "./components/_nav/Nav.vue";
// import Alunos from "./components/Aluno/Alunos.vue";
// import Professores from "./components/Professor/Professores.vue";
// import Sobre from "./components/Sobre/Sobre.vue";

export default {
  name: "App",
  components: {
    Nav,
    // Alunos,
    // Professores,
    // Sobre,
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");
body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}

body,
html {
  margin: 0;
  height: 100%;
}

.marginPrincipal {
  width: 50%;
  margin: auto;
}

#app {
  width: 100%;
}

.btn_Danger {
  background-color: #fa4430;
  font-size: 0.8em !important;
}

.btn {
  border: 1px solid black;
  cursor: pointer;
  padding: 10px 20px;
  color: white;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 3px solid black;
  font-size: 1.2em;
}

.btn:hover {
  text-shadow: 1px 1px 1px black;
  margin-top: 2px;
  border-bottom: 1px solid black;
}

table {
  margin: 0;
  padding: 0;
  list-style-type: none;
  width: 100%;
}

table thead th {
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px;
  text-align: center !important;
}

table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}
.colPequeno {
  width: 5%;
}

/* Style buttons */
.btnIcon {
  background-color: DodgerBlue; /* Blue background */
  border: none; /* Remove borders */
  color: white; /* White text */
  padding: 12px 16px; /* Some padding */
  font-size: 16px; /* Set a font size */
  cursor: pointer; /* Mouse pointer on hover */
}

/* Darker background on mouse-over */
.btnIcon:hover {
  background-color: RoyalBlue;
}

.btnR {
  float: right;
  margin-left: 1%;
}


</style>
