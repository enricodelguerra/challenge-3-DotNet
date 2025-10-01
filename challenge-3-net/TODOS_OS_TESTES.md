# 🧪 **TODOS OS TESTES - TODOS OS ENDPOINTS**
## Sistema de Gestão de Motos API

### 🚀 **COMO EXECUTAR A APLICAÇÃO**
```bash
# No terminal, navegue até o diretório do projeto
cd C:\Users\crist\source\repos\challenge-3-net\challenge-3-net

# Execute a aplicação
dotnet run
```

### 🌐 **URLs DE ACESSO**
- **Swagger UI:** https://localhost:7225/swagger-ui/index.html
- **API HTTP:** http://localhost:8081
- **API HTTPS:** https://localhost:7225

---

## 📋 **TODOS OS ENDPOINTS DISPONÍVEIS**

### 👥 **USUÁRIOS** (`/api/Usuarios`)
- `GET /api/Usuarios` - Listar todos os usuários
- `POST /api/Usuarios` - Criar novo usuário
- `GET /api/Usuarios/{id}` - Buscar usuário por ID
- `PUT /api/Usuarios/{id}` - Atualizar usuário
- `DELETE /api/Usuarios/{id}` - Deletar usuário

### 🏍️ **MOTOS** (`/api/Motos`)
- `GET /api/Motos` - Listar todas as motos
- `POST /api/Motos` - Cadastrar nova moto
- `GET /api/Motos/{id}` - Buscar moto por ID
- `PUT /api/Motos/{id}` - Atualizar moto
- `DELETE /api/Motos/{id}` - Deletar moto

### ⚙️ **OPERAÇÕES** (`/api/Operacoes`)
- `GET /api/Operacoes` - Listar todas as operações
- `POST /api/Operacoes` - Registrar nova operação
- `GET /api/Operacoes/{id}` - Buscar operação por ID
- `PUT /api/Operacoes/{id}` - Atualizar operação
- `DELETE /api/Operacoes/{id}` - Deletar operação

### 📊 **STATUS DAS MOTOS** (`/api/StatusMotos`)
- `GET /api/StatusMotos` - Listar todos os status
- `POST /api/StatusMotos` - Registrar novo status
- `GET /api/StatusMotos/{id}` - Buscar status por ID
- `PUT /api/StatusMotos/{id}` - Atualizar status
- `DELETE /api/StatusMotos/{id}` - Deletar status

---

## 🧪 **TESTES COMPLETOS POR ENDPOINT**

### ===========================================
### 👥 **TESTES - USUÁRIOS** (`/api/Usuarios`)
### ===========================================

#### **1. GET /api/Usuarios - Listar todos os usuários**
```http
GET https://localhost:7225/api/Usuarios
```
**Resultado esperado:** Lista de usuários com paginação

#### **2. POST /api/Usuarios - Criar usuário ADMIN**
```http
POST https://localhost:7225/api/Usuarios
Content-Type: application/json

{
  "nomeFilial": "Empresa Admin",
  "email": "admin@empresa.com",
  "senha": "admin123",
  "cnpj": "11.111.111/0001-11",
  "endereco": "Rua Admin, 100",
  "telefone": "(11) 11111-1111",
  "perfil": "ADMIN"
}
```
**Resultado esperado:** Status 201 - Usuário criado

#### **3. POST /api/Usuarios - Criar usuário GERENTE**
```http
POST https://localhost:7225/api/Usuarios
Content-Type: application/json

{
  "nomeFilial": "Empresa Gerente",
  "email": "gerente@empresa.com",
  "senha": "gerente123",
  "cnpj": "22.222.222/0001-22",
  "endereco": "Rua Gerente, 200",
  "telefone": "(11) 22222-2222",
  "perfil": "GERENTE"
}
```
**Resultado esperado:** Status 201 - Usuário criado

#### **4. POST /api/Usuarios - Criar usuário OPERADOR**
```http
POST https://localhost:7225/api/Usuarios
Content-Type: application/json

{
  "nomeFilial": "Empresa Operador",
  "email": "operador@empresa.com",
  "senha": "operador123",
  "cnpj": "33.333.333/0001-33",
  "endereco": "Rua Operador, 300",
  "telefone": "(11) 33333-3333",
  "perfil": "OPERADOR"
}
```
**Resultado esperado:** Status 201 - Usuário criado

