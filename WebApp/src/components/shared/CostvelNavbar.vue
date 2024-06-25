<script setup lang="ts">
import logo from '@/assets/logo.png';
</script>

<template>
  <nav class="navbar navbar-expand-md bg-primary">
    <div class="container">
      <router-link class="d-inline-flex align-items-center navbar-brand" to="/">
        <img :src="logo" class="logo-image" alt="Logo da aplicação Costvel" />
        <span class="text-white">Costvel</span>
      </router-link>
    </div>
  </nav>
</template>

<style scoped>
.logo-image {
  height: 35px;
  width: 35px;
  margin-right: 10px;
}
</style>
