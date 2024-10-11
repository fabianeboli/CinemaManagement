<script setup lang='ts'>
import CustomModal from '~/components/Modals/CustomModal.vue';


const isOpen = ref(false);
</script>

<template>
  <div>
    Index Page
    <CustomModal name="mODAL" component="" />
    <UButton label="Open" @click="isOpen = true" />
    <UModal v-model="isOpen">
      <UCard>
        <div class="p-4">
          <Placeholder class="h-48" />
        </div>
      </UCard>
    </UModal>
  </div>
</template>

<style scoped></style>