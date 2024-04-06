
import { styled } from "styled-components";
import colors from "../../../../style/theme/colors";
import { Card } from "react-bootstrap";


export const StyledCard = styled(Card)`
    background-color: ${colors.cardbg} !important;
    border-radius: 20px;
    box-shadow: 1px 1px 5px 1px #ececec;

    border: 1px solid ${colors.borderCard};
    padding: 20px;
    height: 100%;
    .card-icon{
        font-size: 100px !important;
        height: 100%;
        color: ${colors.textBtn} !important;
    }
`

export const StyledCardTransp = styled(Card)`
    background-color: ${colors.cardbg} !important;
    border-radius: 20px;
    
    border: 1px solid ${colors.borderCard};
    padding: 20px;
    height: 100%;
    .card-icon{
        font-size: 100px !important;
        height: 100%;
        color: ${colors.textBtn} !important;
    }
`