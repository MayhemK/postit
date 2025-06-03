<script setup>
import { albumsService } from '@/services/AlbumsService.js';
import { watchersService } from '@/services/WatchersService.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '@/AppState.js';
import { logger } from '@/utils/Logger.js';

const route = useRoute()
const watchers = computed(() => AppState.watcherProfiles)


onMounted(() => {
  getWatchersByAlbumId()
})

async function getWatchersByAlbumId() {
  try {
    const albumId = route.params.albumId
    await watchersService.getWatchersByAlbumId(albumId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function createWatcher() {
  try {
    const watcherData = { albumId: route.params.albumId }
    await watchersService.createWatcher(watcherData)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div class="row text-center mb-3">
    <div class="col-7">
      <div class="bg-dark-glass h-100 rounded-4 d-flex flex-column justify-content-around mx-0">
        <div class="fs-2 ">
          <!-- {{ watchers.length }} -->
          N/A
        </div>
        <div>
          watchers
        </div>
      </div>
    </div>
    <div class="col-5">
      <div>
        <b @click="createWatcher()" class="btn btn-success mx-0 px-3">
          <p class="mdi mdi-account-heart fs-3 mb-1 rounded-4"></p>
          <p class="d-none d-md-block">Join</p>
        </b>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <!-- <div v-for="watcher in watchers" :key="watcher.accountId">
          hi

        </div> -->
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>