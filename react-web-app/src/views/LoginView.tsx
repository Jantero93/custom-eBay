import React, { useState } from 'react';

import { Form, Button, Image } from 'react-bootstrap'
import eBayLogo from '../assets/ebay-image.png'

const LoginView = () => {
	const [email, setEmail] = useState('');
	const [password, setPassword] = useState('');

	const formSubmitted = (e: React.FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		console.log('email', email);
		console.log('password', password);
	}

	return (
		<div className="d-flex flex-column align-items-center mt-5">
			<Image className="w-25" src={eBayLogo} />
			<h1>Sign in to custom eBay</h1>
			<Form className="d-flex flex-column align-items-start Width-400-Px mx-auto mt-3 border p-4" onSubmit={(e) => formSubmitted(e)}>
				<Form.Group className="mb-3 D-Flex-Column-Left-Align w-100">
					<Form.Label>Email address</Form.Label>
					<Form.Control type="email" onChange={(e: React.ChangeEvent<HTMLInputElement>) => setEmail(e.currentTarget.value)} />
				</Form.Group>

				<Form.Group className="mb-3 D-Flex-Column-Left-Align w-100">
					<Form.Label>Password</Form.Label>
					<Form.Control type="password" onChange={(e: React.ChangeEvent<HTMLInputElement>) => setPassword(e.currentTarget.value)} />
				</Form.Group>
				<Button className="mt-3" variant="success" type="submit">
					Login
				</Button>
			</Form>
		</div>
	)
}

export default LoginView