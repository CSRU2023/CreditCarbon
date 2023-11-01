<template>
  <Modal ref="modal" size="xl">
    <template #title>เติมเงิน</template>

    <template #body>
      <div class="row">
  <div class="col-sm-6">
    <div class="card">
      <div class="card-body">
        <!-- <form @submit.prevent="onSubmitDeveloper" id="formDeveloper" autocomplete="off">
        <fieldset :disabled="loading"> -->
          <H5><span class="text-danger">กรุณาโอนเงินเข้าบัญชี</span></H5>
          
         <h5>ชื่อธนาคาร : ธนาคารกรุงเทพ</h5> 
          <h5>สาขาธนาคาร : สาขา เดอะมอลล์บางกะปิ</h5>
          <h5>ชื่อบัญชี : บริษัท คาร์บอนเครดิต จำกัด</h5>
          <h5>เลขที่บัญชี : 012-5545-00-1</h5>
      </div>
    </div>
  </div>
  <div class="col-sm-6">
    <div class="card">
      <div class="card-body">
        <span class="text-danger">ชื่อบัญชี</span>
          <Field type="text" class="form-control" id="firstName" name="firstName" />
          <form action="/action_page.php">
          </form>
          <span class="text-danger">จำนวนเงิน</span>
          <Field type="text" class="form-control" id="amountTopUp" name="amountTopUp" />
          <form action="/action_page.php"> </form>
            <span class="text-danger">กรุณาแนบในเสร็จ</span>
            <p> <input type="file" id="myFile" name="filename">
            </p>
      </div>
    </div>
  </div>
</div>
      
      <!-- <form @submit.prevent="onSubmitDeveloper" id="formDeveloper" autocomplete="off">
        <fieldset :disabled="loading">
          <span class="text-danger">กรุณาโอนเงินเข้าบัญชี</span>
          <h5>ชื่อธนาคาร : ธนาคารกรุงเทพ</h5>
          <h5>สาขาธนาคาร : สาขา เดอะมอลล์บางกะปิ</h5>
          <h5>ชื่อบัญชี : บริษัท คาร์บอนเครดิต จำกัด</h5>
          <h5>เลขที่บัญชี : 012-5545-00-1</h5> -->
          
          <!-- <span class="text-danger">เลขที่บัญชี</span>
          <Field type="text" class="form-control" id="accountNumber" name="accountNumber" />
          <form action="/action_page.php">
            <ErrorMessage class="acountNumber" name="acountNumber" />
          </form>

          <span class="text-danger">ชื่อบัญชี</span>
          <Field type="text" class="form-control" id="firstName" name="firstName" />
          <form action="/action_page.php">
          </form>
          <span class="text-danger">จำนวนเงิน</span>
          <Field type="text" class="form-control" id="amountTopUp" name="amountTopUp" />
          <form action="/action_page.php">
            <span class="text-danger">กรุณาแนบในเสร็จ</span>
            <p> <input type="file" id="myFile" name="filename">
            </p>
          </form>
        </fieldset>
      </form> -->

    </template>

    <template #footer>
      <button type="button" class="btn btn-secondary" @click="modal.hide" :disabled="loading">
        ยกเลิก
      </button>
      <button type="onSubmitDeveloper" class="btn btn-primary" onclick="myFunction2()" @click="myFunction2" :disabled="loading">
        <div v-show="loading" class="spinner-border spinner-border-sm">
        </div>
        ยืนยัน
      </button>
    </template>
  </Modal>
</template>

<script setup>
import { ref } from 'vue'
import Modal from '../Modal.vue'
import { Field } from 'vee-validate'

const modal = ref(null)
const loading = ref(false)

function openModal() {
  loading.value = false
  modal.value.show()
}

defineExpose({
  openModal
})

// function myFunction(userId) {
//     Swal.fire({
//       title: 'Deleting User',
//       text: 'Are you sure you want to delete this User?',
//       icon: 'warning',
//       showCancelButton: true,
//       confirmButtonColor: '#3085d6',
//       cancelButtonColor: '#d33',
//       confirmButtonText: 'Confirm'
//     }).then(async (result) => {
//       if (result.isConfirmed) {
//         await http.delete('/users/delete/' + userId)
//         refreshData()
//       }
//     })
//   }

  function myFunction2() {
  alert("ยืนยันการทำรายการ");
 
}

</script>
