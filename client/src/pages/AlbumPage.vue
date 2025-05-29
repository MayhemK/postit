<script setup>
import { AppState } from '@/AppState.js';
import { albumsService } from '@/services/AlbumsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const album = computed(() => AppState.activeAlbum)

onMounted(() => {
  getAlbumById()
})

async function getAlbumById() {
  try {
    const albumId = route.params.albumId
    await albumsService.getAlbumById(albumId)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <section>
    <div v-if="!album" class="text-center fw-bold fs-1 text-light mt-5">Error loading page</div>
    <div v-else class="container">
      <div class="row">
        <div class="col-12">
          <div class="row">
            <div class="col-12 p-5 rounded-5 cover-img" :style="{ backgroundImage: `url(${album.coverImg})` }">
              <p>e</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped></style>