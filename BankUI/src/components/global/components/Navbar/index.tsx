import { Toolbar, Typography, Avatar } from "@mui/material";
import styled from 'styled-components';
import { Dropdown } from 'react-bootstrap';
import colors from "../../../../style/theme/colors";

const StyledNavbar = styled(Toolbar)`
    background-color: ${colors.navbg} !important;
    width: 100%;
    padding-left: 110px;
    .btn-sidebar-usuario {
        background-color: ${colors.dropbg} !important;
        border: none;
    }
`;

function Navbar() {
    // Obter os dados do usuário do localStorage
    const userDataString = localStorage.getItem("dadosUsuario");
    // Verificar se userDataString não é null antes de fazer a conversão
    const userData = userDataString ? JSON.parse(userDataString) : null;
    // Extrair o nome do usuário do objeto userData
    const nomeUsuario = userData ? userData.username : ""; // Definir como string vazia se não houver dados de usuário
    const handleLogout = () => {
        localStorage.clear();
        window.location.href = '/login';
    }
    return (
        <StyledNavbar>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                <img src="/src/assets/logo-clinicalsys.png" height='50' alt="Logo" />
            </Typography>

            <Dropdown>
                <Dropdown.Toggle className="btn-sidebar-usuario d-flex align-items-center btn-avatar" id="dropdown-basic">
                    <div className="avatar-wrapper">
                        <Avatar
                            alt="Remy Sharp"
                            src="https://mui.com/static/images/avatar/1.jpg"
                            sx={{ width: 24, height: 24, marginRight: 1 }}
                        />
                    </div>
                    <span><b>{nomeUsuario}</b></span>
                    <div className="nome-usuario ml-2"></div>
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    <Dropdown.Item onClick={handleLogout}>Logout</Dropdown.Item>
                </Dropdown.Menu>
            </Dropdown>
        </StyledNavbar>
    );
}

export default Navbar;
