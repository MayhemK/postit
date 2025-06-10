<script setup>
import { picturesService } from '@/services/PictureService.js';
import { Pop } from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

const editablePictureData = ref({
  imgUrl: '',
  albumId: route.params.albumId
})

async function createPicture() {
  try {
    await picturesService.createPicture(editablePictureData.value)
    editablePictureData.value.imgUrl = ''
    Pop.success('Picture successfully created!')
    const modalElement = document.getElementById('pictureModal')
    if (modalElement) {
      const modal = Modal.getInstance(modalElement) || new Modal(modalElement)
      modal.hide()
      modalElement.addEventListener('hidden.bs.modal', () => {
        const backdrop = document.querySelector('.modal-backdrop')
        if (backdrop) {
          backdrop.remove()
        }
      })
    }
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <form @submit.prevent="createPicture()">
    <div class="form-floating mb-3">
      <input v-model="editablePictureData.imgUrl" type="url" class="form-control" id="pictureImgUrl"
        placeholder="Picture URL" maxlength="1000" required>
      <label for="pictureImgUrl">Picture URL</label>
    </div>
    <div class="text-end">
      <button class="btn btn-primary" type="submit">Submit</button>
    </div>
  </form>
</template>


<style lang="scss" scoped></style>