import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // Importe o CommonModule
import { FormsModule } from '@angular/forms';  // Importe o FormsModule
import axios from 'axios';

interface ApiResponse {
  success: boolean;
  message: string;
  data: any;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],  // Adicione o FormsModule aqui
  templateUrl: './app.HomeComponent.html',  // Ajuste o caminho conforme necessário
  styleUrls: ['./app.HomeComponent.css']   // Ajuste o caminho conforme necessário
})
export class AppHomeComponent implements OnInit {
  title = 'Home';
  clientsPF: any[] = [];  // Inicializando a variável como um array vazio
  clientsPJ: any[] = [];  // Inicializando a variável como um array vazio
  errorMessage: string = '';  // Mensagem de erro

  // Estrutura do cliente PF
  clientePF = {
    nome: '',
    cpf: '',
    rg: '',
    email: '',
    telefone: '',
    nascimento: ''
  };

  // Estrutura do cliente PJ
  clientePJ = {
    nomeFantasia: '',
    cnpj: '',
    razaoSocial: '',
    email: '',
    dataAbertura: ''
  };

  // Cliente selecionado para edição (PF ou PJ)
  selectedClientPF: any = null;
  selectedClientPJ: any = null;

  // Carregamento inicial do componente
  async ngOnInit(): Promise<void> {
    await this.getClientsPF();  // Carregar clientes PF
    await this.getClientsPJ();  // Carregar clientes PJ
  }

  // Buscar clientes PF
  async getClientsPF(): Promise<void> {
    try {
      const response = await axios.get('https://localhost:7297/Clients/GetAllClientPF');
      const data: ApiResponse = response.data;

      if (data.success) {
        this.clientsPF = data.data;  // Atualizar lista de clientes PF
      } else {
        this.errorMessage = data.message;
      }
    } catch (error) {
      this.errorMessage = 'Erro ao acessar a API.';
      console.error(error);
    }
  }

  // Buscar clientes PJ
  async getClientsPJ(): Promise<void> {
    try {
      const response = await axios.get('https://localhost:7297/Clients/GetAllClientPJ');
      const data: ApiResponse = response.data;

      if (data.success) {
        this.clientsPJ = data.data;  // Atualizar lista de clientes PJ
      } else {
        this.errorMessage = data.message;
      }
    } catch (error) {
      this.errorMessage = 'Erro ao acessar a API.';
      console.error(error);
    }
  }

  // Selecionar cliente PF para edição
  selectClientPF(client: any): void {
    this.selectedClientPF = { ...client };
    this.clientePF = { ...client };
  }

  // Selecionar cliente PJ para edição
  selectClientPJ(client: any): void {
    this.selectedClientPJ = { ...client };
    this.clientePJ = { ...client };
  }

  // Criar ou editar cliente PF
  async onSubmitPF(): Promise<void> {
    if (this.isFormValidPF()) {
      try {
        let response;
        let isEdit = false; 
        if (this.selectedClientPF && this.selectedClientPF.id) {
          isEdit = true;
          // Editar cliente PF
          response = await axios.post('https://localhost:7297/Clients/CreateOrEditClientPF', this.clientePF);
        } else {
          // Criar novo cliente PF
          response = await axios.post('https://localhost:7297/Clients/CreateOrEditClientPF', this.clientePF);
        }
        const data: ApiResponse = response.data;

        if (data.success) {
          this.resetFormPF();  // Limpar o formulário
          this.getClientsPF();  // Recarregar lista
          alert(isEdit? 'Cliente PF atualizado com sucesso!' : 'Cliente PF criado com sucesso!');
        } else {
          this.errorMessage = data.message;
        }
      } catch (error) {
        this.errorMessage = 'Erro ao criar ou editar cliente PF.' + error;
        console.error(error);
      }
    } else {
      alert('Por favor, preencha todos os campos!');
    }
  }

