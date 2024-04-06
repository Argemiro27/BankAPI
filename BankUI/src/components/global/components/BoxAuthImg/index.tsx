import { Box } from "@mui/material";
import imgLogin from "../../../../assets/bgLogin01.jpg";
import { styled } from "styled-components";

const BoxAuthImg = styled(Box)`
  @media (max-width: 900px) {
    display: hidden;
  }
  @media screen and (min-width: 900px) {
    height: 100vh;
    width: 50%;
    display: flex;
    justify-content: center;
    align-items: center;
    background-image: url(${imgLogin});
    background-repeat: no-repeat;
    background-size: cover;
    background-position: center;
    background-color: #a77bff;
  }
`;

export default BoxAuthImg;
