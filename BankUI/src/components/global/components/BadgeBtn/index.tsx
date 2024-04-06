// BadgeButton.js
import styled from "styled-components";
import { Button } from "@mui/material";

export const BadgeButton = styled(Button)`
  && {
    padding: 3px;
    min-width: 0;
    margin: 2px;
    .MuiButton-label {
      display: flex;
      align-items: center;
    }
    .MuiIconButton-root {
      margin: 0;
    }
    .MuiSvgIcon-root {
      font-size: 1.1rem;
    }
  }
`;
