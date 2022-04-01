<template>
  <b-navbar toggleable="md" type="dark" variant="dark">
    <b-navbar-brand href="#">eBay #2</b-navbar-brand>

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav class="d-flex flex-row">
        <b-nav-item href="#">Browse items</b-nav-item>
      </b-navbar-nav>

      <b-navbar-nav class="search-form ms-auto d-flex flex-row">
        <b-form-input class="" placeholder="Search"></b-form-input>
        <b-button class="ms-2" size="md" type="submit">Search</b-button>
      </b-navbar-nav>

      <b-navbar-nav class="ms-auto d-flex flex-row">
        <b-nav-item href="#">Login</b-nav-item>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>
