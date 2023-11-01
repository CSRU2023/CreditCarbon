<script setup lang="ts">
import { RouterView } from 'vue-router'
</script>

<template>
  <div class="position-absolute top-0 start-50 translate-middle-x p-0 container-fluid">
    <div class="align-items-center">
      <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd">
        <div class="container-fluid">
          <img alt="carboncredit" class="logo" src="@/assets/img/bg.png" width="100" height="70" />
          <a class="navbar-brand" href="#">
            <h2 class="container mr-5">Credit Carbon <br /></h2>
          </a>
          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarScroll"
            aria-controls="navbarScroll" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse container" id="navbarScroll">
            <ul class="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll" style="--bs-scroll-height: 100px">
              <li class="nav-item">
                <a class="nav-link active" aria-current="page" href="/home">หน้าแรก</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/about">เกี่ยวกับ</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/market">ตลาดซื้อขายเครดิตคาร์บอร์น</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/project-carbon">รายการเครดิตคาร์บอร์น</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/contact">ติดต่อ</a>
              </li>
              <!-- <li class="nav-item">
                <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Link</a>
              </li> -->
            </ul>
            <!-- <form class="d-flex">
              <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
              <button class="btn btn-outline-success" type="submit">Search</button>
            </form> -->
          </div>
          <div class="btn-group me-2">
                <button type="button" class="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown"
                  data-bs-display="static" aria-expanded="false">
                  <font-awesome-icon icon="fa-solid fa-user" /> (ชื่อ)
                </button>
                <ul class="dropdown-menu dropdown-menu-end dropdown-menu-lg-start">
                  <li><a class="dropdown-item" href="#">ข้อมูลส่วนตัว</a></li>
                  <li><a class="dropdown-item" href="Wallet">กระเป๋า</a></li>
                  <li><a class="dropdown-item" href="User">User</a></li>
                  <li>
                    <hr class="dropdown-divider" />
                  </li>
                  <li><a class="dropdown-item" href="#">ออกจากระบบ</a></li>
                </ul>
              </div>
          <a class="btn btn-outline-dark me-2" type="submit" href="/login">
            <font-awesome-icon icon="fa-solid fa-user" /> เข้าสู่ระบบ</a>
          <a class="btn btn-outline-info" type="submit" href="/member">
            <font-awesome-icon icon="fa-solid fa-user" /> ลงทะเบียน</a>
        </div>
      </nav>
      <nav class="navbar navbar-expand-lg navbar-light container">
        <RouterView />
      </nav>
    </div>
  </div>

  <font-awesome-icon id="fa-check-icon" icon="fa-solid fa-check" class="d-none text-success fa-lg" />
  <font-awesome-icon id="fa-trash-icon" icon="fa-solid fa-trash-can" class="d-none" />
  <font-awesome-icon id="fa-pen-to-square-icon" icon="fa-solid fa-pen-to-square" class="d-none" />
  <font-awesome-icon id="fa-eye-icon" icon="fa-solid fa-eye" class="d-none" />
  <font-awesome-icon id="fa-file-icon" icon="fa-solid fa-file" class="d-none" />
  <font-awesome-icon id="fa-cart-shopping-icon" style="color: #1e8538;" icon="fa-solid fa-cart-shopping" class="d-none" />
</template>
