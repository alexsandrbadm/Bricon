const path = require('path');
const HtmlWebPackPlugin = require('html-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

module.exports = {
	output: {
		path: path.resolve(__dirname, 'dist'),
		filename: 'bundle.[hash:4].js',
	},
	entry: ["@babel/polyfill", "./src/index.js"],
	devtool: 'inline-source-map',
	resolve: {
		modules: [
			'node_modules',
			path.resolve(__dirname, 'src'),
		],
		extensions: [".js", ".jsx"]
	},
	module: {
		rules: [
			{
				test: /\.(js|jsx)$/,
				exclude: /node_modules/,
				use: {
					loader: 'babel-loader',
				},
			},
			{
				test: /\.css$/,
				use: [
					{
						loader: 'style-loader',
					},
					{
						loader: 'css-loader',
					},
				],
			},
		],
	},
	plugins: [
		new HtmlWebPackPlugin({
			template: './src/index.html',
			minify: false
		}),
		new CleanWebpackPlugin()
	],
};