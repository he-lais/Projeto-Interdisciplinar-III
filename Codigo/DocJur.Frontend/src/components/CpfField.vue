<template>
  <b-form-group v-bind:label="fieldLabel">
    <the-mask v-bind:name="fieldName" :mask="['###.###.###-##']" />
  </b-form-group>
</template>

<script>
  export default {
    name: "CpfField",
    props: ['fieldLabel', 'fieldName'],
    data() {
      return {
        cpf: ''
      }
    }
  }
</script>
