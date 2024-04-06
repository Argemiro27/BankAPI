import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import GlobalStyle from './style/global.tsx'
import { ToastContainer } from 'react-toastify';
import store from './react-redux/auth/store.tsx';
import { Provider } from 'react-redux';
ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider store={store}> {/* Forneça o Redux Store como prop "store" para o Provider */}

      <App />
      <ToastContainer />
      <GlobalStyle />
    </Provider>
  </React.StrictMode>,
)
