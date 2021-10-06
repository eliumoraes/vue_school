import Vue from "vue";
import VueRouter from "vue-router";
import Alunos from "./components/Aluno/Alunos.vue";
import AlunoDetalhe from "./components/Aluno/AlunoDetalhe.vue";
import Professores from "./components/Professor/Professores.vue";
import Sobre from "./components/Sobre/Sobre.vue";

Vue.use(VueRouter);

export default new VueRouter({
  // mode: 'history',
  routes: [
    {
      path: '/professores',
      nome: 'Professores',
      component: Professores,
    },
    {
      path: "/alunos",
      nome: "Alunos",
      component: Alunos,
    },
    {
      path: "/alunos/:teacherId",
      nome: "Alunos",
      component: Alunos,
    },
    {
      path: "/sobre",
      nome: "Sobre",
      component: Sobre,
    },
    {
      path: "/alunoDetalhe/:studentId",
      nome: "AlunoDetalhe",
      component: AlunoDetalhe,
    },
  ],
});
