<script setup>
import { albumsService } from '@/services/AlbumsService.js';
import { Pop } from '@/utils/Pop.js';
import { Modal } from 'bootstrap/dist/js/bootstrap.bundle.js';
import { ref } from 'vue';

const categories = [' Aesthetics', 'Food', 'Games', 'Animals', 'Vibes', 'Misc']
const editableData = ref({
  title: '',
  description: '',
  coverImg: '',
  category: ''
})

async function createAlbum() {
  try {
    await albumsService.createAlbum(editableData.value)
    editableData.value = {
      title: '',
      description: '',
      coverImg: '',
      category: ''
    }
    Modal.getOrCreateInstance('#albumModal').hide()
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <form @submit.prevent="createAlbum()" class="text-dark">
    <div class="form-floating mb-3">
      <input v-model="editableData.title" type="text" class="form-control" id="albumTitle" placeholder="Album Title"
        minlength="3" maxlength="25" required>
      <label for="albumTitle">Album Title</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="editableData.description" type="text" class="form-control" id="albumDescription"
        placeholder="Album Description" minlength="15" maxlength="250" required>
      <label for="albumDescription">Album Description</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="editableData.coverImg" type="text" class="form-control" id="albumImage" placeholder="Album Image"
        maxlength="2000" required>
      <label for="albumImage">Album Image</label>
    </div>
    <div v-if="editableData.coverImg" class="mb-3">
      <p class="text-light text-center text-decoration-underline">Image preview</p>
      <img :src="editableData.coverImg" alt="Preview of your cover image" class="w-100 rounded-3 border">
    </div>
    <div class="form-floating mb-3">
      <select v-model="editableData.category" class="form-select" id="albumCategory" required>
        <option v-for="category in categories" :key="'option ' + category" :value="category">
          {{ category }}
        </option>
      </select>
      <label for="albumCategory">Album Category</label>
    </div>
    <div class="text-center">
      <button type="submit" class="btn btn-primary">Save changes</button>
    </div>
  </form>
</template>


<style lang="scss" scoped></style>

<!-- title
description
coverimg
category -->