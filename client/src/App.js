import { Navbar, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";
import "./App.css";
import "bootstrap/dist/css/bootstrap.css";


import { Outlet } from "react-router-dom";

//^ This function returns the jsx that displays what we see in the browser
function App() {
  return (
    <div className="App">
      <>
        <Navbar color="light" expand="md">
          <Nav navbar>
            <NavbarBrand href="/">🐕‍🦺 🐩 DeShawn's Dog Walking</NavbarBrand>
            <NavItem>
              <NavLink href="/walkers">Walkers</NavLink>
              <NavLink href="/dogs">Dogs</NavLink>
              <NavLink href="/cities">Cities</NavLink>
            </NavItem>
          </Nav>
        </Navbar>
        <Outlet />
      </>
    </div>
  );
}

export default App;
