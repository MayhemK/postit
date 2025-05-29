<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';

const album = computed(() => AppState.activeAlbum)
</script>


<template>
  <section>
    <div class="container">
      <div class="row">
        <div class="col-12">
          <div class="row">
            <!-- <div class="col-12" :style{ backgroundImage: `url(@{album.coverImg})`}}> -->
            cover image

            <!-- </div> -->
          </div>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped></style>