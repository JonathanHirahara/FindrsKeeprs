<template>
  <div class="vault">
    <div class="row">
      <div class="col-3" v-for="vault in vaults">
        <div class="card text-white bg-info mb-3" style="max-width: 20rem;">
          <div class="card-body">
            <h4 class="card-title">{{vault.name}}</h4>
          </div>
          <div>
            <p class="card-text">{{vault.description}}</p>
            <button @click="deleteVault(vault.id)">Delete Vault</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<!-- NOTE V-FOR VAULT COMPONENT -->
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
    methods: {
      deleteVault(id) {
        this.$store.dispatch('deleteVault', id)
      }
    },
    components: {}
  }
</script>


<style scoped>
  .row {
    width: 800px;
  }
</style>