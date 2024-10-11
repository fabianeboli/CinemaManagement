<script setup lang="ts">
const { title, handleSubmit } = defineProps<{ title: string, handleSubmit?: () => void }>();
defineEmits(["close"]);
</script>

<template>
  <div class="absolute inset-0 fixed bg-black bg-opacity-50">
    <div class="flex items-start justify-center min-h-screen mt-24 text-center" role="dialog" aria-modal="true">
      <div
        class="bg-white relative bottom-50 my-40 mx-1/3 text-black rounded-lg text-center shadow-xl p-10 w-full h-full">
        <button class="absolute top-3 right-5 bg-red-7 hover:bg-red-8 text-white font-bold py-0.5 px-1.5 rounded"
          @click="$emit('close')">X
        </button>
        <h2 class="mb-5 text-2xl">{{ title }}</h2>
        <slot />
        <button v-if="handleSubmit" type="submit" class="css-button-sliding-to-bottom--red"
          @click.prevent="handleSubmit">
          Submit
        </button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.css-button-sliding-to-bottom--red {
  min-width: 130px;
  height: 40px;
  color: #fff;
  padding: 2.5px 5px;
  font-weight: bold;
  cursor: pointer;
  transition: all 0.3s ease;
  position: relative;
  display: inline-block;
  outline: none;
  border-radius: 5px;
  z-index: 0;
  background: #fff;
  overflow: hidden;
  border: 2px solid #d90429;
  color: #d90429;
}

.css-button-sliding-to-bottom--red:hover {
  color: #fff;
}

.css-button-sliding-to-bottom--red:hover:after {
  height: 100%;
}

.css-button-sliding-to-bottom--red:after {
  content: "";
  position: absolute;
  z-index: -1;
  transition: all 0.3s ease;
  left: 0;
  top: 0;
  height: 0;
  width: 100%;
  background: #d90429;
}
</style>
