<template>
  <div>
    <titulo :titulo="`Aluno: ${aluno.nome}`" :btnVoltar="visualizando">
      <button v-if="visualizando" class="btnIcon btnR" @click="editar()"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></button>
      <button v-else class="btnIcon btnR" @click="cancelar()"><i class="fa fa-ban" aria-hidden="true"></i></button>
    </titulo>

    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{ aluno.nome }}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{ aluno.sobrenome }}</label>
            <input v-else v-model="aluno.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nascimento:</td>
          <td>
            <label v-if="visualizando">{{ aluno.nascimento }}</label>
            <input v-else v-model="aluno.nascimento" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizando">
              {{ professorSelecionadoNome }}
            </label>
            <select v-else v-model="aluno.teacherId" @change="professor()">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                v-bind:value="professor.id"
                :selected="professor.id === aluno.teacherId"
              >
                {{ professor.nome }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>
    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar()">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo.vue";
import urlJsonServer from '../global';

export default {
  components: {
    Titulo,
  },
  async created() {
    await this.$http
      .get(`${urlJsonServer}/students/${this.$route.params.studentId}`)
      .then((res) => res.json())
      .then((aluno) => (this.aluno = aluno));

    await this.$http
      .get(`${urlJsonServer}/teachers`)
      .then((res) => res.json())
      .then((professores) => {
        this.professores = professores;
        console.log("professores: ", professores);
        console.log('aluno.teacherId: ', this.aluno.teacherId)
        this.professor(this.aluno.teacherId);
      });
  },
  mounted() {

  },
  data() {
    return {
      aluno: {},
      professores: [],
      professorSelecionadoNome: null,
      visualizando: true,
    };
  },

  methods: {
    editar() {
      this.visualizando = !this.visualizando
    },
    salvar() {
      let _alunoEditar = {
        id: this.aluno.id,
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        nascimento: this.aluno.nascimento,
        teacherId: this.aluno.teacherId
      }

      this.$http.put(
        `${urlJsonServer}/students/${_alunoEditar.id}`, 
        _alunoEditar
      );

      this.editar()
    },
    cancelar() {
      this.editar()
    },
    alteraProfessor(teacherId) {
      console.log(teacherId);
      this.aluno.teacherId = teacherId;
    },
    professor(teacherId) {
      if (!teacherId) {
        teacherId = this.aluno.teacherId;
      }

      const professor = this.professores.find((t) => t.id === teacherId);
      console.log("Encontrou: ", professor);
      this.professorSelecionadoNome = professor.nome;
      console.log("Aluno: ", this.aluno);
      return professor;
    },
  },
};
</script>

<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}

.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}

.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}

.btnCancelarTop {
  float: right;
  background-color: rgb(249, 186, 92);
}


.colPequeno {
  width: 20%;
  text-align: right;
  background-color: rgb(125, 217, 245);
  font-weight: bold;
}

input, select {
  margin: 0;
  padding: 5px 10px;
  font-size: 0.9em;
  font-family: Montserrat;
  border: 1px solid silver;
  border-radius: 5px;
  width: 95%;
  background-color: rgb(245, 245, 245);
}

select{
  height: 38px;
  width: 100%;
}


</style>
