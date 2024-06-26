import { FormEvent, useState } from 'react';
import { TextField, Box, Divider, InputAdornment, Typography } from '@mui/material';
import BoxAuthImg from '../../global/components/BoxAuthImg';
import { BtnAuth, BtnAuthSec } from '../../global/components/BtnAuth';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import LockIcon from '@mui/icons-material/Lock';
import { Link } from 'react-router-dom';
import LoginIcon from '@mui/icons-material/Login';
import PersonAddAltIcon from '@mui/icons-material/PersonAddAlt';
import { toast } from 'react-toastify';
import AuthService from '../../../services/auth';
import BoxAuth from '../../global/components/BoxAuth';
import colors from '../../../style/theme/colors';
import { getUserDataFromLocalStorage } from '../../../services/storage/userAccountService';

function Login() {
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [error] = useState('');

    const handleLogin = async (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        if (!email || !senha) {
            console.log('Por favor, preencha todos os campos.');
            return;
        }
        try {
            const data = await AuthService.login(email, senha);
            console.log('Login bem-sucedido:', data);

            // Exibir mensagem de sucesso
            toast.success('Login bem-sucedido');

            // Recuperar dados do usuário do localStorage
            const userData = getUserDataFromLocalStorage();
            // Aguardar 4 segundos antes do redirecionamento
            setTimeout(() => {
                // Redirecionar para a página de dashboard0
                if (userData && userData.dataAccount) {
                    window.location.href = '/home';
                }
                if (userData && userData.dataAccount == null){
                    window.location.href = '/new-account';
                }
            }, 1000);
        } catch (error) {
            console.error('Erro durante o login:', (error as Error).message);

            // Exibir mensagem de erro
            toast.error((error as Error).message || 'Erro interno do servidor');
        }
    };

    return (
        <div className='d-flex'>
            <BoxAuthImg/>
            <BoxAuth>
                <form onSubmit={handleLogin} style={{ textAlign: 'center', maxWidth: '300px' }}>
                    <h2>
                        Faça <span style={{ color: colors.secondary }}>login!</span>
                    </h2>

                    <AccountCircleIcon sx={{ fontSize: '200px' }} />
                    <TextField
                        label="Email"
                        name="email"
                        variant="outlined"
                        margin="normal"
                        fullWidth
                        required
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <AccountCircleIcon />
                                </InputAdornment>
                            ),
                        }}
                    />
                    <TextField
                        label="Senha"
                        name="senha"
                        type="senha"
                        variant="outlined"
                        margin="normal"
                        fullWidth
                        required
                        value={senha}
                        onChange={(e) => setSenha(e.target.value)}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <LockIcon />
                                </InputAdornment>
                            ),
                        }}
                    />


                    <BtnAuth type="submit" variant="contained" className='mt-2 mb-2' endIcon={<LoginIcon />}>
                        Entrar
                    </BtnAuth>
                    {error && (
                        <Typography color="error" variant="body2" gutterBottom>
                            {error}
                        </Typography>
                    )}
                    <Box mt={2} mb={1}>
                        <p>ESQUECEU SUA SENHA?</p>
                        <Divider className='mt-4 mb-4' />
                        <p>Não possui uma conta?</p>
                        <Link type="button" className='btn' to={'/cadastro'}>
                            <BtnAuthSec startIcon={<PersonAddAltIcon />}>
                                Faça um golaço! Crie sua conta!
                            </BtnAuthSec>
                        </Link>
                    </Box>
                </form>
            </BoxAuth>
        </div>
    );
}

export default Login;
