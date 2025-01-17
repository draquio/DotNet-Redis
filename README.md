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

![](https://i.ibb.co/h2k6SVT/NoCache.png)
![](https://i.ibb.co/C82VxFy/With-Cache.png)


**Listar productos por ID.**
- Sin cache: 2120 ms
- Con cache: 8.4 ms

![](https://i.ibb.co/wCL8Hqs/Single-Product-No-Cache.png)
![](https://i.ibb.co/DWb0FZW/Single-Product-With-Cache.png)


**Buscar productos por Texto.**
- Sin cache: 792 ms
- Con cache: 9.92 ms

![](https://i.ibb.co/PMNZpSg/Search-Product-No-Cache.png)
![](https://i.ibb.co/Yc6Mcgs/Search-Product-With-Cache.png)