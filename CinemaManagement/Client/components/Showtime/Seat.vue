<script setup lang='ts'>
import { useBookingStore } from '~/stores/booking';

const store = useBookingStore();
const { row, column, reservedAt, reservedByUserId, id } = defineProps<{
  id: string;
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
};

const handleClick = () => {
  if (isReserved.value) return;
  isClicked.value = !isClicked.value;
};

</script>

<template>
  <div class="my-1 mx-0.5 relative" @click="!isReserved && store.reserveSeat(id)" :class="{'cursor-pointer': !isReserved}" @click="handleClick" @mouseover="isHovered = true"
    @mouseleave="isHovered = false">
    <div class="relative left-2.5">
      <div class="absolute rounded-md bg-red-700 opacity-0 transition-opacity text-white text-sm p-1"
        :class="{ 'opacity-100 z-10': isHovered && !isReserved }"> {{ row }} {{ column }} </div>
    </div>
    <div class="relative">
      <UIcon name="i-ic:baseline-chair" class="w-12 h-12 z-0" :class="setSeatColor()" />
    </div>
  </div>
</template>

<style></style>