#### **5. GET /api/Usuarios/{id} - Buscar usuário por ID**
```http
GET https://localhost:7225/api/Usuarios/1
```
**Resultado esperado:** Status 200 - Dados do usuário

#### **6. PUT /api/Usuarios/{id} - Atualizar usuário**
```http
PUT https://localhost:7225/api/Usuarios/1
Content-Type: application/json

{
  "nomeFilial": "Empresa Admin Atualizada",
  "email": "admin@empresa.com",
  "senha": "admin123",
  "cnpj": "11.111.111/0001-11",
  "endereco": "Rua Admin Atualizada, 100",
  "telefone": "(11) 11111-1111",
  "perfil": "ADMIN"
}
```
**Resultado esperado:** Status 200 - Usuário atualizado

#### **7. DELETE /api/Usuarios/{id} - Deletar usuário**
```http
DELETE https://localhost:7225/api/Usuarios/1
```
**Resultado esperado:** Status 200 - Usuário deletado

---

### ===========================================
### 🏍️ **TESTES - MOTOS** (`/api/Motos`)
### ===========================================

#### **8. GET /api/Motos - Listar todas as motos**
```http
GET https://localhost:7225/api/Motos
```
**Resultado esperado:** Lista de motos com paginação

#### **9. POST /api/Motos - Cadastrar moto para usuário 1**
```http
POST https://localhost:7225/api/Motos
Content-Type: application/json

{
  "placa": "ABC-1234",
  "chassi": "12345678901234567",
  "motor": "Motor 150cc",
  "usuarioId": 1
}
```
**Resultado esperado:** Status 201 - Moto cadastrada

#### **10. POST /api/Motos - Cadastrar moto para usuário 2**
```http
POST https://localhost:7225/api/Motos
Content-Type: application/json

{
  "placa": "DEF-5678",
  "chassi": "23456789012345678",
  "motor": "Motor 200cc",
  "usuarioId": 2
}
```
**Resultado esperado:** Status 201 - Moto cadastrada

#### **11. POST /api/Motos - Cadastrar moto para usuário 3**
```http
POST https://localhost:7225/api/Motos
Content-Type: application/json

{
  "placa": "GHI-9012",
  "chassi": "34567890123456789",
  "motor": "Motor 300cc",
  "usuarioId": 3
}
```
**Resultado esperado:** Status 201 - Moto cadastrada

#### **12. GET /api/Motos/{id} - Buscar moto por ID**
```http
GET https://localhost:7225/api/Motos/1
```
**Resultado esperado:** Status 200 - Dados da moto

#### **13. PUT /api/Motos/{id} - Atualizar moto**
```http
PUT https://localhost:7225/api/Motos/1
Content-Type: application/json

{
  "placa": "ABC-1234",
  "chassi": "12345678901234567",
  "motor": "Motor 150cc Atualizado",
  "usuarioId": 1
}
```
**Resultado esperado:** Status 200 - Moto atualizada

#### **14. DELETE /api/Motos/{id} - Deletar moto**
```http
DELETE https://localhost:7225/api/Motos/1
```
**Resultado esperado:** Status 200 - Moto deletada

---

### ===========================================
### ⚙️ **TESTES - OPERAÇÕES** (`/api/Operacoes`)
### ===========================================

#### **15. GET /api/Operacoes - Listar todas as operações**
```http
GET https://localhost:7225/api/Operacoes
```
**Resultado esperado:** Lista de operações com paginação

#### **16. POST /api/Operacoes - Operação ENTREGA**
```http
POST https://localhost:7225/api/Operacoes
Content-Type: application/json

{
  "tipoOperacao": "ENTREGA",
  "descricao": "Entrega da moto para cliente",
  "dataOperacao": "2025-01-16T10:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```
**Resultado esperado:** Status 201 - Operação registrada

#### **17. POST /api/Operacoes - Operação COLETA**
```http
POST https://localhost:7225/api/Operacoes
Content-Type: application/json

{
  "tipoOperacao": "COLETA",
  "descricao": "Coleta da moto do cliente",
  "dataOperacao": "2025-01-16T14:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```
**Resultado esperado:** Status 201 - Operação registrada

