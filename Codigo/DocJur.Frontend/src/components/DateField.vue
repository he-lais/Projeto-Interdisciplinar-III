<template>
  <b-form-group v-bind:label="fieldLabel">
    <b-form-datepicker v-bind:name="fieldName" id="datepicker" v-model="date_value" class="mb-2" locale="pt-br"></b-form-datepicker>
  </b-form-group>
</template>

<script>
  export default {
    name: "DateField",
    props: ['fieldLabel', 'fieldName'],
    data() {
      return {
        date_value: ''
      }
    }
  }
</script>
