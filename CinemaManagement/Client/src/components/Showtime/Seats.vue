<script setup lang='ts'>
import {TSeat } from "../../types";
const {id} = useRoute().params;


const {data, isFetching, error} = await useFetch(`http://localhost:5016/api/Showtimes/${id}/Seats`).get().json();
const seats: TSeat[] = data.value as TSeat[];

</script>

<template>
<div>
  Seat
  <ul>
    <li v-for="seat in seats">
      <Seat :row="seat.row" :column="seat.column" :reservedAt="seat.reservedAt" :reservedByUserId="seat.reservedByUserId"/>
    </li>
  </ul>
</div>
</template>

<style>

</style>