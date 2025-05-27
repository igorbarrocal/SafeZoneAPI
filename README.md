# SafeZone API 🚨

API RESTful desenvolvida em **ASP.NET Core 8**, utilizando **Entity Framework Core** com banco de dados **Oracle**.  
A SafeZone API permite o cadastro e gerenciamento de **regiões monitoradas** e **sensores** voltados à segurança de motociclistas.

Conta com documentação interativa via **Swagger** para facilitar testes e integração com front-ends ou sistemas parceiros.

---

## 📌 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- Oracle Database
- EF Core Migrations (scripts gerados manualmente)
- Swagger (OpenAPI)
- C#

---

## ⚙️ Funcionalidades da API

✅ Cadastro de regiões monitoradas  
✅ Consulta de todas as regiões  
✅ Consulta de região por ID  
✅ Atualização de regiões  
✅ Exclusão de regiões  

✅ Cadastro de sensores  
✅ Consulta de todos os sensores  
✅ Consulta de sensor por ID  
✅ Atualização de sensores  
✅ Exclusão de sensores  

---

## 🔗 Rotas da API

### 🔸 Região

| Método | Rota             | Descrição                       |
|--------|------------------|---------------------------------|
| GET    | `/api/Regiao`    | Lista todas as regiões         |
| GET    | `/api/Regiao/{id}` | Retorna uma região por ID    |
| POST   | `/api/Regiao`    | Cadastra uma nova região       |
| PUT    | `/api/Regiao/{id}` | Atualiza uma região existente |
| DELETE | `/api/Regiao/{id}` | Exclui uma região             |

### 🔸 Sensor

| Método | Rota             | Descrição                        |
|--------|------------------|----------------------------------|
| GET    | `/api/Sensor`    | Lista todos os sensores          |
| GET    | `/api/Sensor/{id}` | Retorna um sensor por ID       |
| POST   | `/api/Sensor`    | Cadastra um novo sensor          |
| PUT    | `/api/Sensor/{id}` | Atualiza um sensor existente   |
| DELETE | `/api/Sensor/{id}` | Exclui um sensor               |

---

## 🛠️ Instalação e Execução

1. Clone o repositório:
```bash
git clone https://github.com/igorbarrocal/SafeZoneAPI.git
cd SafeZoneAPI
