import { h } from 'vue';
<template>
 <div>
    <div
      class="bg-image p-5 text-center shadow-1-strong  mb-5"
    >       <h1 class="display-2">ลงทะเบียนเปิดบัญชี</h1>
      
    </div>
        <div class="container text-center">
          <h1>เลือกประเภทบัญชี </h1>
              <p>กรุณาเลือกประเภทบัญชีที่ต้องการเปิด</p>
             
          
              <div class="row" >
            <div class="col">
              <!-- <h4><p class="my-10">บุคคลทั่วไป </p></h4> -->
              
              <img src="@/assets/img/hu.png" class="img-fluid rounded" />
              <a class="nav-link" href="/regis"> <h1>บุคคลทั่วไป</h1> </a>
            </div>
            <div class="col mt-1" >
          
            <img src="@/assets/img/buil.png" class="img-fluid rounded" />
           <a class="nav-link" href="/about"> <h1>นิติบุคคล</h1> </a>
      </div>
<!--End Column-->
                        
             </div>    
        </div>
      </div>
  
  







<!--   
  <div class="center">
    <h1 class="display-5">ลงทะเบียนเปิดบัญชี</h1>
    

    <h1 class="display-6">เลือกประเภทบัญชี</h1>
    <p class="text-muted">เลือกประเภทบัญชี text-muted</p>
  
  <div class="center1">
    <a class="nav-link" href="/about"> <h1>บุคคลทั่วไป</h1></a>
   </div>
   <div class="center2">
    <a class="nav-link" href="/about"> <h1>นิติบุคคล</h1> </a>
    

    </div>
    <div class="center3">

    
  </div>

</div> -->



</template>

<!-- <style scoped>
.center {
  margin: auto;
  width: 50%;
  border: 3px solid blue;   
  padding: 5%;
  text-align: center;
}

.center1 {
  margin: 0 auto;
  width: 100%;
  border: 1px solid rgb(109, 109, 109);   
  padding: 20%;
  text-align: center;
  background-color: rgb(64, 64, 255) ;
}

.center2 {
  margin: 0 auto;
  width: 100%;
  border: 1px solid rgb(109, 109, 109);   
  padding: 20%;
  color: #008aa9;
  text-align: center;
  background-color: rgb(233, 40, 104) ;
}

.center3 {
  max-width: 960px;
  height: 500px;
  margin: 0 auto;
  border: 1 px solid rebeccapurple;
  text-align: center;
  display: flex;
  background-color: rgb(233, 40, 104) ;
  color: #000;

}




</style> -->
