<script setup>
import { AppState } from '@/AppState.js';
import CreatePictureModal from '@/components/CreatePictureModal.vue';
import PictureCard from '@/components/PictureCard.vue';
import WatcherBar from '@/components/WatcherBar.vue';
import { albumsService } from '@/services/AlbumsService.js';
import { picturesService } from '@/services/PictureService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const album = computed(() => AppState.activeAlbum)
const pictures = computed(() => AppState.pictures)
const userInfo = computed(() => AppState.account)

onMounted(() => {
  getAlbumById()
  getPicturesByAlbum()
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

async function archiveAlbum() {
  try {
    const albumId = route.params.albumId
    await albumsService.archiveAlbum(albumId)
  }
  catch (error) {
    Pop.error(error);
  }
}


async function getPicturesByAlbum() {
  try {
    const albumId = route.params.albumId
    await picturesService.getPicturesByAlbum(albumId)
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
            <div class="col-12">
              <div class="p-5 rounded-5 bg-img d-flex align-items-end"
                :style="{ backgroundImage: `url(${album.coverImg})` }">
                <div class="bg-dark-glass rounded-5 px-5 py-3 flex-grow-1">
                  <div class="mb-4">
                    <p class="text-center fs-2 fw-bold">{{ album.title }}</p>
                    <p v-if="album.description" class="fs-4 text-center">{{ album.description }}</p>
                    <p v-else class="fs-4">A nice album</p>
                    <div class="d-flex justify-content-between align-items-center mb-3">
                      <div v-if="album.archived" class="text-centered fs-5">
                        <span class="mdi mdi-alert">This Album is archived and not accepting new pictures</span>
                        <span class="mdi mdi-alert"></span>
                      </div>
                      <div v-else class="text-decoration-underline fs-4">Accepting Submissions!</div>
                      <div class="d-flex justify-content-end align-items-center gap-3">
                        <p class="mb-0">{{ album.creator.name }}</p>
                        <img :src="album.creator.picture" :alt="`${album.creator.name} profile image`"
                          class="creator-img">
                      </div>
                    </div>
                    <div class="container">
                      <div class="row align-items-center">
                        <div class="col-2">
                          <div class="bg-primary rounded-3 text-center text-capitalize m-0 p-2">{{ album.category }}
                          </div>
                        </div>
                        <div v-if="userInfo && album.creator.id == userInfo.id" class="col-2">
                          <div v-if="album.archived" @click="archiveAlbum()"
                            class="bg-danger rounded-3 text-center text-capitalize m-0 p-2" type="button">Unlock
                            <span class="mdi mdi-lock-open-variant"></span>
                          </div>
                          <div v-else @click="archiveAlbum()"
                            class="bg-danger rounded-3 text-center text-capitalize m-0 p-2" type="button">Archive
                            <span class="mdi mdi-lock"></span>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-4">
              <div class="row mt-4">
                <div class="col-12 text-center">
                  <WatcherBar />
                  <div v-if="userInfo" class="btn btn-warning" :disabled="album.archived" data-bs-toggle="modal"
                    data-bs-target="#pictureModal">
                    Submit Picture
                  </div>
                  <div>modal</div>
                </div>
              </div>
            </div>
            <div class="col-8">
              <div class="container masonry-container">
                <div class="row mt-4">
                  <div v-for="picture in pictures" :key="picture.id" class="col-md-4">
                    <PictureCard :picture="picture" />
                  </div>
                  <div class="bg-dark-glass">
                    Like what you see? Log in and Follow this album, Maybe even submit more pictures!
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
  <CreatePictureModal />
</template>


<style lang="scss" scoped>
.bg-img {
  min-height: 40dvh;
  background-size: cover;
  background-position: center;
}

.creator-img {
  height: 3.7em;
  aspect-ratio: 1/1;
  border-radius: 50%;
}

.masonry-container {
  columns: 200px;
}

.masonry-container>* {
  display: inline-block;
  break-inside: avoid;
}

.masonry-container img {
  width: 100%;
}

.picture-button {
  position: fixed;
  bottom: 0;
  right: 0;
}
</style>