import { createGlobalStyle } from 'styled-components';
import '../../node_modules/bootstrap/dist/css/bootstrap.css'
import '../../node_modules/bootstrap/dist/js/bootstrap.js'
import 'react-toastify/dist/ReactToastify.css';
import 'react-credit-cards-2/dist/es/styles-compiled.css';


import colors from './theme/colors';


const GlobalStyle = createGlobalStyle`
  *{
    font-family: "Prompt", sans-serif;


  }
  body {
    margin: 0;
    padding: 0;
    background: ${colors.bgcolor};

  }
  h1, h2, h3, h4, h5, h6, p{
    color: ${colors.textColor} !important; 
  }
  b{
    color: ${colors.textBold};
  }
  a{
    color: ${colors.bgcolor} !important;
  }

  // Arrow do dropdown
  .dropdown-toggle::after {
    color: ${colors.textBold};
  }
`;

export default GlobalStyle;