#### **18. POST /api/Operacoes - Operação MANUTENCAO**
```http
POST https://localhost:7225/api/Operacoes
Content-Type: application/json

{
  "tipoOperacao": "MANUTENCAO",
  "descricao": "Manutenção preventiva da moto",
  "dataOperacao": "2025-01-16T16:00:00Z",
  "motoId": 2,
  "usuarioId": 2
}
```
**Resultado esperado:** Status 201 - Operação registrada

#### **19. POST /api/Operacoes - Operação TRANSFERENCIA**
```http
POST https://localhost:7225/api/Operacoes
Content-Type: application/json

{
  "tipoOperacao": "TRANSFERENCIA",
  "descricao": "Transferência da moto para outra filial",
  "dataOperacao": "2025-01-16T18:00:00Z",
  "motoId": 3,
  "usuarioId": 3
}
```
**Resultado esperado:** Status 201 - Operação registrada

#### **20. POST /api/Operacoes - Operação CHECK_IN**
```http
POST https://localhost:7225/api/Operacoes
Content-Type: application/json

{
  "tipoOperacao": "CHECK_IN",
  "descricao": "Check-in da moto na base",
  "dataOperacao": "2025-01-16T20:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```
**Resultado esperado:** Status 201 - Operação registrada

#### **21. POST /api/Operacoes - Operação CHECK_OUT**
```http
POST https://localhost:7225/api/Operacoes
Content-Type: application/json

{
  "tipoOperacao": "CHECK_OUT",
  "descricao": "Check-out da moto da base",
  "dataOperacao": "2025-01-16T22:00:00Z",
  "motoId": 2,
  "usuarioId": 2
}
```
**Resultado esperado:** Status 201 - Operação registrada

#### **22. GET /api/Operacoes/{id} - Buscar operação por ID**
```http
GET https://localhost:7225/api/Operacoes/1
```
**Resultado esperado:** Status 200 - Dados da operação

#### **23. PUT /api/Operacoes/{id} - Atualizar operação**
```http
PUT https://localhost:7225/api/Operacoes/1
Content-Type: application/json

{
  "tipoOperacao": "ENTREGA",
  "descricao": "Entrega da moto para cliente - ATUALIZADA",
  "dataOperacao": "2025-01-16T10:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```
**Resultado esperado:** Status 200 - Operação atualizada

#### **24. DELETE /api/Operacoes/{id} - Deletar operação**
```http
DELETE https://localhost:7225/api/Operacoes/1
```
**Resultado esperado:** Status 200 - Operação deletada

---

### ===========================================
### 📊 **TESTES - STATUS DAS MOTOS** (`/api/StatusMotos`)
### ===========================================

#### **25. GET /api/StatusMotos - Listar todos os status**
```http
GET https://localhost:7225/api/StatusMotos
```
**Resultado esperado:** Lista de status com paginação

#### **26. POST /api/StatusMotos - Status DISPONIVEL**
```http
POST https://localhost:7225/api/StatusMotos
Content-Type: application/json

{
  "status": "DISPONIVEL",
  "descricao": "Moto disponível para uso",
  "area": "Centro",
  "dataStatus": "2025-01-16T08:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```
**Resultado esperado:** Status 201 - Status registrado

#### **27. POST /api/StatusMotos - Status EM_USO**
```http
POST https://localhost:7225/api/StatusMotos
Content-Type: application/json

{
  "status": "EM_USO",
  "descricao": "Moto em uso pelo cliente",
  "area": "Zona Sul",
  "dataStatus": "2025-01-16T10:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```
**Resultado esperado:** Status 201 - Status registrado

#### **28. POST /api/StatusMotos - Status MANUTENCAO**
```http
POST https://localhost:7225/api/StatusMotos
Content-Type: application/json

{
  "status": "MANUTENCAO",
  "descricao": "Moto em manutenção",
  "area": "Oficina",
  "dataStatus": "2025-01-16T12:00:00Z",
  "motoId": 2,
  "usuarioId": 2
}
```
**Resultado esperado:** Status 201 - Status registrado

