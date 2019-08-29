<template>
  <div class="createVault">
    <div class="row d-flex justify-content-center">
      <div class="col-4">
        <form @submit="createNewVault">
          <label class="col-form-label col-form-label-lg" for="vault">Keepr Creator</label>
          <input class="form-control form-control-lg" type="text" placeholder="Title" id="vault"
            v-model="newVault.Name">
          <label class="col-form-label col-form-label-lg" for="vault"></label>
          <input class="form-control form-control-lg" type="text" placeholder="Description" id="vault"
            v-model="newVault.Description">
          <button type="submit">Create Keepr</button>
        </form>
      </div>
    </div>
  </div>
</template>
<!-- NOTE CREATE VAULT FORM -->

<script>
  import router from '../router'
  export default {
    name: 'createVault',
    data() {
      return {
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {},
    methods: {
      createNewVault(e) {
        this.$store.dispatch('createNewVault', this.newVault)
        router.push({ name: 'vaults' })
      }
    },
    components: {}
  }
</script>


<style scoped>
  .createVault {
    background-color: black;
    height: 100vh;
    color: rgb(255, 102, 0);
  }

  button {
    background-color: rgb(255, 102, 0);
  }
</style>