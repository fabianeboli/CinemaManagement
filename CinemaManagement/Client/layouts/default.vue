<script>
import {defineComponent} from "vue";
import Navbar from "~/components/Navbar.vue";

definePageMeta({
  colorMode: "light",
});

export default defineComponent({
  components: {Navbar}
})
</script>

<template>
  <div>
    <Navbar />
    <slot />
  </div>
<!--  <main-->
<!--    px-4 py-10-->
<!--    text="center gray-700 dark:gray-200"-->
<!--  >-->
<!--    &lt;!&ndash; <RouterView /> &ndash;&gt;-->
<!--    <slot />-->
<!--    <Footer />-->
<!--    &lt;!&ndash; <div mx-auto mt-5 text-center text-sm opacity-50> &ndash;&gt;-->
<!--      &lt;!&ndash; [Default Layout] &ndash;&gt;-->
<!--    &lt;!&ndash; </div> &ndash;&gt;-->
<!--  </main>-->
</template>
