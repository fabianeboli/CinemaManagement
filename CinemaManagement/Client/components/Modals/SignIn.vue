<script setup lang="ts">
// import Overlay from "~/components/Modals/Overlay.vue";
import {ref} from "vue";
import {useModal} from "#ui/composables/useModal";

const modal = useModal()

const email = ref<string>("");
const password = ref<string>("");
const handleSubmit = () => {
  console.log("Sign in");
};
</script>

<template>
  <!-- <Overlay title="Sign in" :handle-submit="handleSubmit"> -->
  <UModal>
    <UButton variant="soft" color="red" label="Close modal" @click="modal.close()" />
    <div class="flex flex-col gap-y-3">
      <input v-model="email" class="input" type="text" placeholder="email">
      <input v-model="password" class="input" type="password" placeholder="password">
    </div>
  </UModal>
  <!-- </Overlay> -->

</template>

<style scoped></style>
