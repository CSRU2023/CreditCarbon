<script setup lang="ts">
import { RouterLink } from 'vue-router'
// import { RouterLink, RouterView } from 'vue-router'



</script>


<template>
  <!-- <header>
    <img alt="carboncredit" class="logo" src="@/assets/logo.svg" width="50" height="125" />

    <div class="wrapper">
      <HelloWorld msg="CrabonCredit" />

      <nav style="margin-top: 2px;">
        <button type="button" class="btn btn-success">Success</button>
        <RouterLink to="/home">หน้าแรก</RouterLink>
        <RouterLink to="/about">เกี่ยวกับ</RouterLink>
        <RouterLink to="/member">สมัครสมาชิก</RouterLink>
        <RouterLink to="/external">การซื้อขายเครดิตคาร์บอร์น</RouterLink>
        <RouterLink to="/event">ข่าวสาร</RouterLink>
        <RouterLink to="/contact">ติดต่อ</RouterLink>

      </nav>
    </div>
  </header> -->


  <div class="position-absolute top-10 start-50 translate-middle container-fluid" style="top: 40px;">
    <div class="align-items-center">
      <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd;">
        <div class="container-fluid">
          <img alt="carboncredit" class="logo" src="@/assets/logo.svg" width="50" height="50" />
          <a class="navbar-brand" href="#"><h2>Credit Carbon <br></h2></a>
          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarScroll"
            aria-controls="navbarScroll" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse container" id="navbarScroll">
            <ul class="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll" style="--bs-scroll-height: 100px;">
              <li class="nav-item">
                <a class="nav-link active" aria-current="page" href="/home">หน้าแรก</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/about">เกี่ยวกับ</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/member">สมัครสมาชิก</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/home">การซื้อขายเครดิตคาร์บอร์น</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/event">ข่าวสาร</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/contact">ติดต่อ</a>
              </li>
              <!-- <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarScrollingDropdown" role="button"
                  data-bs-toggle="dropdown" aria-expanded="false">
                  Link
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarScrollingDropdown">
                  <li><a class="dropdown-item" href="#">Action</a></li>
                  <li><a class="dropdown-item" href="#">Another action</a></li>
                  <li>
                    <hr class="dropdown-divider">
                  </li>
                  <li><a class="dropdown-item" href="#">Something else here</a></li>
                </ul>
              </li> -->
              <!-- <li class="nav-item">
                <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Link</a>
              </li> -->
            </ul>
            <form class="d-flex">
              <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
              <button class="btn btn-outline-success" type="submit">Search</button>
            </form>
          </div>
          <a  href="/login" class="btn btn-outline-dark" type="submit"> <font-awesome-icon icon="fa-solid fa-user" /> LOGIN</a>
        </div>
      </nav>
    </div>
  </div>
  <RouterView />
</template>

<!-- 
<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }

  nav {
    text-align: center;
    margin-center: -1rem;
    font-size: 1rem;

    padding: 1rem 0;
    margin-top: 1rem;
  }
}
</style> -->
