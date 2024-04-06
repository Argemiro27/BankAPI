import { Box } from "@mui/material";
import { styled } from "styled-components";

const BoxAuth = styled(Box)`
  @media (max-width: 900px) {
    height: 100vh;
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  @media screen and (min-width: 900px) {
    height: 100vh;
    width: 50%;
    display: flex;
    justify-content: center;
    align-items: center;
  }
`;

export default BoxAuth;
