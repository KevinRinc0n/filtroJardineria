# filtroJardineria

# CONSULTAS

- Devuelve un listado con todos los pagos que se realizaron en el año 2008 mediante Paypal. Ordene el resultado de mayor a menor

```
http://localhost:5104/jardinFiltro/Pago/paypal2008
```

![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/16f69ff8-e8a8-4426-aa77-6ed6736fbb01)


- Devuelve un listado con todas las formas de pago que aparecen en la tabla pago. Tenga en cuenta que no deben aparecer formas de pago repetidas

```
http://localhost:5104/jardinFiltro/Pago/formasPago
```

![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/eea0132a-97d1-4042-9266-e001b0713748)


- Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante

```
![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/12313295-2e2e-4b5b-a503-693c5e01c0ca)
```

![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/3d8bf7fb-d2ed-4b3a-8fbe-71e0a4f2f6e0)

Explicacion:


- Devuelve un listado que muestre el nombre de cada empleado, el nombre de su jefe y el nombre del jefe de su jefe

```
http://localhost:5104/jardinFiltro/Empleado/jefeDelJefe
```
![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/e8febf9a-72f2-4425-956c-d93d27ed75d3)

- Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre la descripcion y la imagen del producto

```
http://localhost:5104/jardinFiltro/Producto/sinPedidos
```

![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/b4b83ddd-b6ae-43e0-b2d9-18ab79bbe7b2)

- Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre la descripcion y la imagen del producto

```
http://localhost:5104/jardinFiltro/Producto/sinPedidos
```

![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/b4b83ddd-b6ae-43e0-b2d9-18ab79bbe7b2)

- ¿Cuantos pedidos hay en cada estado? Ordena el resultado de forma descendente por el numero de pedidos

```

```

- Devuelve un listado que muestre solamente los clientes que no han realizado ningun pago

```
http://localhost:5104/jardinFiltro/Cliente/sinPagos
```

![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/aba0a314-4fe1-4922-88a2-e3e7391ac3ca)

- Devuelve un listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde esta su oficina

```
http://localhost:5104/jardinFiltro/Cliente/clientess
```
![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/fdeff69f-ecf8-4b4a-98d2-cc9993b21146)

- Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el numero de telefono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningun pago

```
http://localhost:5104/jardinFiltro/Cliente/sinPagos2
```

![image](https://github.com/KevinRinc0n/filtroJardineria/assets/133520088/3aa42d53-c179-455d-bc46-7c4ee78cef24)
