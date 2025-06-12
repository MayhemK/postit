<script setup>
import CreatePictureForm from './CreatePictureForm.vue';


</script>


<template>
  <div class="modal fade bg-image" id="pictureModal" tabindex="-1" aria-labelledby="pictureModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-lg">
      <div class="modal-content bg-dark-glass border text-light text-shadow">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="pictureModalLabel">Submit a Picture! </h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div>
            <CreatePictureForm />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.bg-image {
  background-image: url('/src/assets/img/stars.svg');
  background-size: cover;
}
</style>