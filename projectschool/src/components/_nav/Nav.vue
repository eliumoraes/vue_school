<template>
  <div class="barraTopo">
    <nav class="marginPrincipal">
      <router-link to="/professores">Professores</router-link>
      <router-link to="/alunos">Alunos</router-link>
      <router-link to="/sobre">Sobre</router-link>
    </nav>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.barraTopo {
  background-color: rgb(230, 230, 230);
}

nav {
  padding: 20px 20px 20px 0;
}

nav a {
  padding: 10px;
  text-decoration: none;
  background-color: white;
  border-radius: 3px;
  color: rgb(0, 110, 255);
  font-weight: bold;
  margin-right: 15px;
}

nav .router-link-active {
  background-color: rgb(160, 160, 160);
  color: white;
}
</style>
