<script setup>
import AlbumForm from './AlbumForm.vue';


</script>


<template>
  <div class="modal fade bg-image text-light" id="albumModal" tabindex="-1" aria-labelledby="albumModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-lg">
      <div class="modal-content bg-dark-glass border text-light text-shadow">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="albumModalLabel">Create New Album! </h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div>
            <AlbumForm />
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