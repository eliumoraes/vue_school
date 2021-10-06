<template>
  <div>
    <!-- <h1>{{ titulo }}</h1> -->
    <Titulo
    :titulo="teacherId !== undefined ? 'Alunos do professor ' + professor.nome : 'Todos os alunos'" />
    <div v-if="teacherId !== undefined">
      <input
        type="text"
        placeholder="Nome do aluno"
        v-model="nome"
        v-on:keyup.enter="addAluno()"
      />
      <button class="btn btn_Input" @click="addAluno()">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Matrícula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <!-- <td>{{ index + 1 }}</td> -->
          <td>{{ aluno.id }}</td>
          <router-link
            :to="`/alunoDetalhe/${aluno.id}`"
            tag="td"
            style="cursor: pointer"
          >
            {{ aluno.nome }} {{ aluno.sobrenome }}
          </router-link>
          <td>
            <button class="btn btn_Danger" @click="remover(aluno)">
              Remover
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum aluno encontrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo.vue";
import urlJsonServer from '../global';
// Acessando os alunos do professor 1 --->
// ${urlJsonServer}/teachers/1/students

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      titulo: "Aluno",
      nome: "",
      professor: {},
      alunos: [],
      teacherId: this.$route.params.teacherId,
    };
  },

  created() {
    if (this.teacherId) {
      this.carregarProfessor(this.teacherId);
      this.$http
        .get(`${urlJsonServer}/teachers/${this.teacherId}/students`)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    } else {
      this.$http
        .get(`${urlJsonServer}/students`)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },

  props: {},
  methods: {
    preparaSobrenome() {
      // Transforma o nome numa array
      const nomeCompleto = this.nome.split(' ')
      // Pega o primeiro elemento da array
      const nome = nomeCompleto[0]
      // Remove o primeiro elemento da array
      nomeCompleto.shift()
      // Transforma a array em string separando por espaços
      const sobrenome = nomeCompleto.join(' ')

      // Logs para testar
      // console.log(this.nome)
      // console.log(nome)
      // console.log(sobrenome)

      return {
        nome: nome,
        sobrenome: sobrenome
      }
    },
    addAluno() {
      let _aluno = {
        nome: this.preparaSobrenome().nome,
        sobrenome: this.preparaSobrenome().sobrenome,
        teacherId: Number(this.teacherId)
      };

      this.$http
        .post(`${urlJsonServer}/students`, _aluno)
        .then((res) => res.json())
        .then((alunoRetornado) => {
          this.alunos.push(alunoRetornado);
        });

      this.nome = null;
    },

    remover(aluno) {
      this.$http
        .delete(`${urlJsonServer}/students/${aluno.id}`)
        .then(() => {
          let indice = this.alunos.indexOf(aluno);
          this.alunos.splice(indice, 1);
        });
    },

    carregarProfessor(professorId) {
      this.$http
        .get(`${urlJsonServer}/teachers/${professorId}`)
        .then((res) => res.json())
        .then((professor) => {
          this.professor = professor;
        });
    },
  },
};
</script>

<!-- Se a tag estiver como:
<style scoped></style>

Nesse formato o codigo css fica limitado apenas ao escopo deste arquivo
-->
<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btn_Input {
  width: 150px;
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 115);
  display: inline;
  margin: 0;
  margin-left: 2px;
}
.btn_Input:hover {
  border: 0;
  text-shadow: 2px 2px 2px brown;
  margin: 0;
  margin-left: 2px;
}
</style>
