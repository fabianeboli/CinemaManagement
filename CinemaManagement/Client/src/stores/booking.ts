import { defineStore } from 'pinia';
import { TSeat } from '../types'

export const useTicketStore = defineStore("ticket", () => {
  const selectedSeats = ref<TSeat[]>([]);
  const cinema = ref("");
  const movie = ref("");
  const date = ref("");
  const time = ref("");
  const totalPrice = ref(0);
  let isLoading = false;
  const isLoadingGetter = computed(() => isLoading.value);

  const reserveSeat = (seat: TSeat) => {
    selectedSeats.value = [...selectedSeats.value, seat];
  }

  const unreserveSeat = (seat: TSeat) => {
    selectedSeats.value = selectedSeats.value.filter(s => s.id !== seat.id);
  }

  const submitBook = async (userId: number, showtimeId: number) => {
    isLoading = true;
    const buyTicket = await useFetch("http://localhost:5016/api/Tickets").post({ userId, showtimeId, totalPrice: totalPrice.value }).execute();

    const reserveSeats = await useFetch("http://localhost:5016/api/Seats").put(selectedSeats.value.map(s => s.id)).execute();

    if (postBook) {
      $reset();
    }
    isLoading = false;
  }


  const $reset = () => {
    selectedSeats.value = [];
    cinema.value = "";
    movie.value = "";
    date.value = "";
    time.value = "";
    totalPrice.value = 0;
  }
});