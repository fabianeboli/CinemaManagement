<script setup lang='ts'>
import { Showtime } from "~/types";


const { id } = useRoute().params;

</script>

<template>
  <Suspense timeout="0">
    <template #default>
      <ShowtimeDetails :id="id"/>
    </template>
    <template #fallback>
       <Spinner/>
    </template>
  </Suspense>
  <!-- <div v-if="isFetching">
    <Spinner />
  </div>
  <div class="text-red-500" v-else-if="error">
    Error: {{ error }}
  </div>
  <div v-else> -->
   
    <!-- <p>{{ showtime.film }}</p> -->
    <!-- <img :src="showtime.film.image" :alt="'Bilboard of '+ showtime.film.title" /> -->

  <!-- </div> -->
</template>

<style></style>