  // Criar ou editar cliente PJ
  async onSubmitPJ(): Promise<void> {
    if (this.isFormValidPJ()) {
      try {
        let response;
        let isEdit = false; 
        if (this.selectedClientPJ && this.selectedClientPJ.id) {
          isEdit = true;
          // Editar cliente PJ
          response = await axios.post('https://localhost:7297/Clients/CreateOrEditClientPJ', this.clientePJ);
        } else {
          // Criar novo cliente PJ
          response = await axios.post('https://localhost:7297/Clients/CreateOrEditClientPJ', this.clientePJ);
        }
        const data: ApiResponse = response.data;

        if (data.success) {
          this.resetFormPJ();  // Limpar o formulário
          this.getClientsPJ();  // Recarregar lista
          alert(isEdit ? 'Cliente PJ atualizado com sucesso!' : 'Cliente PJ criado com sucesso!');
        } else {
          this.errorMessage = data.message;
        }
      } catch (error) {
        this.errorMessage = 'Erro ao criar ou editar cliente PJ.';
        console.error(error);
      }
    } else {
      alert('Por favor, preencha todos os campos!');
    }
  }

  // Limpar formulário PF
  resetFormPF(): void {
    this.clientePF = {
      nome: '',
      cpf: '',
      rg: '',
      email: '',
      telefone: '',
      nascimento: ''
    };
    this.selectedClientPF = null;
  }

  // Limpar formulário PJ
  resetFormPJ(): void {
    this.clientePJ = {
      nomeFantasia: '',
      cnpj: '',
      razaoSocial: '',
      email: '',
      dataAbertura: ''
    };
    this.selectedClientPJ = null;
  }

  // Deletar cliente PF
  async deleteClientPF(id: number): Promise<void> {
    try {
      const response = await axios.delete(`https://localhost:7297/Clients/DeleteClientPF/${id}`);
      const data: ApiResponse = response.data;

      if (data.success) {
        this.clientsPF = this.clientsPF.filter(client => client.id !== id);  // Remover cliente PF
        alert('Cliente PF deletado com sucesso!');
      } else {
        this.errorMessage = data.message;
      }
    } catch (error) {
      this.errorMessage = 'Erro ao deletar cliente PF.';
      console.error(error);
    }
  }

  // Deletar cliente PF com confirmação
  confirmDeleteClientPF(id: number): void {
    const confirmation = window.confirm('Você tem certeza que deseja excluir este cliente PF?');
    if (confirmation) {
      this.deleteClientPF(id);
    }
  }

  // Deletar cliente PJ com confirmação
  confirmDeleteClientPJ(id: number): void {
    const confirmation = window.confirm('Você tem certeza que deseja excluir este cliente PJ?');
    if (confirmation) {
      this.deleteClientPJ(id);
    }
  }

  // Deletar cliente PJ
  async deleteClientPJ(id: number): Promise<void> {
    try {
      const response = await axios.delete(`https://localhost:7297/Clients/DeleteClientPJ/${id}`);
      const data: ApiResponse = response.data;

      if (data.success) {
        this.clientsPJ = this.clientsPJ.filter(client => client.id !== id);  // Remover cliente PJ
        alert('Cliente PJ deletado com sucesso!');
      } else {
        this.errorMessage = data.message;
      }
    } catch (error) {
      this.errorMessage = 'Erro ao deletar cliente PJ.';
      console.error(error);
    }
  }

  // Validar formulário PF
  isFormValidPF(): boolean {
    return (
      this.clientePF.nome.trim() !== '' &&
      this.clientePF.cpf.trim() !== '' &&
      this.clientePF.rg.trim() !== '' &&
      this.clientePF.email.trim() !== '' &&
      this.clientePF.telefone.trim() !== '' &&
      this.clientePF.nascimento.trim() !== ''
    );
  }

  // Validar formulário PJ
  isFormValidPJ(): boolean {
    return (
      this.clientePJ.nomeFantasia.trim() !== '' &&
      this.clientePJ.cnpj.trim() !== '' &&
      this.clientePJ.razaoSocial.trim() !== '' &&
      this.clientePJ.email.trim() !== '' &&
      this.clientePJ.dataAbertura.trim() !== ''
    );
  }
}
