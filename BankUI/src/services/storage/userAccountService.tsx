import { IUser } from "../../interfaces/User";

export const getUserDataFromLocalStorage = (): IUser | null => {
    const userDataString = localStorage.getItem('dadosUsuario');
    if (userDataString) {
      return JSON.parse(userDataString);
    }
    return null;
  };


// Função para extrair informações relevantes do cartão
export const extractCardInfo = (userData: IUser | null) => {
    if (userData && userData.dataAccount) {
        try {
            const dataAccount = JSON.parse(userData.dataAccount);
            const { CardNumber, AccountBalance, ClientName } = dataAccount;
            return {
                number: CardNumber,
                name: ClientName,
                balance: `$${parseFloat(AccountBalance).toFixed(2)}`
            };
        } catch (error) {
            console.error('Erro ao analisar dataAccount:', error);
        }
    }
    return null;
};