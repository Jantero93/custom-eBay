import { Link, useNavigate } from 'react-router-dom';

import { Image, Navbar, Container, Nav, NavDropdown } from 'react-bootstrap';
import eBayLogo from '../assets/ebay-image.png';

const NavBar = () => {
  const navigate = useNavigate();

  const handleImageClicked = () => navigate('/');

  return (
    <Navbar bg="dark" variant="dark" expand="lg">
      <Container className="d-flex justify-content-between">
        <Nav className="mr-auto">
          <Image
            className="width-125 cursor-pointer"
            src={eBayLogo}
            onClick={() => handleImageClicked()}
          />
        </Nav>
        <Nav className="ml-auto">
          <NavDropdown title="my eBay" id="basic-nav-dropdown">
            <NavDropdown.Item as={Link} to="/login">
              Login
            </NavDropdown.Item>
          </NavDropdown>
        </Nav>
      </Container>
    </Navbar>
  );
};

export default NavBar;
