<script setup lang="ts">
</script>


<template>
  <div class="container" style="
    padding-right: 400px;
    padding-left: 400px;">
    <div class="row">

      <label for="login" style="margin-bottom: 20px; text-align: center;">เข้าสู่ระบบ</label><br>

      <input type="text" id="Username" name="Username" class="form-control" placeholder="Username"
        style="margin-bottom: 20px;" />

      <input type="password" id="form2Example11" class="form-control" placeholder="password"
        style="margin-bottom: 20px;" />

      <div class="text-center">
        <button class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" type="button">Log
          in</button>
      </div>
      <a class="text-muted text-center" href="#!">Forgot password?</a>


    </div>
  </div>
</template>


<style>

@media (min-width: 1024px) {
  .container-sm {
    min-height: 50vh;
    display: right;
    align-items: center;
    margin-right: 100px;
  }
}

</style>

