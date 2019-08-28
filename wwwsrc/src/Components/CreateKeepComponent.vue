<template>
  <div class="createKeep">
    <div class="row d-flex justify-content-center ">
      <div class="col-3">
        <div class="form-group">
          <div class="card">
            <div class="card-body">
              <form @submit="createKeep">
                <h2 class="card-title"><b>Create-A-Findr</b></h2>
                <label class="col-form-label col-form-label-lg" for="inputLarge">Findr Title</label>
                <input class="form-control form-control-lg" type="text" placeholder="Title" id="inputLarge">
                <div>
                  <label class="col-form-label col-form-label-lg" for="inputLarge"></label>
                  <input class="form-control form-control-lg" type="text" placeholder="imageUrl Here" id="inputLarge">
                </div>
                <div>
                  <label class="col-form-label col-form-label-lg" for="inputLarge">Large input</label>
                  <input class="form-control form-control-lg" type="text" placeholder="Description" id="inputLarge">
                </div>
                <div>
                  <button>Create Findr</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  import router from '../router'
  export default {
    name: 'createKeep',
    data() {
      return {

      }
    },
    computed: {},
    methods: {
      createKeep(e) {
        this.$store.dispatch('createKeep')
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
  }

  .pos {
    margin-top: 20px;
  }

  button {
    background-color: rgb(255, 136, 0);

  }
</style>