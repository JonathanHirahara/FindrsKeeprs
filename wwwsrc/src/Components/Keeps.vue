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
          <button class="btn btn-warning" @click="viewKeep(keep)">View</button>
          <button class="btn btn-info" @click="">Save</button>
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
      viewKeep(keep) {
        // debugger
        this.$router.push({ name: 'activeKeep', params: { keepId: keep.id } })
      }
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