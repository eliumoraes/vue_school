<template>
  <div>
    <div style="display: flex; width: 70%">
      <h3>{{ titulo }}</h3>
      <div class="voltar">
        <slot></slot>
        <button v-show="btnVoltar" class="btnIcon btnR" @click="voltar()"><i class="fa fa-arrow-left" aria-hidden="true"></i></button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    titulo: String,
    btnVoltar: {
      type: Boolean,
      required: false,
      default: true
    },
  },
  methods: {
    voltar() {
      this.$router.back();
    }
  }
};
</script>

<style scoped>
.voltar {
  width: 50%;
  position: absolute;
  margin-top: 15px;
}

.btnVoltar {
  float: right;
  background-color: rgb(199, 199, 199);
}
</style>
