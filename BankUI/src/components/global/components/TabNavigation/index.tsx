import { useState } from 'react';
import { Tab, Tabs } from "@mui/material";
import { Link } from 'react-router-dom';
import styled from 'styled-components';
import DashboardIcon from '@mui/icons-material/Dashboard';
import PeopleAltIcon from '@mui/icons-material/PeopleAlt';
import PersonIcon from '@mui/icons-material/Person';
import ScheduleIcon from '@mui/icons-material/Schedule';
import EventIcon from '@mui/icons-material/Event';
import colors from '../../../../style/theme/colors';

// Removendo a Toolbar e ajustando o estilo diretamente no componente Tabs
const StyledTabs = styled(Tabs)`
    @media (max-width: 900px) {
        position: fixed;
        bottom: 0;
        left: 0;
        width: 100%;
        background-color: ${colors.navbg};
        z-index: 999; /* ajuste a z-index conforme necessário */
    }
    @media(min-width: 900px){
        display: none !important;
    }
`;

function TabsComp() {
    const [value, setValue] = useState(0);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    const menuItems = [
        { label: 'Início', icon: <DashboardIcon />, path: '/home' },
        { label: 'Usuários', icon: <PeopleAltIcon />, path: '/cadastros/cad-usuarios' },
        { label: 'Pacientes', icon: <PersonIcon />, path: '/cadastros/cad-pacientes' },
        { label: 'Funcionários', icon: <PeopleAltIcon />, path: '/cadastros/cad-funcionarios' },
        { label: 'Grade de Horários', icon: <ScheduleIcon />, path: '/agendamentos/gradehoraria' },
        { label: 'Agendar Consulta', icon: <EventIcon />, path: '/agendamentos/agendar-consulta' },
    ];

    return (
        <StyledTabs
            value={value}
            onChange={handleChange}
            textColor="primary"
            indicatorColor="primary"
            variant="scrollable"
            scrollButtons="auto"
        >
            {menuItems.map((item, index) => (
                <Tab key={index} label={item.label} icon={item.icon} component={Link} to={item.path} />
            ))}
        </StyledTabs>
    );
}

export default TabsComp;
