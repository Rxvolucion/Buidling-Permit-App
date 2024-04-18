<template>
    <h1 class="mb-4">Approve/Reject Permit</h1>
    <div class="approve-reject-permit">
        <!-- <h3 class="mb-4">Permit ID: {{ this.$route.params.permitId }}</h3> -->
      
      <div class="container">
        <ApproveRejectPermit />
      </div>
    </div>
  </template>

<script>
import ApproveRejectPermit from '../components/ApproveRejectPermit.vue'

export default {
    computed: {

    },
    components: {
        ApproveRejectPermit
    }

}

</script>


<style scoped>
.approve-reject-permit {
    background-color: #c2bdbd75;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  padding: 2rem;
}
</style>