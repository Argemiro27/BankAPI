

export interface IUsuario {
  id_usuario: number;
  nome: string;
  email: string;
  senha: string;
  telefone?: string;
  endereco?: string;
  per_comissao?: string;
  num_pix?: string;
  url_foto?: string;
  id_empresa?: number;
  id_cargo?: number;
  nom_cargo: string;
}
