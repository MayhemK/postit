<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { Pop } from '@/utils/Pop.js';
import { watchersService } from '@/services/WatchersService.js';
import AlbumCard from '@/components/AlbumCard.vue';

const account = computed(() => AppState.account)
const watched = computed(() => AppState.watcherAlbums)

onMounted(() => {
  getMyWatchedAlbums()
})

async function getMyWatchedAlbums() {
  try {
    await watchersService.getMyAlbums()
  }
  catch (error) {
    Pop.error(error);
  }
}

async function deleteWatcher(watcherId) {
  try {
    const confirmed = await Pop.confirm("Are you sure you don't want to follow this album anymore?")
    if (!confirmed) {
      return
    }
    await watchersService.deleteWatcher(watcherId)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>

<template>
  <div class="about text-center">
    <div v-if="account">
      <h1>Welcome {{ account.name }}</h1>
      <img class="rounded" :src="account.picture" alt="" />
      <p>{{ account.email }}</p>
      <p>You are Watching {{ watched.length }} Albums</p>
      <section class="container">
        <div class="row">
          <div class="col-12">
            <div class="row">
              <div v-for="watcher in watched" :key="watcher.id" class="col-md-4">
                <AlbumCard :album="watcher.album" />
                <div class="text-center mb-3">
                  <button @click="deleteWatcher(watcher.id)" class="btn btn-danger">Unfollow</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

    </div>
    <div v-else>
      <h1>Loading... <i class="mdi mdi-radiobox-indeterminate-variant mdi-spin"></i></h1>
    </div>
  </div>
</template>

<style scoped lang="scss">
img {
  max-width: 100px;
}
</style>
