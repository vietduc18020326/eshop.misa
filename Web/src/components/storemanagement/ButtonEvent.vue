<template>
  <div class="content-header">
    <div
      class="btn-group"
      v-for="(btn, index) in Btns"
      :key="index"
      @click="openDialog(index)"
    >
      <i :id="btn.id" class="btn-icon"></i>
      {{ btn.name }}
    </div>
    <div
      class="btn-group-v2 item-center"
      v-for="(btn, index) in btns"
      :key="index + 2"
      @click="openDialog(index + 2)"
    >
      <i :id="btn.id" class="btn-icon"></i>
      {{ btn.name }}
    </div>
  </div>
</template>
<script>
export default {
  name: "ButtonEvent",
  data() {
    return {
      Btns: [
        { name: "Thêm mới", id: "icon-add", key: 0 },
        { name: "Nhân bản", id: "icon-humane", key: 1 },
      ],
      btns: [
        { name: "Sửa", id: "icon-update", key: 2 },
        { name: "Xóa", id: "icon-delete", key: 3 },
        { name: "Nạp", id: "icon-loaded", key: 4 },
      ],
      isDialogAdd: false,
      isDialogDelete: false,
      isDialogUpdate: false,
    };
  },
  methods: {
    openDialog: function(index) {
      // nút thêm mới
      if (index == 0) {
        this.isDialogAdd = true;
        this.isDialogDelete = false;
        this.isDialogUpdate = false;
        this.$emit(
          "OpenDialog",
          this.isDialogAdd,
          this.isDialogDelete,
          this.isDialogUpdate
        );
      }
      // nút cập nhật
      if (index == 2) {
        this.isDialogAdd = false;
        this.isDialogDelete = false;
        this.isDialogUpdate = true;
        this.$emit(
          "OpenDialog",
          this.isDialogAdd,
          this.isDialogDelete,
          this.isDialogUpdate
        );
      }
      // nút xóa
      if (index == 3) {
        this.isDialogAdd = false;
        this.isDialogDelete = true;
        this.isDialogUpdate = false;
        this.$emit(
          "OpenDialog",
          this.isDialogAdd,
          this.isDialogDelete,
          this.isDialogUpdate
        );
      }
    },
  },
};
</script>
