# 🧪 **TESTES COMPLETOS DA API - Sistema de Gestão de Motos**

## 📋 **Configuração Inicial**

1. **Execute a aplicação:**
   ```bash
   dotnet run
   ```

2. **Acesse o Swagger:**
   ```
   http://localhost:5052
   ```

---

## 👥 **TESTES - USUÁRIOS**

### **1. Criar Usuário Admin**
```json
POST /api/Usuarios
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

### **2. Criar Usuário Gerente**
```json
POST /api/Usuarios
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

### **3. Criar Usuário Operador**
```json
POST /api/Usuarios
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

### **4. Listar Todos os Usuários**
```
GET /api/Usuarios
```

### **5. Buscar Usuário por ID**
```
GET /api/Usuarios/1
```

### **6. Atualizar Usuário**
```json
PUT /api/Usuarios/1
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

---

## 🏍️ **TESTES - MOTOS**

### **7. Cadastrar Moto para Usuário 1**
```json
POST /api/Motos
{
  "placa": "ABC-1234",
  "chassi": "12345678901234567",
  "motor": "Motor 150cc",
  "usuarioId": 1
}
```

### **8. Cadastrar Moto para Usuário 2**
```json
POST /api/Motos
{
  "placa": "DEF-5678",
  "chassi": "23456789012345678",
  "motor": "Motor 200cc",
  "usuarioId": 2
}
```

### **9. Cadastrar Moto para Usuário 3**
```json
POST /api/Motos
{
  "placa": "GHI-9012",
  "chassi": "34567890123456789",
  "motor": "Motor 300cc",
  "usuarioId": 3
}
```

### **10. Listar Todas as Motos**
```
GET /api/Motos
```

### **11. Buscar Moto por ID**
```
GET /api/Motos/1
```

### **12. Atualizar Moto**
```json
PUT /api/Motos/1
{
  "placa": "ABC-1234",
  "chassi": "12345678901234567",
  "motor": "Motor 150cc Atualizado",
  "usuarioId": 1
}
```

---

## ⚙️ **TESTES - OPERAÇÕES**

### **13. Registrar Operação de Entrega**
```json
POST /api/Operacoes
{
  "tipoOperacao": "ENTREGA",
  "descricao": "Entrega da moto para cliente",
  "dataOperacao": "2025-01-16T10:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```

### **14. Registrar Operação de Coleta**
```json
POST /api/Operacoes
{
  "tipoOperacao": "COLETA",
  "descricao": "Coleta da moto do cliente",
  "dataOperacao": "2025-01-16T14:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```

### **15. Registrar Operação de Manutenção**
```json
POST /api/Operacoes
{
  "tipoOperacao": "MANUTENCAO",
  "descricao": "Manutenção preventiva da moto",
  "dataOperacao": "2025-01-16T16:00:00Z",
  "motoId": 2,
  "usuarioId": 2
}
```

### **16. Registrar Operação de Transferência**
```json
POST /api/Operacoes
{
  "tipoOperacao": "TRANSFERENCIA",
  "descricao": "Transferência da moto para outra filial",
  "dataOperacao": "2025-01-16T18:00:00Z",
  "motoId": 3,
  "usuarioId": 3
}
```

### **17. Registrar Check-in**
```json
POST /api/Operacoes
{
  "tipoOperacao": "CHECK_IN",
  "descricao": "Check-in da moto na base",
  "dataOperacao": "2025-01-16T20:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```

### **18. Registrar Check-out**
```json
POST /api/Operacoes
{
  "tipoOperacao": "CHECK_OUT",
  "descricao": "Check-out da moto da base",
  "dataOperacao": "2025-01-16T22:00:00Z",
  "motoId": 2,
  "usuarioId": 2
}
```

### **19. Listar Todas as Operações**
```
GET /api/Operacoes
```

### **20. Buscar Operação por ID**
```
GET /api/Operacoes/1
```

---

## 📊 **TESTES - STATUS DAS MOTOS**

### **21. Registrar Status Disponível**
```json
POST /api/StatusMotos
{
  "status": "DISPONIVEL",
  "descricao": "Moto disponível para uso",
  "area": "Centro",
  "dataStatus": "2025-01-16T08:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```

### **22. Registrar Status Em Uso**
```json
POST /api/StatusMotos
{
  "status": "EM_USO",
  "descricao": "Moto em uso pelo cliente",
  "area": "Zona Sul",
  "dataStatus": "2025-01-16T10:00:00Z",
  "motoId": 1,
  "usuarioId": 1
}
```

### **23. Registrar Status Manutenção**
```json
POST /api/StatusMotos
{
  "status": "MANUTENCAO",
  "descricao": "Moto em manutenção",
  "area": "Oficina",
  "dataStatus": "2025-01-16T12:00:00Z",
  "motoId": 2,
  "usuarioId": 2
}
```

