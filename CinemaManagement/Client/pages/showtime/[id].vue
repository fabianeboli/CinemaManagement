<script setup lang='ts'>
import { Showtime } from "~/types";
import {useModal} from "#ui/composables/useModal";
import {onMounted} from "vue";
import {useRoute} from "#app";
import ShowtimeDetails from "~/components/Showtime/ShowtimeDetails.vue";
import Spinner from "~/components/Utils/Spinner.vue";


const { id } = useRoute().params;
const modal = useModal();
onMounted(() => {
  modal.close();
})
</script>

<template>
  <!-- <Suspense timeout="0">
    <template #default>
      Test
    </template>
    <template #fallback>
      <Spinner/>
    </template>
  </Suspense> -->
  <ShowtimeDetails/>
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