export const SERVICE_URL = process.env.NODE_ENV === 'development'
	? 'http://localhost:9001/'
	: 'http://pegions.somee.com/';

export async function getLastFileData() {
	const req = await fetch(SERVICE_URL + `api/last-file-data/`);
	return await req.json();
}