### **24. Registrar Status Indisponível**
```json
POST /api/StatusMotos
{
  "status": "INDISPONIVEL",
  "descricao": "Moto temporariamente indisponível",
  "area": "Depósito",
  "dataStatus": "2025-01-16T14:00:00Z",
  "motoId": 3,
  "usuarioId": 3
}
```

### **25. Listar Todos os Status**
```
GET /api/StatusMotos
```

### **26. Buscar Status por ID**
```
GET /api/StatusMotos/1
```

---

## 🔍 **TESTES DE VALIDAÇÃO E ERRO**

### **27. Teste de Validação - Email Inválido**
```json
POST /api/Usuarios
{
  "nomeFilial": "Teste",
  "email": "email-invalido",
  "senha": "123456",
  "cnpj": "44.444.444/0001-44",
  "perfil": "ADMIN"
}
```
**Resultado esperado:** Erro 400 - Email inválido

### **28. Teste de Validação - CNPJ Duplicado**
```json
POST /api/Usuarios
{
  "nomeFilial": "Teste Duplicado",
  "email": "teste@duplicado.com",
  "senha": "123456",
  "cnpj": "11.111.111/0001-11",
  "perfil": "ADMIN"
}
```
**Resultado esperado:** Erro 400 - CNPJ já existe

### **29. Teste de Validação - Placa Duplicada**
```json
POST /api/Motos
{
  "placa": "ABC-1234",
  "chassi": "99999999999999999",
  "motor": "Motor Teste",
  "usuarioId": 1
}
```
**Resultado esperado:** Erro 400 - Placa já existe

### **30. Teste de Validação - Chassi Duplicado**
```json
POST /api/Motos
{
  "placa": "XYZ-9999",
  "chassi": "12345678901234567",
  "motor": "Motor Teste",
  "usuarioId": 1
}
```
**Resultado esperado:** Erro 400 - Chassi já existe

### **31. Teste de Validação - Usuário Não Encontrado**
```json
POST /api/Motos
{
  "placa": "TEST-0000",
  "chassi": "00000000000000000",
  "motor": "Motor Teste",
  "usuarioId": 999
}
```
**Resultado esperado:** Erro 404 - Usuário não encontrado

### **32. Teste de Validação - Moto Não Encontrada**
```json
POST /api/Operacoes
{
  "tipoOperacao": "ENTREGA",
  "descricao": "Teste",
  "dataOperacao": "2025-01-16T10:00:00Z",
  "motoId": 999,
  "usuarioId": 1
}
```
**Resultado esperado:** Erro 404 - Moto não encontrada

---

## 🗑️ **TESTES DE EXCLUSÃO**

### **33. Deletar Operação**
```
DELETE /api/Operacoes/1
```

### **34. Deletar Status**
```
DELETE /api/StatusMotos/1
```

### **35. Deletar Moto**
```
DELETE /api/Motos/1
```

### **36. Deletar Usuário**
```
DELETE /api/Usuarios/1
```

---

## 📈 **TESTES DE PAGINAÇÃO**

### **37. Listar Usuários com Paginação**
```
GET /api/Usuarios?pageNumber=1&pageSize=10
```

### **38. Listar Motos com Paginação**
```
GET /api/Motos?pageNumber=1&pageSize=10
```

### **39. Listar Operações com Paginação**
```
GET /api/Operacoes?pageNumber=1&pageSize=10
```

### **40. Listar Status com Paginação**
```
GET /api/StatusMotos?pageNumber=1&pageSize=10
```

---

## 🎯 **ORDEM RECOMENDADA DE TESTES**

1. **Criar usuários** (testes 1-3)
2. **Listar usuários** (teste 4)
3. **Cadastrar motos** (testes 7-9)
4. **Listar motos** (teste 10)
5. **Registrar operações** (testes 13-18)
6. **Listar operações** (teste 19)
7. **Registrar status** (testes 21-24)
8. **Listar status** (teste 25)
9. **Testar validações** (testes 27-32)
10. **Testar exclusões** (testes 33-36)
11. **Testar paginação** (testes 37-40)

---

## ✅ **RESULTADOS ESPERADOS**

- **Status 200:** Operação realizada com sucesso
- **Status 201:** Recurso criado com sucesso
- **Status 400:** Erro de validação
- **Status 404:** Recurso não encontrado
- **Status 500:** Erro interno do servidor

---

## 🚀 **DICAS PARA TESTAR**

1. **Use o Swagger UI** para facilitar os testes
2. **Teste um endpoint por vez** para verificar o funcionamento
3. **Verifique os logs** no terminal para debug
4. **Teste cenários de erro** para validar as validações
5. **Use IDs válidos** dos recursos criados anteriormente

---

**🎉 Boa sorte com os testes! A API está funcionando perfeitamente!**
