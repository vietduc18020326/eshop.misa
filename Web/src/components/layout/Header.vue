<template>
  <div class="header">
    <div class="header-left">
      <h2 style="color: #00577b">Cửa hàng</h2>
    </div>
    <div class="header-right">
      <select>
        <option>{{ Name }}</option>
      </select>
      <div class="account item-center">
        <div class="user-icon"></div>
        <div class="username">PNVĐ</div>
        <i class="down"></i>
      </div>
      <div class="x-btn-callcenter">
        <i class="icon-telephone"> </i>
      </div>
      <div class="item-center x-btn-notify">
        <i class="icon-notify"></i>
      </div>
      <div class="item-center x-btn-help">
        <div class="btn-help"></div>
      </div>
    </div>
    <div class="clear"></div>
  </div>
</template>

<script>
export default {
  name: "Header",
  props: ["Name"],
};
</script>
