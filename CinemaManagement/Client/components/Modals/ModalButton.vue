<script setup lang='ts'>
const { component, name, _props } = defineProps<{ component: any, name: string, _props?: object }>();

const toast = useToast();
const modal = useModal();

function openModal() {
  console.log("HERE");
  modal.open(component(_props), {
    onSuccess() {
     console.log("Open Modal");
    }
  });
}

const closeModal = () => {
  console.log("HERE");
  modal.close(component, {
    onSuccess() {
      console.log("Close Modal");
    }
  });
};
</script>

<template>
  <UButton variant="soft" color="violet" label="Reveal modal" @click="openModal" @close-modal="closeModal">{{ name }}</UButton>
</template>

<style scoped></style>