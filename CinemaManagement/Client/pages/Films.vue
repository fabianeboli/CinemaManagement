<script setup lang="ts">
import Error from "../components/Utils/Error.vue";
import Spinner from "../components/Utils/Spinner.vue";
import Film from "../components/Film.vue";

const { status, error, data } = await useFetch("http://localhost:5016/api/Films");
</script>

<template>
  <div>
    <h1>Films</h1>
    <div v-if="error">
      <Error :error-message="error.message" />
    </div>
    <div v-else-if="status === 'pending'">
      <Spinner />
    </div>
    <div v-else>
      <ul class="flex flex-col xl:flex-row flex-wrap justify-center gap-x-10 gap-y-10">
        <li
          v-for="{ id, title, description, duration, genre, image } in data" 
          :key="id"
          class="flex content-center justify-center">
          <Film :id="id" :title="title" :description="description" :genre="genre" :image="image" :duration="duration" />
        </li>
      </ul>
    </div>
  </div>

</template>

<style scoped></style>
