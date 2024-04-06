

export const loginSuccess = (): { type: 'LOGIN_SUCCESS'; payload: any } => ({
  type: 'LOGIN_SUCCESS',
  payload: { }
});

export const logout = (): { type: 'LOGOUT' } => ({
  type: 'LOGOUT'
});
