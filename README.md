# Contenedores
Gestión de la descarga de un barco portacontenedores y como se descarga en camiones.
Las características del proyecto son las siguientes:


1.Modelo de Datos:


Contenedor ( Classs Abstract)
•	Int peso

ContenedorNormal (Class) hereda de Contendor
•	Sin atributos

ContenedorSeguridad Class) hereda de Contendor
•	Bool Alarma

ContenedorSeguridad(Class) hereda de Contenedor
•	int Temperatura


Interface “IShow”
•	Implementa el método “MostrarContenedores”.

PilaContendores: (class )
•	Pila pilaContendores
•	String nombre
•	Int pesoPila

ColaCamiones: (class )
•	Cola colaCamiones
•	String nombre


Barco: (class )
•	Array[5] pilasContenedores

Camion: (class )
•	lista de Contendores
•	numMaximo de Contenedores=2

2.Main Class
En la clase principal tendremos
•	Inicialización del modelo
•	Menú 
Inicializa el modelo
Inicializa la estructura de datos de acuerdo con los siguientes datos
Pilas de contenedores en el barco
Indice	Tipo Contenedor	Peso
0	ContenedorNormal	100
0	ContenedorNormal	130
1	ContenedorRefrigerado	200
2	ContenedorRefrigerado	50
2	ContenedorSeguridad	100
2	ContenedorNormal	400
3	ContenedorSeguridad	100
4	ContenedorSeguridad	100

 Camiones en la cola de Camiones
Nombre
Camion 1
Camion 2
Camion 3
Camion 4
Camion 5
Camion 6
        
Conedores en los Camiones
Nombre	Tipo Contenedor	Peso
Camion 5	ContenedorNormal	100
Camion 6	ContenedorRefrigerado	150



Menu loop:
El menú mostrará:

************ BARCO ********************
1. Mostrar Contenedores
2. Mostrar Contenedores Peso
3. Activar Seguridad
4. Activar Temperatura 7 grados
5. Mostrar Contenedores Ordenados Peso Pila
************* CAMIONES *******************
6. Mostrar Cola Camiones
************** OPERACIONES ******************
7. Mostrar Pila de Contenedores Maxima
8. Descargar Contenedores al primer Camión
9. Mostrar Cola Camiones con contenedores
10. Sacar camion de cola
********************************
11. Salir
Seleccione una opción:

