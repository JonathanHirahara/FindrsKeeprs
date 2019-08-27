<template>
  <div class="keeps">
    <div class="card text-white bg-warning mb-3" style="max-width: 20rem;">
      <div class="card-header">Header</div>
      <div class="card-body">
        <h4 class="card-title">Warning card title</h4>
        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's
          content.
        </p>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'keeps',
    data() {
      return {}
    },
    computed: {
      getAllKeeps() {
        return this.$store.state.keeps
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>