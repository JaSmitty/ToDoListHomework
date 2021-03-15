import Vue from 'vue'
import Vuex from 'vuex'
//import axios from 'axios'

Vue.use(Vuex)


export default new Vuex.Store({
  state: {
    listOfLists: []
  },
  mutations: {
    SET_LISTS(state, data) {
      state.listOfLists = data;
    }
    }
  
})
