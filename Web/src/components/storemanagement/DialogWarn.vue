<template>
  <div class="warn" title="Cảnh báo">
    <div class="warn-header">
      <div class="warn-left">
        <p id="title">Xóa nhân viên</p>
      </div>
      <div class="warn-right" @click="closeDialog">
        <i class="icon-x"></i>
      </div>
      <div class="clear"></div>
    </div>
    <div class="warn-body">
      <i class="icon-warn"></i>
      <div id="title-warn">
        Bạn có chắc chắn muốn xóa <strong>{{ Store.StoreName }}</strong> khỏi
        danh sách cửa hàng ?
      </div>
    </div>
    <div class="btn-footer">
      <div class="btn-warn">
        <button class="btn-delete" @click="deleteStore">
          <i class="icon-delete"></i>
          <p>Xóa</p>
        </button>
        <div class="btn-cancel item-center" @click="closeDialog">
          <i class="icon-x"></i>
          <p>Hủy bỏ</p>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import storeServices from "../../services/storeServices";

export default {
  name: "DialogWarn",
  props: ["store"],
  data() {
    return {
      Store: {},
      Alert: {
        Text: "",
        Success: false,
      },
    };
  },
  mounted() {
    this.Store = this.store;
  },
  methods: {
    closeDialog: function() {
      this.$emit("CloseDialog", this.Alert);
    },
    deleteStore: async function() {
      await storeServices.deleteStore(this.Store.StoreId);
      this.Alert.Success = true;
      this.Alert.Text = "Xóa thành công";
      this.$emit("hanldeAlert", this.Alert);
      this.closeDialog();
    },
  },
};
</script>
