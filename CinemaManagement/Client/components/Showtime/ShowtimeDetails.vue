<script setup lang='ts'>
import type { Showtime } from "~/types";
import FilmDate from "~/components/FilmDate.vue";
import Seats from "~/components/Showtime/Seats.vue";

const { id } = useRoute().params;
const { data, status, error } = await useFetch(`http://localhost:5016/api/Showtimes/${id}`)
const showtime: Showtime = data.value as Showtime;
console.log(data.value);

const { data: theaterData } = await useFetch(`http://localhost:5016/api/Theaters/${id}`)
</script>

<template>
    <div class="flex flex-col items-center justify-evenly">
      <div class="flex items-baseline gap-x-20 mb-15">
        <div>
          <h1 class="font-bold text-xl"> {{ showtime.film.title }} </h1>
          <h3 class="text-stn"> {{ theaterData.name }} </h3>
          <h3 class="text-stn"> {{ showtime.auditorium.name }} </h3>
        </div>
        <FilmDate :date="showtime.date" :direction="'row'" />
      </div>
      <Seats />
    </div>
</template>

<style scoped></style>