<template>
  <div class="vaults">
    <div class="row d-flex justify-content-center">
      <div class="col-3">
        <button class="btn btn-warning">NEW KEEPR</button>
      </div>
      <div class="col-6">
        <h1>Hello {{user.username}} </h1>
      </div>
      <div class="col-3">
        <button class="btn btn-warning" @click="main">MAIN</button>
      </div>
    </div>
    <div class="row d-flex justify-content-center">
      <vault></vault>
    </div>
  </div>
</template>


<script>
  import router from '../router'
  import vault from '../Components/VaultComponent.vue'
  export default {
    name: 'vaults',
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getVaultsByUserId', this.user)
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      main() {
        router.push({ name: 'home' })
      }
    },
    components: {
      vault
    }
  }
</script>


<style scoped>
  .vaults {
    background-color: black;
    height: 100vh;
  }
</style>