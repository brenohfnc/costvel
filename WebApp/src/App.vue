<script setup lang="ts">
import { RouterView } from 'vue-router';
import CostvelNavbar from '@/components/shared/CostvelNavbar.vue';
import CostvelToast from '@/components/shared/CostvelToast.vue';
</script>

<template>
  <header>
    <costvel-navbar />
  </header>
  <main class="container my-4">
    <suspense>
      <RouterView />
    </suspense>
  </main>
  <costvel-toast />
</template>
