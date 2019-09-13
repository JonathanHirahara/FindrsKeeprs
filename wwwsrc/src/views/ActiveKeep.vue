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
          <!-- <button v-if="activeVault.id" class="btn btn-info" @click="keepKeep(activeKeep)">Save</button> -->
        </div>
      </div>
    </div>
    <div class="row">
      <!-- FIXME when you click on a vault set it as the active vault -->
      <div class="col-3" v-for="vault in vaults">
        <div class="card text-white bg-info mb-3" style="max-width: 20rem;">
          <div class="card-body">
            <h4 class="card-title">{{vault.name}}</h4>
          </div>
          <div>
            <p class="card-text">{{vault.description}}</p>
            <button @click="setActiveVault(vault)">SELECT VAULT</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'activeKeep',
    data() {
      return {
        // activeVault: {}
      }
    },
    mounted() {
      this.$store.dispatch('getKeepById', this.$route.params.keepId)
      //FIXME get my vaults here
      //NOTE getting vaults
      this.$store.dispatch('getVaultsByUserId')
      //FIXME when you hit this page increase the keep viewcount

      this.$store.dispatch('viewKeep', this.$route.params.keepId)

    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      },
      // activeVault() {
      //   return this.$store.state.activeVault
      // }
    },
    methods: {
      keepKeep(activeKeep) {
        // debugger
        //FIXME send a vault as well as the keep to create a vaultkeep
        this.$store.dispatch('addKeepToVault', activeKeep)
      },
      setActiveVault(vault) {
        let keepToVault = {
          keepId: this.activeKeep.id,
          vaultId: vault.id
        }
        debugger
        this.$store.dispatch('addKeepToVault', keepToVault)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>