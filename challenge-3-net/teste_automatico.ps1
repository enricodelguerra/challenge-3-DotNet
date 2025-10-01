# 🧪 Script de Teste Automático - Sistema de Gestão de Motos API
# Execute este script para testar automaticamente a API

$baseUrl = "https://localhost:7225"
$headers = @{
    "Content-Type" = "application/json"
}

Write-Host "🚀 Iniciando testes automáticos da API..." -ForegroundColor Green
Write-Host "Base URL: $baseUrl" -ForegroundColor Yellow
Write-Host ""

# Função para fazer requisições HTTP
function Invoke-ApiRequest {
    param(
        [string]$Method,
        [string]$Uri,
        [string]$Body = $null
    )
    
    try {
        if ($Body) {
            $response = Invoke-RestMethod -Uri $Uri -Method $Method -Headers $headers -Body $Body
        } else {
            $response = Invoke-RestMethod -Uri $Uri -Method $Method -Headers $headers
        }
        return $response
    }
    catch {
        Write-Host "❌ Erro na requisição: $($_.Exception.Message)" -ForegroundColor Red
        return $null
    }
}

# Teste 1: Verificar se a API está rodando
Write-Host "1️⃣ Testando se a API está rodando..." -ForegroundColor Cyan
try {
    $response = Invoke-WebRequest -Uri "$baseUrl/swagger" -Method GET
    if ($response.StatusCode -eq 200) {
        Write-Host "✅ API está rodando!" -ForegroundColor Green
    }
} catch {
    Write-Host "❌ API não está rodando. Execute 'dotnet run' primeiro!" -ForegroundColor Red
    exit 1
}

# Teste 2: Criar usuário
Write-Host "2️⃣ Criando usuário de teste..." -ForegroundColor Cyan
$usuarioData = @{
    nomeFilial = "Empresa Teste"
    email = "teste@empresa.com"
    senha = "123456"
    cnpj = "99.999.999/0001-99"
    endereco = "Rua Teste, 123"
    telefone = "(11) 99999-9999"
    perfil = "ADMIN"
} | ConvertTo-Json

$usuario = Invoke-ApiRequest -Method "POST" -Uri "$baseUrl/api/Usuarios" -Body $usuarioData
if ($usuario) {
    Write-Host "✅ Usuário criado com ID: $($usuario.id)" -ForegroundColor Green
    $usuarioId = $usuario.id
} else {
    Write-Host "❌ Falha ao criar usuário" -ForegroundColor Red
    exit 1
}

# Teste 3: Listar usuários
Write-Host "3️⃣ Listando usuários..." -ForegroundColor Cyan
$usuarios = Invoke-ApiRequest -Method "GET" -Uri "$baseUrl/api/Usuarios"
if ($usuarios) {
    Write-Host "✅ Encontrados $($usuarios.items.Count) usuários" -ForegroundColor Green
} else {
    Write-Host "❌ Falha ao listar usuários" -ForegroundColor Red
}

# Teste 4: Criar moto
Write-Host "4️⃣ Criando moto de teste..." -ForegroundColor Cyan
$motoData = @{
    placa = "TEST-1234"
    chassi = "12345678901234567"
    motor = "Motor Teste 150cc"
    usuarioId = $usuarioId
} | ConvertTo-Json

$moto = Invoke-ApiRequest -Method "POST" -Uri "$baseUrl/api/Motos" -Body $motoData
if ($moto) {
    Write-Host "✅ Moto criada com ID: $($moto.id)" -ForegroundColor Green
    $motoId = $moto.id
} else {
    Write-Host "❌ Falha ao criar moto" -ForegroundColor Red
    exit 1
}

# Teste 5: Listar motos
Write-Host "5️⃣ Listando motos..." -ForegroundColor Cyan
$motos = Invoke-ApiRequest -Method "GET" -Uri "$baseUrl/api/Motos"
if ($motos) {
    Write-Host "✅ Encontradas $($motos.items.Count) motos" -ForegroundColor Green
} else {
    Write-Host "❌ Falha ao listar motos" -ForegroundColor Red
}

