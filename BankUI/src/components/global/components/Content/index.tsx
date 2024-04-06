import styled from "styled-components";


const Content = styled.div`
    background-color: ${colors.bgcolor};
    max-height: 100vh;
    width: 100%;
    overflow: auto;
    .tab-navigator-fixed{
        position: fixed;
        bottom: 0;
    }
`

export default Content;