<template>
  <div class="activeKeep">
    <div class="col-3">
      <div class="card mb-3">
        <h3 class="card-header">{{activeKeep.name}}</h3>
        <img style="height: 200px; width: 100%; display: block;" :src="activeKeep.img" alt="Card image">
        <div class="card-body">
          <p class="card-text">{{activeKeep.description}}</p>
        </div>
        <div class="card-body">
          <button class="btn btn-info" @click="">Save</button>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
  export default {
    name: 'activeKeep',
    data() {
      return {}
    },
    mounted() {
      // let data = {
      //   keepId: this.$route.params.keepId
      // }
      // debugger
      this.$store.dispatch('getKeepById', this.$route.params.keepId)
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>