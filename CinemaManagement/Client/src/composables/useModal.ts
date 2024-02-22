
const show = ref<boolean>(false);

const component = ref<any>(null);

export function useModal() {
  return {
    show,
    component,
    showModal: () => show.value = true,
    hideModal: () => show.value = false,
    toggleModal: () => show.value = !show.value,
    openModal: (object: any, props?: object) => {
      component.value = markRaw(object);
      console.log(component.value);
      show.value = true;
    }
  }
}

