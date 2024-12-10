<template>
	<div id="app">
		<DataTable />
	</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import DataTable from './components/DataTable.vue';

export default defineComponent({
	name: 'App',
	components: {
		DataTable,
	},
});
</script>

<style scoped>
#app {
	font-family: Arial, sans-serif;
	padding: 20px;
}
</style>
