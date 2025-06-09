<script setup>
import { AppState } from '@/AppState.js';
import AlbumCard from '@/components/AlbumCard.vue';
import CreateAlbumModal from '@/components/CreateAlbumModal.vue';
import PictureModal from '@/components/PictureModal.vue';
import { albumsService } from '@/services/AlbumsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted, ref } from 'vue';

const account = computed(() => AppState.account)
const albums = computed(() => {
  if (filterCategory.value == 'all') {
    return AppState.albums
  }
  return AppState.albums.filter(album => album.category == filterCategory.value)
})

onMounted(() => {
  getAlbums()
})

const filterCategory = ref('all')
const categories = [
  {
    name: 'all',
    backgroundImg: 'https://images.unsplash.com/photo-1747985323857-5c1c16b2ac47?q=80&w=1150&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
  },
  {
    name: 'aesthetics',
    backgroundImg: 'https://images.unsplash.com/photo-1523510468197-455cc987be86?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
  },
  {
    name: 'food',
    backgroundImg: 'https://images.unsplash.com/photo-1555244162-803834f70033?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
  },
  {
    name: 'games',
    backgroundImg: 'https://images.unsplash.com/photo-1511512578047-dfb367046420?q=80&w=1171&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
  },
  {
    name: 'animals',
    backgroundImg: 'https://images.unsplash.com/photo-1427434991195-f42379e2139d?q=80&w=1332&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
  },
  {
    name: 'vibes',
    backgroundImg: 'https://images.unsplash.com/photo-1555580399-49e780f216b7?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
  },
  {
    name: 'misc',
    backgroundImg: 'https://images.unsplash.com/photo-1508138221679-760a23a2285b?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
  }
]

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
      <div class="col-12">
        <div class="border-bottom border-white my-2 text-light">
          <span class="fs-5 fw-bold">Find Your Interest</span>
        </div>
      </div>
    </div>
    <div class="row border-bottom border-white my-2 text-light">
      <div v-for="category in categories" :key="'filter ' + category.id" class="col-6 col-md-3">
        <div @click="filterCategory = category.name"
          class="fw-bold fs-3 p-4 text-center rounded-2 mb-2 cat-button text-shadow text-light text-capitalize"
          :style="{ backgroundImage: `url(${category.backgroundImg})` }" role="button">
          {{ category.name }}
        </div>
      </div>
      <div v-if="account" class="col-6 col-md-3">
        <div class="fw-bold fs-3 p-4 text-center rounded-2 mb-2 create-button text-shadow text-light" role="button"
          data-bs-toggle="modal" data-bs-target="#albumModal">
          <span>New Album</span>
        </div>
      </div>
    </div>
    <div class="row">
      <div v-for="album in albums" :key="album.id" class="col-md-4">
        <AlbumCard :album="album" />
      </div>
    </div>
  </section>
  <CreateAlbumModal />
  <PictureModal />
</template>

<style scoped lang="scss">
.cat-button {
  background-size: cover;
  background-position: center;
}

.create-button {
  background-image: url('https://images.unsplash.com/photo-1622737133809-d95047b9e673?q=80&w=1332&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D');
  background-size: cover;
  background-position: center;
}
</style>
