<template>
  <b-form-group v-bind:label="fieldLabel">
    <b-form-input
      v-bind:name="fieldName"
      v-model="text"
    ></b-form-input>
  </b-form-group>
</template>

<script>

export default {
    name: "TextField",
    props: ['fieldLabel', 'fieldName'],
    data() {
      return {
        text: ''
      }
    }
};
</script>