<template>
  <div>
    <b-form-group v-bind:label="fieldLabel">
      <b-form-radio v-model="selected" v-bind:name="fieldName" value="yes">Sim</b-form-radio>
      <b-form-radio v-model="selected" v-bind:name="fieldName" value="no">Não</b-form-radio>
    </b-form-group>
  </div>
</template>

<script>
  export default {
    name: "YesNoField",
    props: ['fieldLabel', 'fieldName'],
    data() {
      return {
        selected: ''
      }
    }
  }
</script>
