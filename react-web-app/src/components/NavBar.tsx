import { useNavigate } from 'react-router-dom'

import { Image, Navbar, Container, Nav, NavDropdown } from 'react-bootstrap'
import eBayLogo from '../assets/ebay-image.png'

const NavBar = () => {
    const navigate = useNavigate();

    const handleImageClicked = () => navigate('/');

    return (
        <Navbar bg="dark" variant='dark' expand="lg">
            <Container>
                <Image className='Width-125-Px Cursor-Pointer' src={eBayLogo} onClick={() => handleImageClicked()} />
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link href="#home">Home</Nav.Link>
                        <Nav.Link href="#link">Link</Nav.Link>
                        <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                            <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                            <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                            <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}

export default NavBar