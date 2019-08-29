<template>
  <div class="row privateKeeps">
    <div class="col-3" v-for="privateKeep in privateKeeps">
      <div class="card mb-3">
        <h3 class="card-header">{{privateKeep.name}}</h3>
        <img style="height: 200px; width: 100%; display: block;" :src="privateKeep.img" alt="Card image">
        <div class="card-body">
          <p class="card-text">{{privateKeep.description}}</p>
        </div>
        <div class="card-body">
          <button class="btn btn-info" @click="deleteKeep(privateKeep.id)">Delete</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'privateKeeps',
    data() {
      return {}
    },
    computed: {
      privateKeeps() {
        return this.$store.state.privateKeeps
      }
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch('deleteKeepById', id)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>