<script setup lang="ts">
// import Overlay from './Overlay.vue';
const email = ref<string>("");
const password = ref<string>("");

const handleSubmit = () => {
  console.log("Sign up");
};
</script>

<template>
  <!-- <Overlay title="Sign up" :handle-submit="handleSubmit"> -->
    <input v-model="email" type="text" class="input" placeholder="email">
    <input v-model="password" type="text" class="input" placeholder="password">
  <!-- </Overlay> -->
</template>

<style scoped>

</style>

