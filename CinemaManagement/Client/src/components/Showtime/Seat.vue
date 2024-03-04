<script setup lang='ts'>
const { row, column, reservedAt, reservedByUserId } = defineProps<{
  row: string;
  column: string;
  reservedAt: Date;
  reservedByUserId: number;
}>();

const isHovered = ref<boolean>(false);
const isReserved = ref<boolean>(Boolean(reservedByUserId));
const isClicked = ref<boolean>(false);

const setSeatColor = () => {
  if (isReserved.value) return "bg-gray-500";
  if (isClicked.value) return "bg-yellow-500";
  return "bg-emerald-700";
}

const handleClick = () => {
  if (isReserved.value) return;
  isClicked.value = !isClicked.value;
}

</script>

<template>
  <div class="my-1 mx-0.5" @click="handleClick" @mouseover="isHovered = true " @mouseleave="isHovered = false">
    <div class="relative left-2.5">
      <div
        class="absolute rounded-md bg-red-700 opacity-0  transition-opacity text-white text-sm p-1 z-100 text-black"
        :class="{ 'opacity-100 hover:cursor-pointer': isHovered && !isReserved}">
        {{ row }} {{ column }}
      </div>
    </div>
    <div class="i-ic:baseline-chair w-3em h-3em"            :class="setSeatColor()">
    </div>
  </div>
</template>

<style></style>