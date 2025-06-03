<script setup>
import { Picture } from '@/models/Picture.js';

defineProps({
  picture: { type: Picture, required: true }
})

async function setActivePicture() {

}
</script>


<template>
  <div type="button" data-bs-toggle="modal" data-bs-target="#pictureModal" @click="setActivePicture()">
    <div class="">
      <img :src="picture.imgUrl" alt="" class="rounded-5">
    </div>
  </div>
</template>


<style lang="scss" scoped>
img {
  max-width: 100%;
}
</style>