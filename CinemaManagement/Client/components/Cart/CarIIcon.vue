<script setup lang='ts'>

const store = useCartStore();
</script>

<template>
  <!-- TODO Open Modal 'cart' after click -->
<div class="relative">
  <UIcon name="i-carbon-shopping-cart" class="text-2xl p-5 text-emerald-400"/>
  <div v-if="store.cart.length > 0" class="absolute top-0 right-0 w-2 h-2 bg-red-500 rounded-full">
    {{ store.cart.length }}
  </div>
</div>
</template>

<style scoped>

</style>