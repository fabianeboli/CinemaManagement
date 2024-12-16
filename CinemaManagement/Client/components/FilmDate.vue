<script setup lang='ts'>
import { useDateFormat } from "@vueuse/core";
const { date, } = defineProps<{
  date: Date,
  direction: "row" | "col"
}>();
</script>

<template>
  <div :class="`flex flex-${direction}`">
    <div class="i-carbon-calendar mr-0.5"/>
    <p class="text-[#888]">{{useDateFormat(new Date(date), 'DD.MM.YY').value}}</p>
    <div class="i-carbon-time mx-0.5"/> 
    <p class="text-[#888]">{{useDateFormat(new Date(date), 'HH:MM').value}}</p>
  </div>
</template>

<style>

</style>