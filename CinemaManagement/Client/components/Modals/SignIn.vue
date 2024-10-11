<script setup lang="ts">
// import Overlay from "~/components/Modals/Overlay.vue";

const email = ref<string>("");
const password = ref<string>("");

const handleSubmit = () => {
  console.log("Sign in");
};
</script>

<template>
  <!-- <Overlay title="Sign in" :handle-submit="handleSubmit"> -->
    <div class="flex flex-col gap-y-3">
      <input v-model="email" class="input" type="text" placeholder="email">
      <input v-model="password" class="input" type="password" placeholder="password">
    </div>
  <!-- </Overlay> -->

</template>

<style scoped></style>
