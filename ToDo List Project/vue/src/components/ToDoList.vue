<template>
  <body>
        <tr v-for="list in this.$store.state.ListOfLists" v-bind:key="list.id">
            <div>{{list.id}}</div>
        </tr>
    </body>
</template>

<script>
import listService from "@/services/ListService.js";

export default {
  name: "list",
  methods: {
    getLists() {
      listService.getAll().then((response) => {
        this.$store.commit("SET_LIST", response.data);
      });
    },
    created() {
      this.getLists();
    },
  },
};
</script>

<style>
</style>