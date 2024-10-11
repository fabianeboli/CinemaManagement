<script setup lang="ts">
import { useFilmDetailsStore } from "../../stores/filmDetails";
import Spinner from "../Utils/Spinner.vue";
defineEmits(["closeModal"]);
// !TODO add isFetch

const { id, title, genre, duration, description, image } = defineProps({
  id: {
    type: Number,
    required: true
  },
  title: {
    type: String,
    required: true
  },
  genre: {
    type: String,
    required: true
  },
  duration: {
    type: Number,
    required: true
  },
  description: {
    type: String,
    required: true
  },
  image: {
    type: String,
    required: true
  }
})

const { error, data, status } = await useFetch(`http://localhost:5016/api/FilmsShowtimes/${id}`, {
  lazy: false
});
const modal = useModal();
</script>

<template>
  <UModal>
    <UButton variant="soft" color="red" label="Close modal" @click="modal.close" />
    <div class="flex flex-col items-center my-auto p-5 shadow rounded-sm">
      <picture class="items-baseline max-w-[200px] w-full h-full mb-5 !m-auto bg-cover mr-5">
        <img class="self-baseline bg-red-400/90" :src="image"
          alt="https://m.media-amazon.com/images/M/MV5BOTI4NTNhZDMtMWNkZi00MTRmLWJmZDQtMmJkMGVmZTEzODlhXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_.jpg">
      </picture>
      <div class="flex flex-col justify-between w-75">
        <div class="mb-7">
          <div class="flex justify-between gap-2">
            <h1 class="text-4xl text-[#424242] font-bold">{{ title }}</h1>
            <div class="flex flex-nowrap justify-center items-center">
              <p class="">{{ duration }}min </p>
              <div class="ml-1 i-carbon-time" />
            </div>
          </div>
          <h2 class="text-xl my-3 text-[#424242]">{{ genre }}</h2>
          <p>{{ description }}</p>
        </div>
        <div class="flex justify-center mt-10">
          <div v-if="status === 'pending'">
            <Spinner />
          </div>
          <div v-else-if="error" class="text-red-500 text-center">
            <span class="font-bold">Error:</span> {{ error }}
          </div>
          <div v-else>
            <ul>
              <li v-for="({ id, date, auditorium }) in data" :key="id" class="flex my-8 gap-x-10">
                <div>
                  <p class="font-semibold">{{ auditorium.name }}</p>
                  <div class="flex items-center mt-1">
                    <FilmDate :date="date" :direction="'row'" />
                  </div>
                </div>
                <RouterLink :to="`/showtime/${id}`">
                  <button
                    class="px-7 py-3 from-[#670818] to-[#e00c0c] bg-gradient-to-br rounded-lg shadow-2xl text-white font-semibold hover:shadow-lg hover:shadow-red-500 hover:scale-102 duration-500 transition hover:from-[#e00c0c] hover:to-[#670818]"
                    @click="$emit('close')">
                    Book
                  </button>
                </RouterLink>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </UModal>
</template>

<style scoped></style>
