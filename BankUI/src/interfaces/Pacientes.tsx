interface IPaciente {
    id_paciente?: number;
    nom_paciente: string;
    email?: string;
    cpf?: string;
    telefone?: string;
    data_nasc?: Date;
    nom_profissao?: string;
    flg_sexo?: string;
    flg_tiposang?: string;
    endereco?: string;
    flg_est_civil?: string;
    obs?: string;
    nom_responsavel?: string;
    cpf_resp?: string;
    id_convenio?: number;
  }