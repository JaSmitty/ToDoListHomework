<template>
  <div class="home">
    <h1>To do lists</h1>
    <list />
  </div>
</template>

<script>

import ToDoList from '@/components/ToDoList.vue';

export default {
  name: "home",
  components: {
    ToDoList
  }
}
</script>
