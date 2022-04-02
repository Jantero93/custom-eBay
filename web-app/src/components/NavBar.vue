<template>
  <b-navbar class="navigation-bar" toggleable="sm" type="dark" variant="dark">
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav class="d-flex flex-row">
        <b-link to="/">Home</b-link>
      </b-navbar-nav>

      <b-navbar-nav class="ms-auto d-flex flex-row">
        <b-button size="md" variant="success">List Item</b-button>
        <b-form-input class="ms-5" placeholder="Search" />
        <b-button class="ms-2" size="md" variant="outline-info" type="submit"
          >Search</b-button
        >
      </b-navbar-nav>

      <b-navbar-nav class="ms-auto d-flex flex-row">
        <b-link to="my-ebay">My eBay</b-link>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>

<style scoped>
.navigation-bar {
  font-size: 0.8em;
  font-family: Arial, Helvetica, sans-serif;
}
a {
  color: gray;
  text-decoration: none;
}

a:hover {
  color: #42b983;
}

button {
  white-space: nowrap;
  text-align: center;
}

@media screen and (max-width: 575px) {
  a {
    margin-top: 1em;
    margin-bottom: 1em;
    font-size: 2em;
  }
}
</style>
