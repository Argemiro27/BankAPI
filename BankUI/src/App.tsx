import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { connect, ConnectedProps } from 'react-redux';
import Login from './components/pages/auth/login';
import Home from './components/pages/authenticated/Home';
import { Suspense } from 'react';
import Layout from './components/global/components/Layout';
import NewAccount from './components/pages/authenticated/NewAccount';

interface RootState {
  auth: {
    isAuthenticated: boolean;
  };
}

const mapStateToProps = (state: RootState) => ({
  isAuthenticated: state.auth.isAuthenticated
});

const connector = connect(mapStateToProps);
type PropsFromRedux = ConnectedProps<typeof connector>;

function App({ isAuthenticated }: PropsFromRedux) {
  return (
    <Router>
      <Suspense fallback={<div>Loading...</div>}>
        {isAuthenticated && <Layout />}
        <Routes>
          {/* Rotas acessíveis apenas após autenticação */}
          {isAuthenticated && <Route path='/home' element={<Home />} />}
          {isAuthenticated && <Route path='/new-account' element={<NewAccount />} />}
          
          {/* Rotas acessíveis antes da autenticação */}
          {!isAuthenticated && <Route path='/login' element={<Login />} />}
          
          {/* Redireciona para a página de login se tentar acessar uma rota protegida sem autenticação */}
          <Route path='*' element={<Navigate to='/login' />} />
        </Routes>
      </Suspense>
    </Router>
  );
}

export default connector(App);
