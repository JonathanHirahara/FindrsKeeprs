<template>
  <div class="activeVault">
    <div class="row keeps">
      <div class="col-3" v-for="keep in getvaultkeepkeeps">
        <div class="card mb-3">
          <h3 class="card-header">{{keep.name}}</h3>
          <img style="height: 200px; width: 100%; display: block;" :src="keep.img" alt="Card image">
          <div class="card-body">
            <p class="card-text">{{keep.description}}</p>
          </div>
          <div class="row d-flex justify-content-center">
            <div class="col-12">
              <p>KEEPS:{{keep.keeps}}</p>
            </div>
            <div class="col-12">
              <p>VIEWS:{{keep.views}}</p>
            </div>
            <div class="col-12">
              <p>SHARES:{{keep.shares}}</p>
            </div>
          </div>

        </div>
      </div>

    </div>

  </div>
</template>


<script>
  export default {
    name: 'activeVault',
    data() {
      return {}
    },
    mounted() {
      // debugger
      this.$store.dispatch('getVaultById', this.$route.params.vaultId)
      this.$store.dispatch('getVaultKeepKeeps', this.$route.params.vaultId)
    },
    computed: {
      getvault() {
        return this.$store.state.activeVault
      },
      getvaultkeepkeeps() {
        return this.$store.state.vaultKeepKeeps
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>
  .activeVault {
    background-color: black;
    height: 100%;
  }
</style>