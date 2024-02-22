<script setup lang="ts">
import {useModal} from "~/composables/useModal";
import SignIn from "~/components/Modals/SignIn.vue";
import SignUp from "~/components/Modals/SignUp.vue";

const modal = useModal();

</script>

<template>
  <nav>
    <div class="flex justify-evenly text-[#212121] text-xl xl:text-2xl">
      <div class="flex justify-between gap-x-8 xl:gap-x-10 last:gap-x-0">
        <RouterLink class="hover:font-bold hover:text-red-7" to="/">Home</RouterLink>
        <RouterLink class="hover:font-bold hover:text-red-7" to="/showtimes">Showtimes</RouterLink>
        <RouterLink class="hover:font-bold hover:text-red-7" to="/films">Films</RouterLink>
      </div>
      <div class="i-carbon-sun hover:text-red-7 relative right-14 mx-auto"/>
      <div class="flex gap-x-8 xl:gap-x-10">
        <a class="hover:font-bold cursor-pointer hover:text-red-7" @click="modal.openModal(SignIn)">Sign in</a>
        <a class="hover:font-bold cursor-pointer hover:text-red-7" @click="modal.openModal(SignUp)">Sign up</a>
      </div>
    </div>
    <RouterLink to="/[...all]">404</RouterLink>
    <Teleport to="#modal">
      <Transition>
        <component :is="modal.component.value"
                   v-if="modal.show.value"
                   @close="modal.hideModal"/>
      </Transition>
    </Teleport>
  </nav>
</template>

<style scoped>
.v-enter-from,
.v-from-to {
  opacity: 0;
}

.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}
</style>
