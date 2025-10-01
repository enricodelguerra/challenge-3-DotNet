# Sistema de Gestão de Motos API

## 📋 Sobre o Projeto

API RESTful desenvolvida em .NET 9 para gerenciamento de motos, usuários, operações e status. O sistema implementa os princípios SOLID, Clean Code e boas práticas de desenvolvimento, incluindo HATEOAS, paginação e documentação completa com Swagger/OpenAPI.

## 👥 Integrantes

- **Desenvolvedor Principal**: [Seu Nome]
- **Instituição**: FIAP - Advanced Business Development with .NET

## 🏗️ Arquitetura

### Justificativa da Arquitetura

A arquitetura foi projetada seguindo os princípios SOLID e Clean Architecture:

- **Single Responsibility Principle (SRP)**: Cada classe tem uma única responsabilidade
- **Open/Closed Principle (OCP)**: Aberto para extensão, fechado para modificação
- **Liskov Substitution Principle (LSP)**: Interfaces podem ser substituídas por suas implementações
- **Interface Segregation Principle (ISP)**: Interfaces específicas e coesas
- **Dependency Inversion Principle (DIP)**: Dependências de abstrações, não de implementações

### Estrutura do Projeto

```
challenge-3-net/
├── Controllers/          # Controllers RESTful
├── Data/                # Contexto do Entity Framework
├── Models/              # Entidades de domínio e DTOs
│   ├── DTOs/           # Data Transfer Objects
│   └── *.cs            # Entidades de domínio
├── Repositories/        # Camada de acesso a dados
│   ├── Interfaces/     # Contratos dos repositórios
│   └── *.cs            # Implementações dos repositórios
├── Services/           # Camada de negócio
│   ├── Interfaces/     # Contratos dos serviços
│   ├── Mapping/        # Configuração do AutoMapper
│   └── *.cs            # Implementações dos serviços
└── Program.cs          # Configuração da aplicação
```

## 🚀 Tecnologias Utilizadas

- **.NET 9** - Framework principal
- **Entity Framework Core 9** - ORM para acesso a dados
- **SQL Server LocalDB** - Banco de dados
- **AutoMapper** - Mapeamento de objetos
- **Swagger/OpenAPI** - Documentação da API
- **BCrypt** - Criptografia de senhas
- **FluentValidation** - Validação de dados

## 📊 Entidades Principais

### 1. Usuario
- **Justificativa**: Central para autenticação e autorização do sistema
- **Campos**: ID, NomeFilial, Email, SenhaHash, CNPJ, Endereco, Telefone, Perfil
- **Perfis**: ADMIN, GERENTE, OPERADOR

### 2. Moto
- **Justificativa**: Entidade principal do negócio, representa os veículos gerenciados
- **Campos**: ID, Placa, Chassi, Motor, UsuarioId, DataCriacao, DataAtualizacao
- **Relacionamentos**: Pertence a um Usuario

### 3. Operacao
- **Justificativa**: Registra todas as ações realizadas com as motos
- **Campos**: ID, TipoOperacao, Descricao, DataOperacao, MotoId, UsuarioId
- **Tipos**: ENTREGA, COLETA, MANUTENCAO, TRANSFERENCIA, CHECK_IN, CHECK_OUT

### 4. StatusMoto
- **Justificativa**: Controla o estado atual e histórico das motos
- **Campos**: ID, Status, Descricao, Area, DataStatus, MotoId, UsuarioId
- **Status**: DISPONIVEL, EM_USO, MANUTENCAO, INDISPONIVEL, etc.

## 🔧 Instalação e Execução

### Pré-requisitos

- .NET 9 SDK
- SQL Server LocalDB (ou SQL Server)
- Visual Studio 2022 ou VS Code

### Passos para Execução

1. **Clone o repositório**
   ```bash
   git clone [URL_DO_REPOSITORIO]
   cd challenge-3-net
   ```

2. **Restaure as dependências**
   ```bash
   dotnet restore
   ```

3. **Configure a string de conexão**
   - Edite o arquivo `appsettings.json`
   - Ajuste a connection string conforme seu ambiente

4. **Execute a aplicação**
   ```bash
   dotnet run
   ```

5. **Acesse a documentação**
   - Swagger UI: `https://localhost:7000`
   - API Base: `https://localhost:7000/api`

## 📚 Documentação da API

### Endpoints Principais

