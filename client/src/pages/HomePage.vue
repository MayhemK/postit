<script setup>
import { AppState } from '@/AppState.js';
import AlbumCard from '@/components/AlbumCard.vue';
import { albumsService } from '@/services/AlbumsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const albums = computed(() => AppState.albums)

onMounted(() => {
  getAlbums()
})

async function getAlbums() {
  try {
    await albumsService.getAlbums()
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>

<template>
  <section class="container mt-3 bg-stars">
    <div class="row">
      <div v-for="album in albums" :key="album.id" class="col-md-4">
        <AlbumCard :album="album" />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss"></style>
