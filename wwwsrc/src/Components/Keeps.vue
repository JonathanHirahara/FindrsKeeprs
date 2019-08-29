<template>
  <div class="row keeps">
    <div class="col-3" v-for="keep in keeps">
      <div class="card mb-3">
        <h3 class="card-header">{{keep.name}}</h3>
        <img style="height: 200px; width: 100%; display: block;" :src="keep.img" alt="Card image">
        <div class="card-body">
          <p class="card-text">{{keep.description}}</p>
        </div>
        <div class="card-body">
          <button class="btn btn-info">Save Find</button>
        </div>
      </div>
    </div>

  </div>
</template>

<!-- NOTE V-FOR KEEP COMPONENT -->
<script>
  export default {
    name: 'keeps',
    data() {
      return {

      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {
      // saveKeep(keep) {
      //   debugger
      //   this.$store.dispatch('saveKeep', keep)
      // }
    },
    components: {}
  }
</script>


<style scoped>
  .keeps {
    background-color: black;
    height: 100vh;
  }
</style>