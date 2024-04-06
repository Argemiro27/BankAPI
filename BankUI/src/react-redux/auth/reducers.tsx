import { loginSuccess, logout } from "./actions";

// authReducer.ts
interface AuthState {
  isAuthenticated: boolean;
  token: string | null;
  user: any | null; // Você pode definir a interface para o usuário conforme necessário
}

const initialState: AuthState = {
  isAuthenticated: localStorage.getItem('dadosUsuario') ? true : false,
  token: localStorage.getItem('dadosUsuario') ? JSON.parse(localStorage.getItem('dadosUsuario')!).token : null,
  user: localStorage.getItem('dadosUsuario') ? JSON.parse(localStorage.getItem('dadosUsuario')!).user : null
};

type AuthAction = 
  | ReturnType<typeof loginSuccess>
  | ReturnType<typeof logout>;

const authReducer = (state: AuthState = initialState, action: AuthAction): AuthState => {
  switch (action.type) {
    case 'LOGIN_SUCCESS':
      return {
        ...state,
        isAuthenticated: true,
        token: action.payload.token,
        user: action.payload.user
      };
    case 'LOGOUT':
      localStorage.removeItem('dadosUsuario');
      return {
        ...state,
        isAuthenticated: false,
        token: null,
        user: null
      };
    default:
      return state;
  }
};

export default authReducer;
