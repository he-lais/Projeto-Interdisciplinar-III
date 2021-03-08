<template>
    <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
      <a class="sidebar-brand d-flex align-items-center justify-content-center" href="index.html">
        <div class="sidebar-brand-icon rotate-n-15">
          <i class="fas fa-balance-scale"></i>
        </div>
        <div class="sidebar-brand-text mx-3">DocJur</sup></div>
      </a>

      <!-- Divider -->
      <hr class="sidebar-divider my-0">

      <!-- Nav Item - Dashboard -->
      <li class="nav-item">
        <a class="nav-link" href="/">
          <i class="fas fa-fw fa-tachometer-alt"></i>
          <span>Dashboard</span></a>
      </li>

      <hr class="sidebar-divider">
      <div class="sidebar-heading">Gestão de Documentos</div>

      <li class="nav-item">
        <a class="nav-link" href="/document_create">
          <i class="fas fa-fw fa-pen-alt"></i>
          <span>Gerar Documento</span></a>
      </li>


      <li class="nav-item">
        <a class="nav-link" href="/documentos">
          <i class="fas fa-fw fa-history"></i>
          <span>Histórico</span></a>
      </li>

      <hr class="sidebar-divider">
      <div class="sidebar-heading">Cadastros</div>

      <li class="nav-item">
        <a class="nav-link" href="/usuarios">
          <i class="fas fa-fw fa-user"></i>
          <span>Usuários</span></a>
      </li>

      <li class="nav-item">
        <a class="nav-link" href="/modelos_documento">
          <i class="fas fa-fw fa-file-alt"></i>
          <span>Modelos De Documentos</span></a>
      </li>

      <hr class="sidebar-divider d-none d-md-block">
    </ul>
</template>

<script>
export default {
    data: function(){
        return {}
    },
    methods: {}
}
</script>
