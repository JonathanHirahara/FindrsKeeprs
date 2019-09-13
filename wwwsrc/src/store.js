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
    keeps: [],
    privateKeeps: [],
    activeKeep: {},
    activeVault: {},
    vaultKeepKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, data) {
      state.keeps = data
    },
    setPrivateKeeps(state, data) {
      state.privateKeeps = data
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    },
    setVaults(state, data) {
      state.vaults = data
    },
    setActiveVault(state, data) {
      state.activeVault = data
    },
    setVaultKeepKeeps(state, data) {
      state.vaultKeepKeeps = data
    },
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
    async getAllPublicKeeps({ dispatch, commit }) {
      try {
        // debugger
        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      }
      catch (error) { console.log(error) }
    },
    async getPrivateUserKeeps({ dispatch, commit }) {
      try {
        // debugger
        let res = await api.get('keeps/user/')
        commit('setPrivateKeeps', res.data)
      }
      catch (error) { console.log(error) }
    },

    async createKeep({ dispatch, commit }, newKeep) {
      try {
        // debugger
        let res = await api.post('/keeps', newKeep)
        dispatch('getAllPublicKeeps')
      }
      catch (error) { console.log(error) }
    },
    async getKeepById({ dispatch, commit }, payload) {
      try {
        // debugger
        let res = await api.get('keeps/' + payload)
        commit('setActiveKeep', res.data)
      }
      catch (error) { console.log(error) }
    },

    async deleteKeepById({ dispatch, commit }, payload) {
      try {
        await api.delete('keeps/' + payload)
        dispatch('getPrivateUserKeeps')
      }
      catch (error) { console.log(error) }
    },

    async viewKeep({ dispatch, commit }, keep) {
      try {
        // debugger

        let res = await api.put('keeps/' + keep.id, keep)
      }
      catch (error) { console.log(error) }
    },
    async viewCounter({ dispatch, commit }, keep) {
      try {
        // debugger
        let res = await api.put('keeps/' + keep.id + '/view', keep)
      }
      catch (error) { console.log(error) }
    },
    async keepsCounter({ dispatch, commit }, keep) {
      try {
        // debugger
        let res = await api.put('keeps/' + keep.id + '/kept', keep)
      }
      catch (error) { console.log(error) }
    },
    //#endregion

    //#region Vaults stuff
    async getVaultsByUserId({ dispatch, commit }) {
      try {
        // debugger
        let res = await api.get('/vaults/')
        commit('setVaults', res.data)
      }
      catch (error) { console.log(error) }
    },
    async createNewVault({ dispatch, commit }, newVault) {
      try {
        let res = await api.post('/vaults', newVault)
        dispatch('getVaultsByUserId')
      }
      catch (error) { console.log(error) }
    },
    async deleteVault({ dispatch, commit }, payload) {
      try {
        await api.delete('vaults/' + payload)
        dispatch('getVaultsByUserId')
      }
      catch (error) { console.log(error) }
    },


    async addKeepToVault({ dispatch, commit }, payload) {
      try {
        // debugger
        let res = await api.post('vaultKeeps', payload)
        // dispatch('getVaultKeeps')
      }
      catch (error) { console.log(error) }
    },

    async removeKeepFromVault({ dispatch, commit }, payload) {
      try {
        await api.put('vaultKeeps', payload)
      }
      catch (error) { console.log(error) }
    },
    async getVaultKeepKeeps({ dispatch, commit }, activeVaultId) {
      try {
        // debugger
        let res = await api.get('vaultKeeps/' + activeVaultId, activeVaultId)
        commit('setVaultKeepKeeps', res.data)
      }
      catch (error) { console.log(error) }
    },
    async getVaultById({ dispatch, commit }, payload) {
      try {
        // debugger
        let res = await api.get('/vaults/' + payload)
        commit('setActiveVault', res.data)
      }
      catch (error) { console.log(error) }
    },


  }
  //#endregion 




})