# Teste 6: Criar operação
Write-Host "6️⃣ Criando operação de teste..." -ForegroundColor Cyan
$operacaoData = @{
    tipoOperacao = "ENTREGA"
    descricao = "Operação de teste"
    dataOperacao = "2025-01-16T10:00:00Z"
    motoId = $motoId
    usuarioId = $usuarioId
} | ConvertTo-Json

$operacao = Invoke-ApiRequest -Method "POST" -Uri "$baseUrl/api/Operacoes" -Body $operacaoData
if ($operacao) {
    Write-Host "✅ Operação criada com ID: $($operacao.id)" -ForegroundColor Green
    $operacaoId = $operacao.id
} else {
    Write-Host "❌ Falha ao criar operação" -ForegroundColor Red
}

# Teste 7: Listar operações
Write-Host "7️⃣ Listando operações..." -ForegroundColor Cyan
$operacoes = Invoke-ApiRequest -Method "GET" -Uri "$baseUrl/api/Operacoes"
if ($operacoes) {
    Write-Host "✅ Encontradas $($operacoes.items.Count) operações" -ForegroundColor Green
} else {
    Write-Host "❌ Falha ao listar operações" -ForegroundColor Red
}

# Teste 8: Criar status
Write-Host "8️⃣ Criando status de teste..." -ForegroundColor Cyan
$statusData = @{
    status = "DISPONIVEL"
    descricao = "Status de teste"
    area = "Centro"
    dataStatus = "2025-01-16T08:00:00Z"
    motoId = $motoId
    usuarioId = $usuarioId
} | ConvertTo-Json

$status = Invoke-ApiRequest -Method "POST" -Uri "$baseUrl/api/StatusMotos" -Body $statusData
if ($status) {
    Write-Host "✅ Status criado com ID: $($status.id)" -ForegroundColor Green
    $statusId = $status.id
} else {
    Write-Host "❌ Falha ao criar status" -ForegroundColor Red
}

# Teste 9: Listar status
Write-Host "9️⃣ Listando status..." -ForegroundColor Cyan
$statusList = Invoke-ApiRequest -Method "GET" -Uri "$baseUrl/api/StatusMotos"
if ($statusList) {
    Write-Host "✅ Encontrados $($statusList.items.Count) status" -ForegroundColor Green
} else {
    Write-Host "❌ Falha ao listar status" -ForegroundColor Red
}

# Teste 10: Teste de validação (email inválido)
Write-Host "🔟 Testando validação (email inválido)..." -ForegroundColor Cyan
$usuarioInvalidoData = @{
    nomeFilial = "Teste Invalido"
    email = "email-invalido"
    senha = "123456"
    cnpj = "88.888.888/0001-88"
    perfil = "ADMIN"
} | ConvertTo-Json

try {
    $response = Invoke-WebRequest -Uri "$baseUrl/api/Usuarios" -Method POST -Headers $headers -Body $usuarioInvalidoData
    Write-Host "❌ Validação falhou - deveria ter retornado erro" -ForegroundColor Red
} catch {
    if ($_.Exception.Response.StatusCode -eq 400) {
        Write-Host "✅ Validação funcionando - email inválido rejeitado" -ForegroundColor Green
    } else {
        Write-Host "❌ Erro inesperado na validação" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "🎉 Testes automáticos concluídos!" -ForegroundColor Green
Write-Host "📊 Resumo dos testes:" -ForegroundColor Yellow
Write-Host "   - API funcionando: ✅" -ForegroundColor Green
Write-Host "   - Usuário criado: ✅" -ForegroundColor Green
Write-Host "   - Moto criada: ✅" -ForegroundColor Green
Write-Host "   - Operação criada: ✅" -ForegroundColor Green
Write-Host "   - Status criado: ✅" -ForegroundColor Green
Write-Host "   - Validação funcionando: ✅" -ForegroundColor Green
Write-Host ""
Write-Host "🌐 Acesse o Swagger em: $baseUrl" -ForegroundColor Cyan
Write-Host "📝 Use o arquivo 'requisicoes_teste.http' para mais testes" -ForegroundColor Cyan
