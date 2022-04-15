<template>
  <b-modal
    id="image-zoom-modal"
    class="modal-fullscreen"
    no-stacking
    size="lg"
    ok-only
    ok-title="Close"
    ok-variant="danger"
  >
    <b-img :src="image" />
  </b-modal>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'ImageModal',
  props: {
    image: {
      required: true,
      type: String
    }
  }
});
</script>

<style scoped>
img {
  width: 100%;
  height: 100%;
  object-fit: contain;
}

@media (min-width: 992px) {
  .modal .modal-huge {
    max-width: 90% !important;
    width: 90% !important;
  }
}
</style>
