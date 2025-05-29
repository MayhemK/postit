<script setup>
import { Picture } from '@/models/Picture.js';

defineProps({
  image: { type: Picture, required: true }
})
</script>


<template>
  <div>
    <div>{{ image }}</div>
    <div>hi</div>
  </div>
</template>


<style lang="scss" scoped></style>