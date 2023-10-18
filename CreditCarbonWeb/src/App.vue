<script setup lang="ts">
import { RouterView } from 'vue-router'

</script>

<template>
   <div class="position-absolute top-0 start-50 translate-middle-x p-0 container-fluid">
    <div class="align-items-center">
      <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd;">
        <div class="container-fluid">
          <img alt="carboncredit" class="logo" src="@/assets/logo.svg" width="50" height="50" />
          <a class="navbar-brand" href="#">
            <h2>Credit Carbon <br></h2>
          </a>
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
                <a class="nav-link" href="/contact">ติดต่อ</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/user">user</a>
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
          <a class="btn btn-outline-dark" type="submit" href="/login" > <font-awesome-icon icon="fa-solid fa-user" />
            LOGIN</a>
        </div>
      </nav>
      <nav class="navbar navbar-expand-lg navbar-light container">
        <RouterView />
      </nav>
    </div>
  </div>
  
  <font-awesome-icon
    id="fa-check-icon"
    icon="fa-solid fa-check"
    class="d-none text-success fa-lg" />
  <font-awesome-icon
    id="fa-trash-icon"
    icon="fa-solid fa-trash-can"
    class="d-none" />
  <font-awesome-icon
    id="fa-pen-to-square-icon"
    icon="fa-solid fa-pen-to-square"
    class="d-none" />
  <font-awesome-icon id="fa-eye-icon" icon="fa-solid fa-eye" class="d-none" />
</template>

