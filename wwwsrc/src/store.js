import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    vaults: [],
    keeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setVaults(state, data) {
      state.vaults = data
    },
    setKeeps(state, data) {
      state.keeps = data
    }
  },
  actions: {
    //#region Auth stuff
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    //#endregion

    //#region Keeps stuff
    async getAllKeeps({ dispatch, commit }) {
      try {
        // debugger
        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      }
      catch (error) { console.log(error) }
    },

    async createKeeps({ dispatch, commit }, payload) {
      try {
        let res = await api.post('/keeps', payload)
        dispatch('getAllkeeps')
      }
      catch (error) { console.log(error) }
    },
    //#endregion

    //#region Vaults stuff
    async getVaultsByUserId({ dispatch, commit }, user) {
      try {
        debugger
        let res = await api.get('/vaults/', user)
        commit('setVaults', res.data)
      }
      catch (error) { console.log(error) }
    }

  }
})
