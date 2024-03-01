<script setup lang='ts'>
import { formatDate } from '@vueuse/core';
import { Showtime } from '~/types';

const { id } = defineProps<{
  id: string
}>();

const { data, error, isFetching } = await useFetch(`http://localhost:5016/api/Showtimes/${id}`).get().json(); 
const showtime: Showtime = data.value as Showtime;
console.log(data.value);

</script>

<template>
  <div class="flex justify-evenly">
    {{ showtime.film.title }}
    <div>
      <FilmDate :date="showtime.date" :direction="'row'"/>
    </div>
    <Seats/>
  </div>
</template>

<style></style>