<script setup>
import { AppState } from '@/AppState.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';

const picture = computed(() => AppState.activePicture)

</script>


<template>
  <div>

    <div class="modal fade bg-image" id="pictureView" tabindex="-1" aria-labelledby="pictureModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content bg-dark-glass border text-light text-shadow">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="pictureModalLabel"> image modal </h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div class="row">
              <div class="col-md-7">
                <div>
                  <img :src="picture.imgUrl" alt="picture.description || 'Picture'">
                </div>
              </div>
              <div class="col-md-5 d-flex flex-column justify-content-between">
                <div>
                  <h4>Views:</h4>
                  <p>{{ picture.views }}</p>
                  <p> **Uploader:** {{ picture.creator?.name }} </p>
                </div>
                <div class="modal-footer justify-content-start border-top-0">
                  <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
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
  height: auto;
  display: block;
  margin: 0 auto;
}

.modal-content {
  background-color: rgba(0, 0, 0, 0.75);
  border: 1px solid rgba(255, 255, 255, 0.1);
  box-shadow: 0 0 15px rgba(0, 0, 0, 0.5);
}

.btn-close-white {
  filter: invert(1) grayscale(100%) brightness(200%);
}

.modal-header,
.modal-footer {
  border-color: rgba(255, 255, 255, 0.1);
}
</style>