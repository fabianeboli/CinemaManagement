import {defineStore} from 'pinia';

export const useFilmDetailsStore = defineStore("filmDetails", () => {
  const id = ref(0);
  const title = ref("");
  const year = ref("");
  const image = ref("");
  const description = ref("");
  const genre = ref("");
  const duration = ref(0);

  const setDetails = (newId: number, newTitle: string, newYear: string, newImage: string, newDescription: string, newGenre: string, newDuration: number) => {
    $reset();
    id.value = newId;
    title.value = newTitle;
    year.value = newYear;
    image.value = newImage;
    description.value = newDescription;
    genre.value = newGenre;
    duration.value = newDuration;
  }

  const $reset = () => {
    id.value = 0;
    title.value = "";
    year.value = "";
    description.value = "";
    image.value = "";
    genre.value = "";
    duration.value = 0;
  }

  return {id, title, year, description, image, genre, duration, setDetails, $reset};

})
