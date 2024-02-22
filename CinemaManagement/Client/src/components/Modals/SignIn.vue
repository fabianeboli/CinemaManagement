<script setup lang="ts">
import Overlay from "~/components/Modals/Overlay.vue";
const email = ref<string>("");
const password = ref<string>("");

const handleSubmit = () => {
  console.log("Sign in");
}
</script>

<template>
  <Overlay title="Sign in" :handle-submit="handleSubmit">
    <div class="flex flex-col gap-y-3">
      <input class="input"
             type="text"
             placeholder="email"
             v-model="email">
      <input class="input"
             type="password"
             placeholder="password"
             v-model="password">
    </div>
  </Overlay>

</template>

<style scoped>


</style>
