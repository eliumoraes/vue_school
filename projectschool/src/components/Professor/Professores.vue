<template>
  <div>
    <Titulo titulo="Professores" />
    <table>
      <thead>
        <th>Código</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <!-- <td>{{ index + 1 }}</td> -->
          <td>{{ professor.id }}</td>

          <router-link 
            :to="'/alunos/' +`${professor.id}`"
            tag="td"
            style="cursor:pointer"
          >
          {{ professor.nome }}
          </router-link>

          <td>{{quantidadeDeAlunos(professor.id)}}</td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum professor encontrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo.vue";
import urlJsonServer from '../global';

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      professores: [],
      students: [],
    };
  },
  created() {
    this.$http
      .get(urlJsonServer + "/teachers")
      .then((res) => res.json())
      .then(
        (professor) => (
          (this.professores = professor)
          // console.log("professores: ", professor)
        )
      );
    this.$http
      .get(urlJsonServer + "/students")
      .then((res) => res.json())
      .then(
        (students) => (
          (this.students = students)
          // console.log("students: ", students)
        )
      )
      
  },

  methods: {
    quantidadeDeAlunos(professorId) {
      const quantidade = this.students
        .filter(student => 
          student.teacherId === professorId
        )
      // console.log(quantidade.length)
      return quantidade.length
    },
  }
};
</script>

<style lang="scss" scoped></style>
