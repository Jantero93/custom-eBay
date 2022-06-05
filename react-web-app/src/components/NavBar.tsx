import { useNavigate } from 'react-router-dom'

import { Image, Navbar, Container, Nav, NavDropdown } from 'react-bootstrap'
import eBayLogo from '../assets/ebay-image.png'

const NavBar = () => {
    const navigate = useNavigate();

    const handleImageClicked = () => navigate('/');

    return (
        <Navbar bg="dark" variant='dark' expand="lg">
            <Container>
                <Navbar.Collapse className="d-flex justify-content-between" id="basic-navbar-nav">
                    <Nav className="mr-auto">
                        <Image className='Width-125-Px Cursor-Pointer' src={eBayLogo} onClick={() => handleImageClicked()} />
                        <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    </Nav>
                    <Nav className="ml-auto">
                        <NavDropdown title="my eBay" id="basic-nav-dropdown">
                            <NavDropdown.Item href="#action/3.1">Login</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}

export default NavBar