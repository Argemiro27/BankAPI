import { Card, Col, Container, Row } from "react-bootstrap";
import { StyledCard, StyledCardTransp } from "../../../global/components/Card";
import Cards from 'react-credit-cards-2';
import { useState, useEffect } from "react";

function Home() {
  const [cardInfo, setCardInfo] = useState({
    number: '',
    expiry: '',
    cvc: '',
    name: '',
    focus: '',
  });

  const [accountInfo, setAccountInfo] = useState({
    accountNumber: "",
    balance: "",
    accountType: "",
    ownerName: ""
  });

  useEffect(() => {
    // Função para recuperar dados do localStorage
    const getUserDataFromLocalStorage = () => {
      const userDataString = localStorage.getItem('dadosUsuario');
      if (userDataString) {
        return JSON.parse(userDataString);
      }
      return null;
    };
  
    // Recuperar dados do usuário do localStorage
    const userData = getUserDataFromLocalStorage();
  
    if (userData && userData.dataAccount) {
      try {
        const dataAccount = JSON.parse(userData.dataAccount);
        const { CardNumber, AccountBalance, AccountType, ClientName, AccountNumber } = dataAccount;
        setAccountInfo({
          accountNumber: AccountNumber,
          balance: `$${AccountBalance.toFixed(2)}`,
          accountType: AccountType,
          ownerName: ClientName
        });
        setCardInfo(prevState => ({
          ...prevState,
          number: CardNumber,
          name: ClientName
        }));
      } catch (error) {
        console.error('Erro ao analisar dataAccount:', error);
      }
    }
  }, []);
  
  return (
    <Container>
      <Row>
        <Col className="d-flex justify-content-center">
          <StyledCard className="m-3 w-75">
            <Row className="h-100">
              <Col className="d-flex justify-content-center align-items-center">
                <Cards
                  number={cardInfo.number}
                  expiry={cardInfo.expiry}
                  cvc={cardInfo.cvc}
                  name={cardInfo.name}
                />
              </Col>
              <Col>
                <StyledCardTransp className=" p-3">
                  <p><b>Número da Conta:</b> {accountInfo.accountNumber}</p>
                  <p><b>Saldo:</b> {accountInfo.balance}</p>
                  <p>
                    <b>Tipo de Conta:</b> 
                    {accountInfo.accountType === "C" ? " Corrente" : ""}
                  </p>

                  <p><b>Nome do Proprietário:</b> {accountInfo.ownerName}</p>
                </StyledCardTransp>
              </Col>
            </Row>
            <Row>
            </Row>
          </StyledCard>
        </Col>
      </Row>
    </Container>
  );
}

export default Home;
