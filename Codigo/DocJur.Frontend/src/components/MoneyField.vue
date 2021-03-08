<template>
  <b-form-group v-bind:label="fieldLabel">
    <money v-bind:name="fieldName" v-model="price" prefix='R$ '></money>
  </b-form-group>
</template>

<script>
  export default {
    name: "MoneyField",
    props: ['fieldLabel', 'fieldName'],
    data() {
      return {
        price: ''
      }
    }
  }
</script>
