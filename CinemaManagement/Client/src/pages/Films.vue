<script setup lang="ts">

const {isFetching, error, data} = useFetch("http://localhost:5016/api/Films").get().json();

</script>


<template>
    <div>
      <h1>Films</h1>
      <div v-if="error">
        <Error :errorMessage="error.message"/>
      </div>
      <div v-else-if="isFetching">
        <Spinner/>
      </div>
      <div v-else>
        <ul class="flex flex-col xl:flex-row flex-wrap justify-center gap-x-10 gap-y-10">
          <li class="flex content-center justify-center" v-for="{id, title, description, duration, genre, image} in data" :key="id">
            <Film
                  :id="id"
                  :title="title"
                  :description="description"
                  :genre="genre"
                  :image="image"
                  :duration="duration"/>
          </li>
        </ul>
      </div>
    </div>

</template>

<style scoped>

</style>
