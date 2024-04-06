// AuthService.ts

interface AuthResponse {
  token: string;
}
const VITE_REACT_APP_API_URL = import.meta.env.VITE_REACT_APP_API_URL



class AuthService {
  static async login(email: string, senha: string): Promise<AuthResponse> {
    console.log(email, senha);
  
    let endpoint = `${VITE_REACT_APP_API_URL}/api/Auth/login?email=${email}&senha=${senha}`;
    console.log(endpoint);
    const response = await fetch(endpoint, {
      method: "GET",
    });
    const data = await response.json(); // Assumindo que a resposta da API é em formato JSON
    console.log("Resultado da API:", data);
    if (response.ok) {
  
      const tokenDecodablePart = data.tokenID.split('.')[1];
      const dadosUsuario = JSON.parse(atob(tokenDecodablePart));
      console.log("Dados do usuário retornados: ", dadosUsuario);
  
      // Salvar os dados no localStorage
      localStorage.setItem("dadosUsuario", JSON.stringify(dadosUsuario));
  
      return data;
    } else {
      const errorData = await response.json();
      throw new Error(errorData.error || "Erro desconhecido");
    }
  }
  

  // static async saveUsuario(userData: any): Promise<void> {
  //   try {
  //     await axios.post(`${VITE_REACT_APP_API_URL}/auth/save-usuario`, userData);
  //   } catch (error) {
  //     const errorMessage =
  //       error instanceof Error ? error.message : "Erro desconhecido";
  //     throw new Error("Erro ao salvar usuário: " + errorMessage);
  //   }
  // }

}

export default AuthService;
