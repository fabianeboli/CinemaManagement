<script setup lang="ts">
const {errorMessage} = defineProps<{ errorMessage: string }>();

</script>

<template>
  <div>
    <h1 class="text-xl xl:text-3xl text-red-500">Error: {{ errorMessage }}</h1>
  </div>
</template>

<style scoped>

</style>
