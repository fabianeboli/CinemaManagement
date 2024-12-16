import { defineStore } from "pinia";
import type { TSeat } from "../types";

export const useBookingStore = defineStore("booking", () => {
  const selectedSeatsIds = ref<string[]>([]);
  const cinema = ref("");
  const movie = ref("");
  const date = ref("");
  const time = ref("");
  const totalPrice = ref(0);
  let isLoading = false;
  const isLoadingGetter = computed(() => isLoading.value);

  const reserveSeat = (seat: string) => {
    selectedSeatsIds.value = [...selectedSeatsIds.value, seat];
  };

  const unreserveSeat = (seat: string) => {
    selectedSeatsIds.value = selectedSeatsIds.value.filter(s => s !== seat);
  };

  const submitBook = async (userId: number, showtimeId: number) => {
    isLoading = true;
    const buyTicket = await useFetch("http://localhost:5016/api/Tickets").post({ userId, showtimeId, totalPrice: totalPrice.value }).execute();

    const reserveSeats = await useFetch("http://localhost:5016/api/Seats").put(selectedSeatsIds.value.map(s => s.id)).execute();

    if (postBook) {
      $reset();
    }
    isLoading = false;
  };


  const $reset = () => {
    selectedSeatsIds.value = [];
    cinema.value = "";
    movie.value = "";
    date.value = "";
    time.value = "";
    totalPrice.value = 0;
  };

  return {
    selectedSeats: selectedSeatsIds,
    cinema,
    movie,
    date,
    time,
    totalPrice,
    isLoading,
    isLoadingGetter,
    reserveSeat,
    unreserveSeat,
    submitBook,
    $reset
  };
});