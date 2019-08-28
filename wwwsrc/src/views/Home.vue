<template>
  <div class=" home">
    <div class="row">
      <div class="col-3">
        <button class="btn btn-info" @click="home">MyKeeprs</button>
      </div>
      <div class="col-6">
        <h1>Welcome To FindrsKeeprs </h1>
      </div>
      <div class="col-3">
        <button @click="createFindr" class="btn btn-info">CREATE Findr</button>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-3 ">
        <button class="btn btn-info" v-if="user.id" @click="logout">logout</button>
        <router-link class="btn btn-info" v-else :to="{name: 'login'}">Login</router-link>
      </div>


    </div>
    <keeps></keeps>
  </div>
</template>

<script>
  import router from '../router'
  import keeps from '@/Components/KeepsComponent.vue'
  import vaults from '../Components/Vaults.vue'
  import createKeep from '../Components/CreateKeepComponent.vue'
  export default {
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    mounted() {
      this.$store.dispatch('getAllKeeps')
    },
    methods: {
      logout() {
        this.$store.dispatch("logout")
      },
      home() {
        router.push({ name: 'vaults' })
      },
      createFindr() {
        router.push({ name: 'createKeep' })
      }

    },
    components: {
      keeps
    }
  };
</script>
<style>
  h1 {
    color: white;
  }

  .home {
    background-color: black;
  }
</style>