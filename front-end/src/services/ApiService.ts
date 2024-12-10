import axios from 'axios';

const API_URL = 'http://localhost:5160/api/AdviceSlip';

export const ApiService = {
	async getAdviceData() {
		try {
			const response = await axios.get(API_URL);
			return response.data;
		} catch (error) {
			console.error('Error fetching advice data:', error);
			throw error;
		}
	},
};
