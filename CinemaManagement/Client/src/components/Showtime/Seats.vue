<script setup lang='ts'>
import {TSeat } from "../../types";
const {id} = useRoute().params;
const {data, isFetching, error} = await useFetch(`http://localhost:5016/api/Showtimes/${id}/Seats`).get().json();

const seats: TSeat[] = data.value as TSeat[];
const rows = new Set(seats.map(seat => seat.row));

</script>
<template>
  <table role="Auditorium seats">
    <tr class="flex items-center" v-for="row in rows">
      <h1 class="font-semibold text-[#424242] mr-2 my-1"> {{ row }} </h1>
      <td v-for="seat in seats.filter(seat => seat.row === row)"> 
        <Seat 
          :row="seat.row" 
          :column="seat.column" 
          :reservedAt="seat.reservedAt" 
          :reservedByUserId="seat.reservedByUserId"
        />
      </td>
    </tr>
  </table>
</template>

<style>
</style>