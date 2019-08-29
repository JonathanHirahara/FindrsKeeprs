<template>
  <div class="createKeep">
    <div class="row d-flex justify-content-center">
      <div class="col-4">
        <form @submit="createNewKeep">
          <label class="col-form-label col-form-label-lg" for="keep">Findr Creator</label>
          <input class="form-control form-control-lg" type="text" placeholder="Title" id="keep" v-model="newKeep.Name">
          <label class="col-form-label col-form-label-lg" for="keep"></label>
          <input class="form-control form-control-lg" type="text" placeholder="imageUrl Here" id="keep"
            v-model="newKeep.Img">
          <label class="col-form-label col-form-label-lg" for="keep"></label>
          <input class="form-control form-control-lg" type="text" placeholder="Description" id="keep"
            v-model="newKeep.Description">
          <div class="form-check">
            <input type="checkbox" v-model="newKeep.isprivate">
            <label>Private Findr?</label>
          </div>
          <button type="submit">Create Findr</button>
        </form>
      </div>
    </div>
  </div>

</template>

<!-- NOTE Create Keep Form -->
<script>
  import router from '../router'
  export default {
    name: 'createKeep',
    data() {
      return {
        newKeep: {
          Name: "",
          Img: "",
          Description: "",

        }
      }
    },
    computed: {},
    methods: {
      createNewKeep(e) {
        // debugger
        this.$store.dispatch('createKeep', this.newKeep)
        router.push({ name: 'home' })
      }
    },
    components: {}
  }
</script>


<style scoped>
  .createKeep {
    background-color: black;
    height: 100vh;
    color: rgb(255, 136, 0);
  }

  .pos {
    margin-top: 20px;
  }

  button {
    background-color: rgb(255, 136, 0);

  }
</style>