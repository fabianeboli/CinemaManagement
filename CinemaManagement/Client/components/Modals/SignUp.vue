<script setup lang="ts">
import {useModal} from "#ui/composables/useModal";

const email = ref<string>("");
const password = ref<string>("");
const modal = useModal();
const handleSubmit = () => {
  console.log("Sign up");
};
</script>

<template>
  <!-- <Overlay title="Sign up" :handle-submit="handleSubmit"> -->
  <UModal>
    <UButton variant="soft" color="red" label="Close modal" @click="modal.close()" />
    <input v-model="email" type="text" class="input" placeholder="email">
    <input v-model="password" type="text" class="input" placeholder="password">
  </UModal>
  <!-- </Overlay> -->
</template>

<style scoped>

</style>

