<script setup>
import { Picture } from '@/models/Picture.js';
import { picturesService } from '@/services/PictureService.js';
import { Pop } from '@/utils/Pop.js';
import PictureModal from './PictureModal.vue';
import { logger } from '@/utils/Logger.js';

const props = defineProps({
  picture: { type: Picture, required: true }
})

async function setActivePicture() {
  try {
    picturesService.setActivePicture(props.picture)
    await plusViews()
  }
  catch (error) {
    Pop.error(error);
  }

  async function plusViews() {
    try {
      picturesService.plusViews(props.picture.id)
    }
    catch (error) {
      Pop.error(error);
    }
  }
}

</script>


<template>
  <div type="button" data-bs-toggle="modal" data-bs-target="#PicModal" @click="setActivePicture()">
    <div class="">
      <img :src="picture.imgUrl" alt="picture.description || 'Picture'" class="rounded-5">
    </div>
  </div>
  <!-- <img :src="picture.imgUrl" alt="" class="rounded-5"> -->
</template>


<style lang="scss" scoped>
img {
  max-width: 100%;
  height: auto;
  object-fit: cover;
}
</style>