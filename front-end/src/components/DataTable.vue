<template>
	<div>
		<h1>Advice Table</h1>

		<!-- Filter input -->
		<input v-model="filter" type="text" placeholder="Filter by advice..." />

		<!-- Filter button -->
		<button @click="applyFilter">Filter</button>

		<!-- Refresh button -->
		<button @click="refreshData">Refresh Table</button>

		<!-- Table display -->
		<table v-if="filteredData.length">
			<thead>
				<tr>
					<th>ID</th>
					<th>Advice</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="item in filteredData" :key="item.slipId">
					<td>{{ item.slipId }}</td>
					<td>{{ item.advice || 'No advice' }}</td>
				</tr>
			</tbody>
		</table>

		<!-- Loading state -->
		<p v-else>Loading data...</p>
	</div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { ApiService } from '../services/ApiService'; // Importing the API service

interface DataItem {
	slipId: number;
	advice: string | null;
}

export default defineComponent({
	name: 'DataTable',

	setup() {
		const data = ref<DataItem[]>([]);
		const filter = ref('');
		const filteredData = ref<DataItem[]>([]);

		const fetchData = async () => {
			try {
				const fetchedData = await ApiService.getAdviceData();
				data.value = fetchedData;
				filteredData.value = fetchedData;
			} catch (error) {
				console.error('Error fetching data:', error);
			}
		};

		onMounted(() => {
			fetchData();
		});

		const refreshData = () => {
			fetchData();
		};

		const applyFilter = () => {
			filteredData.value = data.value.filter((item) => filterAdvice(item));
		};

		const filterAdvice = (item: DataItem): boolean => {
			const lowercasedFilter = filter.value.toLowerCase();
			return (
				item.advice?.toLowerCase().includes(lowercasedFilter) ||
				item.slipId.toString().includes(lowercasedFilter)
			);
		};

		return {
			filter,
			filteredData,
			refreshData,
			applyFilter,
		};
	},
});
</script>

<style scoped>
table {
	width: 100%;
	border-collapse: collapse;
}

th,
td {
	padding: 8px 12px;
	border: 1px solid #ddd;
	text-align: left;
}

th {
	background-color: #f4f4f4;
}

input {
	margin-bottom: 10px;
	padding: 8px;
	font-size: 14px;
}

button {
	margin-left: 10px;
	padding: 8px;
	background-color: #4caf50;
	color: white;
	border: none;
	cursor: pointer;
}

button:hover {
	background-color: #45a049;
}
</style>
