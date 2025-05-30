<script setup>
import { Picture } from '@/models/Picture.js';

defineProps({
  picture: { type: Picture, required: true }
})
</script>


<template>
  <div>
    <img :src="picture.imgUrl" alt="" class="rounded-5">
  </div>
</template>


<style lang="scss" scoped>
img {
  max-width: 100%;
}
</style>