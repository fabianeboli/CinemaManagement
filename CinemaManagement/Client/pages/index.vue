<script setup lang='ts'>
const isOpen = ref(false);

</script>

<template>
  <div>
    Index Page
    <button class="text-purple-50">TEST</button>
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