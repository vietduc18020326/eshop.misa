<template>
  <div class="panel-left">
    <div class="logo">
      <div class="icon-logo"></div>
    </div>
    <div class="menu">
      <div v-for="(menu, index) in Menu" :key="index" class="menu-item">
        <div class="menu-icon" :id="menu.id"></div>
        <div class="menu-text">{{ menu.name }}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Navbar",
  data() {
    return {
      Menu: [
        { name: "Tổng quan", id: "overview" },
        { name: "Báo cáo", id: "report" },
        { name: "Đơn hàng", id: "order" },
        { name: "Mua hàng", id: "purchases" },
        { name: "Khuyến mãi", id: "promotion" },
        { name: "Quản lý cửa hàng", id: "storemanagement" },
        { name: "Hàng hóa", id: "goods" },
      ],
    };
  },
};
</script>

<style scoped></style>
