<template>
  <div class="createVault">
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
  export default {
    name: 'createVault',
    data() {
      return {}
    },
    computed: {},
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>