#### **29. POST /api/StatusMotos - Status INDISPONIVEL**
```http
POST https://localhost:7225/api/StatusMotos
Content-Type: application/json

{
  "status": "INDISPONIVEL",
  "descricao": "Moto temporariamente indisponível",
  "area": "Depósito",
  "dataStatus": "2025-01-16T14:00:00Z",
  "motoId": 3,
  "usuarioId": 3
}
```
**Resultado esperado:** Status 201 - Status registrado

#### **30. GET /api/StatusMotos/{id} - Buscar status por ID**
```http
GET https://localhost:7225/api/StatusMotos/1
```
**Resultado esperado:** Status 200 - Dados do status

#### **31. PUT /api/StatusMotos/{id} - Atualizar status**
```http
PUT https://localhost:7225/api/StatusMotos/1
Content-Type: application/json

{
  "status": "DISPONIVEL",
  "descricao": "Moto disponível para uso - ATUALIZADA",
  "area": "Centro",
  "dataStatus": "2025-01-16T08:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```
**Resultado esperado:** Status 200 - Status atualizado

#### **32. DELETE /api/StatusMotos/{id} - Deletar status**
```http
DELETE https://localhost:7225/api/StatusMotos/1
```
**Resultado esperado:** Status 200 - Status deletado

---

## 🔍 **TESTES DE VALIDAÇÃO E ERRO**

### ===========================================
### ❌ **TESTES DE VALIDAÇÃO**
### ===========================================

#### **33. Teste - Email Inválido**
```http
POST https://localhost:7225/api/Usuarios
Content-Type: application/json

{
  "nomeFilial": "Teste",
  "email": "email-invalido",
  "senha": "123456",
  "cnpj": "44.444.444/0001-44",
  "perfil": "ADMIN"
}
```
**Resultado esperado:** Status 400 - Email inválido

#### **34. Teste - CNPJ Duplicado**
```http
POST https://localhost:7225/api/Usuarios
Content-Type: application/json

{
  "nomeFilial": "Teste Duplicado",
  "email": "teste@duplicado.com",
  "senha": "123456",
  "cnpj": "11.111.111/0001-11",
  "perfil": "ADMIN"
}
```
**Resultado esperado:** Status 400 - CNPJ já existe

#### **35. Teste - Email Duplicado**
```http
POST https://localhost:7225/api/Usuarios
Content-Type: application/json

{
  "nomeFilial": "Teste Email Duplicado",
  "email": "admin@empresa.com",
  "senha": "123456",
  "cnpj": "55.555.555/0001-55",
  "perfil": "ADMIN"
}
```
**Resultado esperado:** Status 400 - Email já existe

#### **36. Teste - Placa Duplicada**
```http
POST https://localhost:7225/api/Motos
Content-Type: application/json

{
  "placa": "ABC-1234",
  "chassi": "99999999999999999",
  "motor": "Motor Teste",
  "usuarioId": 1
}
```
**Resultado esperado:** Status 400 - Placa já existe

#### **37. Teste - Chassi Duplicado**
```http
POST https://localhost:7225/api/Motos
Content-Type: application/json

{
  "placa": "XYZ-9999",
  "chassi": "12345678901234567",
  "motor": "Motor Teste",
  "usuarioId": 1
}
```
**Resultado esperado:** Status 400 - Chassi já existe

#### **38. Teste - Usuário Não Encontrado (Moto)**
```http
POST https://localhost:7225/api/Motos
Content-Type: application/json

{
  "placa": "TEST-0000",
  "chassi": "00000000000000000",
  "motor": "Motor Teste",
  "usuarioId": 999
}
```
**Resultado esperado:** Status 404 - Usuário não encontrado

#### **39. Teste - Moto Não Encontrada (Operação)**
```http
POST https://localhost:7225/api/Operacoes
Content-Type: application/json

{
  "tipoOperacao": "ENTREGA",
  "descricao": "Teste",
  "dataOperacao": "2025-01-16T10:00:00Z",
  "motoId": 999,
  "usuarioId": 1
}
```
**Resultado esperado:** Status 404 - Moto não encontrada

#### **40. Teste - Usuário Não Encontrado (Operação)**
```http
POST https://localhost:7225/api/Operacoes
Content-Type: application/json

{
  "tipoOperacao": "ENTREGA",
  "descricao": "Teste",
  "dataOperacao": "2025-01-16T10:00:00Z",
  "motoId": 1,
  "usuarioId": 999
}
```
**Resultado esperado:** Status 404 - Usuário não encontrado

