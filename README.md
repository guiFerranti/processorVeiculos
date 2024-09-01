# Processor.Veiculos.API
Link para a API: https://veiculos-api.up.railway.app/api/veiculos

Link para a página Web onde é possível testar a API: https://veiculos.up.railway.app/

## /api/Veiculos

#### POST
#### Descrição: Criar um veículo

##### Request
```json 
{
  "ano": 0,
  "modelo": "string",
  "marca": "string",
  "imageUrl": "string"
}
```

##### Responses

| Code | Description |
| ---- | ----------- |
| 201 | Created |

```json
{
  "id": 0
}
```

#### GET
#### Descrição: Requisitar todos veículos (paginados)

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| page | query |  | No | integer |
| pageSize | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

```json
{
  "veiculos": [
    {
      "id": 0,
      "createdAt": "2024-09-01T23:45:04.154Z",
      "updatedAt": "2024-09-01T23:45:04.154Z",
      "ano": 0,
      "modelo": "string",
      "marca": "string",
      "imageUrl": "string"
    }
  ],
  "totalCount": 0,
  "pageNumber": 0,
  "pageSize": 0
}
```

## /api/Veiculos/{id}

#### GET
#### Descrição: Requisitar um veículo específico

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | long |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
| 404 | Not Found |

```json
{
  "id": 0,
  "createdAt": "2024-09-01T23:46:25.386Z",
  "updatedAt": "2024-09-01T23:46:25.386Z",
  "ano": 0,
  "modelo": "string",
  "marca": "string",
  "imageUrl": "string"
}
```

#### PUT
#### Descrição: Atualizar um veículo específico

##### Request
```json 
{
  "ano": 0,
  "modelo": "string",
  "marca": "string",
  "imageUrl": "string"
}
```

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | long |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 | No Content |
| 404 | Not Found |

#### DELETE
#### Descrição: Deletar um veículo específico

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | long |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 | No Content |
| 404 | Not Found |
