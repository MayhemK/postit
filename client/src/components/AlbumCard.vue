<script setup>
import { Album } from '@/models/Album.js';

defineProps({
  album: { type: Album, required: true }
})
</script>


<template>
  <section class="">
    <div :style="{ backgroundImage: `url(${album.coverImg})` }">
      <div>
        <p>{{ album.title }}</p>
        <div>
          <img :src="album.creator.picture" alt="">
          <span>{{ album.creator.name }}</span>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>
img {
  max-height: 2rem;
}
</style>