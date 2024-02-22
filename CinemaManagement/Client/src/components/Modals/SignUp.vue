<script setup lang="ts">
const email = ref<string>("");
const password = ref<string>("");

const handleSubmit = () => {
  console.log("Sign up");
}
</script>

<template>
  <Overlay title="Sign up" :handle-submit="handleSubmit">
    <input type="text" class="input" placeholder="email" v-model="email"/>
    <input type="text" class="input" placeholder="password" v-model="password"/>
  </Overlay>
</template>

<style scoped>

</style>

