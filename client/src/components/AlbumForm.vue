<script setup>
const categories = [' Aesthetics', 'Food', 'Games', 'Animals', 'Vibes', 'Misc']
</script>


<template>
  <form action="" class="text-dark">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="albumTitle" placeholder="Album Title" minlength="3" maxlength="25"
        required>
      <label for="albumTitle">Album Title</label>
    </div>
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="albumDescription" placeholder="Album Description" minlength="15"
        maxlength="250" required>
      <label for="albumDescription">Album Description</label>
    </div>
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="albumImage" placeholder="Album Image" maxlength="2000" required>
      <label for="albumImage">Album Image</label>
    </div>
    <div class="form-floating mb-3">
      <select class="form-select" id="albumCategory" required>
        <option selected>Choose Album Category</option>
        <option v-for="category in categories" :key="'option ' + category" :value="category">
          {{ category }}
        </option>
      </select>
      <label for="albumCategory">Album Category</label>
    </div>
  </form>
</template>


<style lang="scss" scoped></style>

<!-- title
description
coverimg
category -->