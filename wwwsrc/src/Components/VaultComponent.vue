<template>
  <div class="vault">
    <div class="col-3" v-for="vault in vaults">
      <div class="card text-white bg-info mb-3" style="max-width: 20rem;">
        <div class="card-body">
          <h4 class="card-title">{{vault.name}}</h4>
          <p class="card-text">{{vault.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'vault',
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>