# Backend + Redis
Proyecto backend realizado con la finalidad de usar y practicar la memoria cache de Redis para optimizar peticiones.

## Tecnologías
- .NET Core 8
- Redis
- Api pública "dummyjson"
- Docker Compose (Para levantar Redis)

## Endpoints
**Listar todos los productos.**
- Sin cache: 2970 ms
- Con cache: 10.9 ms

<div style="display: flex; gap:10px; margin-bottom:30px">
  <img src="https://i.ibb.co/h2k6SVT/NoCache.png" alt="Listar productos sin cache" width="350"/>
  <img src="https://i.ibb.co/C82VxFy/With-Cache.png" alt="Listar productos con cache" width="350"/>
</div>

**Listar productos por ID.**
- Sin cache: 2120 ms
- Con cache: 8.4 ms

<div style="display: flex; gap:10px; margin-bottom:30px">
  <img src="https://i.ibb.co/wCL8Hqs/Single-Product-No-Cache.png" alt="Lista producto por ID sin cache" width="350"/>
  <img src="https://i.ibb.co/DWb0FZW/Single-Product-With-Cache.png" alt="Listar producto por ID con cache" width="350"/>
</div>

**Buscar productos por Texto.**
- Sin cache: 792 ms
- Con cache: 9.92 ms

<div style="display: flex; gap:10px">
  <img src="https://i.ibb.co/PMNZpSg/Search-Product-No-Cache.png" alt="Buscar productos por texto sin cache" width="350"/>
  <img src="https://i.ibb.co/Yc6Mcgs/Search-Product-With-Cache.png" alt="Buscar productos por texto con cache" width="350"/>
</div>