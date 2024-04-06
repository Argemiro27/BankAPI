import { Button } from "@mui/material";
import styled from "styled-components";
import colors from "../../../../style/theme/colors";

export const BtnAuth = styled(Button)`
    width: 100%;
    background-color: ${colors.primary} !important;
    font-size: 12px !important;
    font-weight: bold !important;
    color: ${colors.textBtn} !important;
`

export const BtnAuthSec = styled(Button)`
    width: 100%;
    background-color: ${colors.secondary} !important;
    font-size: 12px !important;
    font-weight: bold !important;
    color: ${colors.textBtn} !important;
`