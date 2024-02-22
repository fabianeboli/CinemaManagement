<script setup lang="ts">
// const {isFetching, error, data} = useFetch("http://localhost:5016/api/films").get().json();

const filmsMockup: any[] = [{
  id: 1,
  title: "Mockup #1",
  description: "test 231 geadasdaerrt asad",
  genre: "Drama",
  duration: 125,
  image: "sadsadag"
},
  {
    id: 2,
    title: "Mockup #2312313211",
    description: "etqafdadsfdsaf Lorem ipsum babas ssdoadoao qweq absda " +
      "fdewqr gda erwrwr asdadsa asdas afasff " +
      "fffffffffff eeeeeeeeeee eeeeeeeeeeeer rrrrrrrrrrrr",
    duration: 99,
    genre: "Comedy",
    image: ""
  }];

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
