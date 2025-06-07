<script setup>
import { Picture } from '@/models/Picture.js';
import { picturesService } from '@/services/PictureService.js';
import { Pop } from '@/utils/Pop.js';
import PictureModal from './PictureModal.vue';

const props = defineProps({
  picture: { type: Picture, required: true }
})

async function setActivePicture() {
  try {
    picturesService.setActivePicture(props.picture)
  }
  catch (error) {
    Pop.error(error);
  }
}

// function plusViews() {
//   try {
//     picturesService.plusViews(props.picture.id)
//   }
//   catch (error) {
//     Pop.error(error);
//   }
// }
</script>


<template>
  <!-- <div type="button" data-bs-toggle="modal" data-bs-target="#pictureView" @click="setActivePicture()">
    <div class="">
      <img :src="picture.imgUrl" alt="" class="rounded-5">
    </div>
  </div> -->
  <img :src="picture.imgUrl" alt="" class="rounded-5">
</template>


<style lang="scss" scoped>
img {
  max-width: 100%;
}
</style>