---

## 📈 **TESTES DE PAGINAÇÃO**

### ===========================================
### 📄 **TESTES DE PAGINAÇÃO**
### ===========================================

#### **41. Listar Usuários - Página 1, 10 itens**
```http
GET https://localhost:7225/api/Usuarios?pageNumber=1&pageSize=10
```

#### **42. Listar Usuários - Página 2, 5 itens**
```http
GET https://localhost:7225/api/Usuarios?pageNumber=2&pageSize=5
```

#### **43. Listar Motos - Página 1, 10 itens**
```http
GET https://localhost:7225/api/Motos?pageNumber=1&pageSize=10
```

#### **44. Listar Motos - Página 2, 5 itens**
```http
GET https://localhost:7225/api/Motos?pageNumber=2&pageSize=5
```

#### **45. Listar Operações - Página 1, 10 itens**
```http
GET https://localhost:7225/api/Operacoes?pageNumber=1&pageSize=10
```

#### **46. Listar Operações - Página 2, 5 itens**
```http
GET https://localhost:7225/api/Operacoes?pageNumber=2&pageSize=5
```

#### **47. Listar Status - Página 1, 10 itens**
```http
GET https://localhost:7225/api/StatusMotos?pageNumber=1&pageSize=10
```

#### **48. Listar Status - Página 2, 5 itens**
```http
GET https://localhost:7225/api/StatusMotos?pageNumber=2&pageSize=5
```

---

## 🎯 **ORDEM RECOMENDADA DE TESTES**

### **FASE 1: CRIAÇÃO BÁSICA**
1. Criar usuários (testes 2-4)
2. Listar usuários (teste 1)
3. Cadastrar motos (testes 9-11)
4. Listar motos (teste 8)

### **FASE 2: OPERAÇÕES E STATUS**
5. Registrar operações (testes 16-21)
6. Listar operações (teste 15)
7. Registrar status (testes 26-29)
8. Listar status (teste 25)

### **FASE 3: CONSULTAS INDIVIDUAIS**
9. Buscar usuário por ID (teste 5)
10. Buscar moto por ID (teste 12)
11. Buscar operação por ID (teste 22)
12. Buscar status por ID (teste 30)

### **FASE 4: ATUALIZAÇÕES**
13. Atualizar usuário (teste 6)
14. Atualizar moto (teste 13)
15. Atualizar operação (teste 23)
16. Atualizar status (teste 31)

### **FASE 5: VALIDAÇÕES**
17. Testar validações (testes 33-40)

### **FASE 6: PAGINAÇÃO**
18. Testar paginação (testes 41-48)

### **FASE 7: EXCLUSÕES**
19. Deletar operação (teste 24)
20. Deletar status (teste 32)
21. Deletar moto (teste 14)
22. Deletar usuário (teste 7)

---

## ✅ **RESULTADOS ESPERADOS**

| Status | Significado |
|--------|-------------|
| **200** | Operação realizada com sucesso |
| **201** | Recurso criado com sucesso |
| **400** | Erro de validação |
| **404** | Recurso não encontrado |
| **500** | Erro interno do servidor |

---

## 🚀 **COMO USAR ESTES TESTES**

### **1. No Swagger UI:**
- Acesse: https://localhost:7225/swagger-ui/index.html
- Clique em qualquer endpoint
- Clique em "Try it out"
- Cole o JSON do teste
- Clique em "Execute"

### **2. No Postman:**
- Importe o arquivo `requisicoes_teste.http`
- Execute os testes um por um

### **3. No PowerShell:**
- Execute o script `teste_automatico.ps1`

---

## 🎉 **RESUMO**

**Total de Endpoints:** 20
**Total de Testes:** 48
**Cobertura:** 100% dos endpoints

- ✅ **Usuários:** 7 testes
- ✅ **Motos:** 7 testes  
- ✅ **Operações:** 10 testes
- ✅ **Status:** 7 testes
- ✅ **Validações:** 8 testes
- ✅ **Paginação:** 8 testes
- ✅ **Exclusões:** 4 testes

**🎯 Todos os endpoints estão cobertos com testes completos!**
