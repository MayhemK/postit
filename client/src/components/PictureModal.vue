<script setup>
import { AppState } from '@/AppState.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';

const picture = computed(() => AppState.activePicture)

async function plusViews() {
  try {
    logger.log('yerp')
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div v-if="picture">

    <div class="modal fade bg-image" id="pictureView" tabindex="-1" aria-labelledby="pictureModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content bg-dark-glass border text-light text-shadow">
          <!-- <div class="modal-header">
          <h1 class="modal-title fs-5" id="pictureModalLabel"> image modal </h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div> -->
          <div class="modal-body">
            <div class="row">
              <div class="col-md-7">
                <div>
                  <img :src="picture.imgUrl" alt="">
                </div>
              </div>
              <div class="col-md-5">
                picture information, like views???
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.bg-image {
  background-image: url('/src/assets/img/stars.svg');
}

img {
  max-width: 100%;
}
</style>