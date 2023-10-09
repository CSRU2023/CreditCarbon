
<template lang="">
       <div class="container">
              <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
              <div class="carousel-indicators">
              <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
              <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
              <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
              </div>
              <div class="carousel-inner">
              <div class="carousel-item active">
              <img src="@/assets/img/car3.jpg" class="d-block w-500" alt="...">
              </div>
              <div class="carousel-item">
              <img src="@/assets/img/car4.jpg" class="d-block w-500" alt="...">
              
              </div>
              <div class="carousel-item">
              <img src="@/assets/img/car1.jpg" class="d-block w-500" alt="...">
              </div>
              </div>
              <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Previous</span>
              </button>
              <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
              <span class="carousel-control-next-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Next</span>
              </button>

              <h1 class="display-3">เกี่ยวกับ </h1>
        
              

              

       
            </div>
       
             
       
       </div>
</template>

<script>
export default (await import('vue')).defineComponent({

})
</script>

<style lang="">


</style>











<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
