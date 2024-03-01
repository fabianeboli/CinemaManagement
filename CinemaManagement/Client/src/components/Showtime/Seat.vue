<script setup lang='ts'>
import { set } from 'nprogress';

const { row, column, reservedAt, reservedByUserId } = defineProps<{
  row: string;
  column: string;
  reservedAt: Date;
  reservedByUserId: number;
}>();

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
  <div @click="handleClick">
    <div class="relative bottom-0.5 left-1">
      <div
        class="absolute rounded-sm bg-red-700 opacity-0 hover:opacity-100 transition-opacity text-white text-xs z-100 text-black hover:cursor-pointer">
        {{ row }} {{ column }}
      </div>
    </div>

    <div class="i-ic:baseline-chair w-1.5em h-1.5em " :class="setSeatColor()">
    </div>
    <div :class="{ active: true }"></div>

  </div>
</template>

<style></style>