#### Usuários (`/api/usuarios`)
- `GET /api/usuarios` - Lista usuários (paginado)
- `GET /api/usuarios/{id}` - Busca usuário por ID
- `POST /api/usuarios` - Cria novo usuário
- `PUT /api/usuarios/{id}` - Atualiza usuário
- `DELETE /api/usuarios/{id}` - Exclui usuário

#### Motos (`/api/motos`)
- `GET /api/motos` - Lista motos (paginado)
- `GET /api/motos/{id}` - Busca moto por ID
- `GET /api/motos/placa/{placa}` - Busca moto por placa
- `GET /api/motos/chassi/{chassi}` - Busca moto por chassi
- `GET /api/motos/usuario/{usuarioId}` - Lista motos por usuário
- `POST /api/motos` - Cria nova moto
- `PUT /api/motos/{id}` - Atualiza moto
- `DELETE /api/motos/{id}` - Exclui moto

#### Operações (`/api/operacoes`)
- `GET /api/operacoes` - Lista operações (paginado)
- `GET /api/operacoes/{id}` - Busca operação por ID
- `GET /api/operacoes/moto/{motoId}` - Lista operações por moto
- `GET /api/operacoes/usuario/{usuarioId}` - Lista operações por usuário
- `POST /api/operacoes` - Cria nova operação
- `PUT /api/operacoes/{id}` - Atualiza operação
- `DELETE /api/operacoes/{id}` - Exclui operação

#### Status de Motos (`/api/status-motos`)
- `GET /api/status-motos` - Lista status (paginado)
- `GET /api/status-motos/{id}` - Busca status por ID
- `GET /api/status-motos/moto/{motoId}/atual` - Status atual da moto
- `GET /api/status-motos/moto/{motoId}/historico` - Histórico de status da moto
- `GET /api/status-motos/tipo/{status}` - Lista status por tipo
- `POST /api/status-motos` - Cria novo status
- `PUT /api/status-motos/{id}` - Atualiza status
- `DELETE /api/status-motos/{id}` - Exclui status

### Exemplos de Uso

#### Criar Usuário
```http
POST /api/usuarios
Content-Type: application/json

{
  "nomeFilial": "Empresa Exemplo",
  "email": "contato@empresa.com",
  "senha": "senha123",
  "cnpj": "12.345.678/0001-90",
  "endereco": "Rua Exemplo, 123",
  "telefone": "(11) 99999-9999",
  "perfil": "ADMIN"
}
```

#### Criar Moto
```http
POST /api/motos
Content-Type: application/json

{
  "placa": "ABC-1234",
  "chassi": "12345678901234567",
  "motor": "250cc",
  "usuarioId": 1
}
```

#### Criar Operação
```http
POST /api/operacoes
Content-Type: application/json

{
  "tipoOperacao": "ENTREGA",
  "descricao": "Entrega da moto para cliente",
  "motoId": 1,
  "usuarioId": 1
}
```

#### Atualizar Status da Moto
```http
POST /api/status-motos
Content-Type: application/json

{
  "status": "EM_USO",
  "descricao": "Moto em uso pelo cliente",
  "area": "Zona Sul",
  "motoId": 1,
  "usuarioId": 1
}
```

## 🧪 Testes

### Executar Testes
```bash
dotnet test
```

### Cobertura de Testes
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 🔒 Segurança

- Senhas criptografadas com BCrypt
- Validação de dados com Data Annotations e FluentValidation
- CORS configurado para desenvolvimento
- Validação de unicidade (email, CNPJ, placa, chassi)

## 📈 Performance

- Paginação em todos os endpoints de listagem
- Índices no banco de dados para campos únicos
- Lazy loading configurado no Entity Framework
- AutoMapper para mapeamento eficiente de objetos

## 🚀 Deploy

### Docker
```bash
docker build -t sistema-gestao-motos .
docker run -p 7000:7000 sistema-gestao-motos
```

### Azure
1. Configure a connection string no Azure
2. Publique a aplicação
3. Configure o banco de dados SQL Server

## 📝 Changelog

### v1.0.0
- Implementação inicial da API
- CRUD completo para todas as entidades
- Documentação Swagger/OpenAPI
- Implementação dos princípios SOLID
- HATEOAS e paginação
- Validações e tratamento de erros

## 🤝 Contribuição

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 📞 Contato

- **Email**: dev@fiap.com
- **Projeto**: [Link do GitHub]

---

**Desenvolvido com ❤️ para o desafio Advanced Business Development with .NET - FIAP**
