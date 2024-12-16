<script setup lang="ts">
import FilmDetails from "../components/Modals/FilmDetails.vue";
import { useFilmDetailsStore } from "../stores/filmDetails";
// import CustomModal from "./Modals/ModalButton.vue";


const { id, title, genre, duration, description, image } = defineProps<{
  id: number
  title: string
  genre: string
  duration: number
  description: string
  image: string
}>();

const modal = useModal();
const store = useFilmDetailsStore();
</script>

<template>
  <div class="flex my-auto p-5 shadow rounded-sm">
    <picture class="items-baseline max-w-[220px] w-2/3 bg-cover bg-gray-300/40 mr-5">
      <img class="self-baseline" :src="image"
        alt="https://m.media-amazon.com/images/M/MV5BOTI4NTNhZDMtMWNkZi00MTRmLWJmZDQtMmJkMGVmZTEzODlhXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_.jpg">
    </picture>
    <div class="flex flex-col justify-between w-75">
      <div class="mb-7">
        <div class="flex justify-between gap-2 ">
          <h1 class="text-4xl text-[#424242] font-bold">{{ title }}</h1>
          <div class="flex flex-nowrap justify-center  items-center ">
            <p class="">{{ duration }}min </p>
            <div class="ml-1 i-carbon-time" />
          </div>
        </div>
        <h2 class="text-xl my-3 text-[#424242]">{{ genre }}</h2>
        <p>{{ description }}</p>
      </div>
      <div class="flex justify-center mt-10">
        <button class="skew-button btn-grad"
          @click="modal.open(FilmDetails, { id, title, genre, image, description, duration })">Details</button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.skew-button {
  clip-path: polygon(10px 0%, 100% 0%, calc(100% - 10px) 100%, 0% 100%);
}

.btn-grad {
  background-image: linear-gradient(to right, #870000 0%, #190A05 51%, #870000 100%);
  margin: 10px;
  padding: 15px 45px;
  text-align: center;
  text-transform: uppercase;
  transition: 0.5s;
  background-size: 200% auto;
  color: white;
  box-shadow: 0 0 20px #eee;
  border-radius: 10px;
  display: block;
}

.btn-grad:hover {
  background-position: right center;
  /* change the direction of the change here */
  color: #fff;
  text-decoration: none;
}
</style>
