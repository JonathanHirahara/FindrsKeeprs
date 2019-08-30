<template>
  <div class="row keeps">
    <div class="col-3" v-for="keep in keeps">
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
        <div class="card-body">
          <button class="btn btn-warning" @click="viewKeep(keep)">View</button>
        </div>
        <div class="card-body">
          <button class="btn btn-warning" @click="shareKeep(keep)">SHARE</button>
        </div>
      </div>
    </div>

  </div>
</template>

<!-- NOTE V-FOR KEEP COMPONENT -->
<script>
  export default {
    name: 'keeps',
    data() {
      return {
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    mutations: {
      // viewKeep(keep) {
      //   this.$store.state.setActiveKeep
      // }
    },
    methods: {
      // incrementViews(id) {
      //   this.keep.views++;
      //   this.$store.dispatch('keepCounter', keep.views, keep.id)
      // },
      viewKeep(keep) {
        // debugger
        // this.$store.commit('setActiveKeep', keep)

        this.$router.push({ name: 'activeKeep', params: { keepId: keep.id } })

      }
    },
    components: {}
  }
</script>


<style scoped>

</style>