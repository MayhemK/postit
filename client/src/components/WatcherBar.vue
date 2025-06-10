<script setup>
import { albumsService } from '@/services/AlbumsService.js';
import { watchersService } from '@/services/WatchersService.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '@/AppState.js';
import { logger } from '@/utils/Logger.js';
import { WatcherProfile } from '@/models/Watcher.js';

const route = useRoute()
const props = defineProps({
  watchers: { type: Array, default: () => [] }
})

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
        <div v-if="watchers.length >= 1">
          <div class="fs-2 ">
            {{ watchers.length }}
          </div>
          <div v-if="watchers.length > 1">
            Watchers
          </div>
          <div v-else>
            Watcher
          </div>
        </div>
        <div v-else>
          Follow this Album!
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
    <div class="row mt-3">
      <div class="col-12">
        <div class="d-flex flex-wrap gap-2 justify-content-center">
          <div v-for="watcher in props.watchers" :key="watcher.id" class="text-center">
            <img :src="watcher.profile.picture" :alt="watcher.profile.name + ' profile image'"
              class="watcher-img border border-white">
            <p class="text-light mb-0">{{ watcher.profile.name }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.watcher-img {
  height: 3.7em;
  aspect-ratio: 1/1;
  border-radius: 50%;
}
</style>