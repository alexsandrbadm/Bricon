import React from 'react';
import moment from 'moment'
import {observer} from 'mobx-react';
import {getLastFileData} from './api/api';
import {observable, runInAction} from 'mobx';

const state = observable({
	isLoading: true,
	data: {}
});

const App = observer(() => {
	// const fileData = getLastFileData("2020-08-12 1151.rdo")
	React.useEffect(() => {
		getLastFileData().then(result =>
			runInAction(() => {
				state.isLoading = false;
				state.data = result.data;
			}));
	}, []);
	
	if (state.isLoading)
		return null;
	
	return <div style={{height: '100vh'}} className="d-flex w-100 p-3 mx-auto flex-column">
		<header className="mb-5">
			<div>
				<h3 className="float-md-start mb-0">Pigeons</h3>
				<nav className="nav nav-masthead justify-content-center float-md-end">
					<a className="nav-link active" aria-current="page" href="#">Главная</a>
					<a className="nav-link" href="#">Контакты</a>
				</nav>
			</div>
		</header>
		
		<main className="px-3">
			<h1>Имя файла</h1>
			<p className="lead">{state.data.fileName}</p>
			<table className="table table-dark table-sm">
				<tbody>
				<tr className="table-active">
					<th scope="row">Name: </th>
					<td>{state.data.data.readOutDataSet.fancier.name}</td>
					<th scope="row">Loft number: </th>
					<td>{state.data.data.readOutDataSet.fancier.license}</td>
				</tr>
				<tr>
					<th scope="row">Address: </th>
					<td>{state.data.data.readOutDataSet.fancier.address}</td>
					<th scope="row">Coordinates: </th>
					<td>{state.data.data.readOutDataSet.fancier.coordX}</td>
				</tr>
				<tr>
					<th scope="row">City: </th>
					<td>{state.data.data.readOutDataSet.fancier.city}</td>
					<th></th>
					<td>{state.data.data.readOutDataSet.fancier.coordY}</td>
				</tr>
				<tr>
					<th scope="row">Clock: </th>
					<td>{state.data.data.readOutDataSet.fancier.serial}</td>
				</tr>
				</tbody>
			</table>
			<table className="table table-dark table-sm">
				<thead>
				<tr>
					<th scope="col">Nr</th>
					<th scope="col">El-Ring</th>
					<th scope="col">Ring Number</th>
					<th scope="col">Club</th>
					<th scope="col">Race</th>
					<th scope="col">AA</th>
					<th scope="col">YR</th>
					<th scope="col">YB</th>
					<th scope="col">H</th>
					<th scope="col">Clocking Date/Time</th>
					<th scope="col">Eval</th>
				</tr>
				</thead>
				<tbody>
				{state.data.data.readOutDataSet.pigeons.map((pigeon, i) => <tr>
					<th scope="row">{i + 1}</th>
					<td>{pigeon.elBand}</td>
					<td className="text-nowrap">{pigeon.fedBand}</td>
					<td>{pigeon.clubID}</td>
					<td>{pigeon.flightID}</td>
					<td>{pigeon.position1}</td>
					<td>{pigeon.position2}</td>
					<td>{pigeon.position3}</td>
					<td>{pigeon.position4}</td>
					<td>{moment(pigeon.time).format("DD/MM/YYYY HH:mm:ss")}</td>
					<td>{pigeon.evaluation}</td>
				</tr>)}
				</tbody>
			</table>
		</main>
		
		<footer className="mt-auto text-white-50">
			<p>Made in <a href="https://ru.wikipedia.org/wiki/%D0%9A%D0%B8%D1%82%D0%B0%D0%B9"
						  className="text-white">China</a></p>
		</footer>
	</div>;
});

export default App;