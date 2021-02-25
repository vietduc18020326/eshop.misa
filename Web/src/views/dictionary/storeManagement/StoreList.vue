<template>
  <div class="content">
    <div class="content-center">
      <ButtonEvent @OpenDialog="openDialog" @reLoadData="reLoadStore" />
      <div class="content-body">
        <div class="s-table" id="style-scroll">
          <table>
            <thead>
              <tr class="row">
                <th id="storecode">
                  Mã cửa hàng <br />
                  <div class="search-group">
                    <div class="input-group">
                      <button>*</button>
                      <input type="text" class="search" />
                    </div>
                  </div>
                </th>
                <th id="storename">
                  Tên cửa hàng<br />
                  <div class="search-group">
                    <div class="input-group">
                      <button class="item-center">*</button>
                      <input type="text" class="search" />
                    </div>
                  </div>
                </th>
                <th id="storeaddress">
                  Địa chỉ <br />
                  <div class="search-group">
                    <div class="input-group">
                      <button>*</button>
                      <input type="text" class="search" />
                    </div>
                  </div>
                </th>
                <th id="storephone">
                  Số điện thoại<br />
                  <div class="search-group">
                    <div class="input-group">
                      <button>*</button>
                      <input type="text" class="search" />
                    </div>
                  </div>
                </th>
                <th id="storestatus">
                  Trạng thái<br />
                  <select class="search-group">
                    <option value="0">Đang hoạt động</option>
                    <option value="1">Đang đóng cửa</option>
                  </select>
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="(store, index) in Stores"
                :key="index"
                @click="handleClick(index)"
                @dblclick="handleUpdate(index)"
                class="data-row"
                :id="index"
              >
                <td>{{ store.StoreCode }}</td>
                <td>{{ store.StoreName }}</td>
                <td>{{ store.Address }}</td>
                <td>{{ store.PhoneNumber }}</td>
                <td>{{ statusStore(store.Status) }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <Pagination
        @loadData="loadStore"
        :quantityStore="quantityStore"
        :Stores="Stores"
      />
      <div :class="{ back_dialog: isDialog }"></div>
      <StoreProfileDetail
        v-if="isDialogAdd | isDialogUpdate"
        @CloseDialog="closeDialog"
        @handleAlert="HandleAlert"
        :isDialog="isDialogAdd"
        :isUpdate="isDialogUpdate"
        :store="Store"
      />
      <DialogWarn
        v-if="isDialogDelete"
        @CloseDialog="closeDialog"
        @hanldeAlert="HandleAlert"
        :store="Store"
      />
      <div id="snackbar"></div>
    </div>
  </div>
</template>
<script>
import ButtonEvent from "../../../components/storemanagement/ButtonEvent";
import Pagination from "../../../components/storemanagement/Pagination";
import StoreProfileDetail from "./StoreProfileDetail";
import DialogWarn from "../../../components/storemanagement/DialogWarn";
import storeServices from "../../../services/storeServices";

export default {
  name: "StoreList",
  components: {
    ButtonEvent,
    Pagination,
    StoreProfileDetail,
    DialogWarn,
  },
  data() {
    return {
      Stores: [],
      Store: {},
      Alert: {},
      isDialog: false,
      isDialogAdd: false,
      isDialogDelete: false,
      isDialogUpdate: false,
      isClickRow: false,
      quantityPage: 0,
      quantityStore: 0,
      pagi: 10,
      offset: 0,
    };
  },
  async mounted() {
    this.quantityStore = await storeServices.quantityStore();
    this.quantityPage = Math.ceil(this.quantityStore / this.pagi);
    this.reLoad();
  },
  updated() {
    var trList = document.querySelectorAll(".data-row");
      for (let tr of trList) {
        if (tr.classList.contains("row_active")) {
          tr.classList.remove("row_active");
          this.Store = {};
          this.isClickRow = false
          break;
        }
      }
  },
  methods: {
    //Mở dialog
    openDialog: function(dialogAdd, dialogDelete, dialogUpdate) {
      this.isDialog = true;
      this.isDialogAdd = dialogAdd;
      this.isDialogDelete = dialogDelete;
      this.isDialogUpdate = dialogUpdate;
      if (!this.isClickRow && dialogUpdate) {
        this.isDialog = false;
        this.isDialogUpdate = false;
      }
      if (!this.isClickRow && dialogDelete) {
        this.isDialog = false;
        this.isDialogDelete = false;
      }
      if (this.isDialogAdd) {
        this.Store = {};
      }
    },
    //đóng dialog
    closeDialog: async function() {
      this.isDialog = false;
      this.isDialogAdd = false;
      this.isDialogDelete = false;
      this.isDialogUpdate = false;
      this.isClickRow = false;
      this.Store = {
        Status: 1,
      };
      this.Stores = await storeServices.GetStoreOfPage(
        this.offset,
        this.quantityPage
      );
      this.$emit("ClickStore", this.Store.StoreName);
      var trList = document.querySelectorAll(".data-row");
      for (let tr of trList) {
        if (tr.classList.contains("row_active")) {
          tr.classList.remove("row_active");
          break;
        }
      }
    },
    //xử lí câu thông báo khi thêm mới, cập nhật và xóa dữ liệu thành công hay có lỗi
    HandleAlert: function(alert) {
      var x = document.getElementById("snackbar");
      x.innerHTML = alert.Text;
      x.className = "show";
      console.log(alert.Text);
      setTimeout(() => {
        x.className = x.className.replace("show", "");
      }, 3000);
    },
    //lấy dữ liệu theo trang
    loadStore: function(number) {
      this.offset = (number - 1) * this.quantityPage;
      this.reLoad();
    },
    //Xử lí khi click vào dữ liệu trong bảng
    handleClick: function(index) {
      this.Store = this.Stores[index];
      this.isClickRow = true;
      var trList = document.querySelectorAll(".data-row");
      for (let tr of trList) {
        if (tr.classList.contains("row_active")) {
          tr.classList.remove("row_active");
          break;
        }
      }
      var clickedTr = document.getElementById(index);
      clickedTr.classList.add("row_active");
      this.$emit("ClickStore", this.Store.StoreName);
    },
    //cập nhật khi double click vào bảng
    handleUpdate: function(index) {
      this.isDialog = true;
      this.isDialogDelete = false;
      this.isDialogUpdate = true;
      this.isDialogAdd = false;
      this.Store = this.Stores[index];
    },
    //Xử lí khi ấn nút nạp
    reLoadStore: function(isReload) {
      this.Stores = {};
      if (isReload) {
        setTimeout(this.reLoad, 500);
      }
    },
    reLoad: async function() {
      this.Stores = await storeServices.GetStoreOfPage(
        this.offset,
        this.quantityPage
      );
    },
    statusStore: function(status) {
      if (status == 0) {
        return "Đang đóng cửa";
      }
      if (status == 1) {
        return "Đang hoạt động";
      }
      return "";
    },
  },
  watch: {
    isArrayClickRow: {
      handler() {},
    },
  },
};
</script>
<style scoped></style>
