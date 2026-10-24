# Sistema de Gestión de Empleados — Arquitectura en 5 Capas

Aplicación de escritorio desarrollada en **C# y Windows Forms**, utilizando **.NET Framework 4.7.2** y **SQL Server** como motor de base de datos.

El proyecto fue realizado como trabajo práctico académico, con el objetivo de implementar una arquitectura en capas que permita separar las responsabilidades del sistema, facilitar su mantenimiento y organizar el acceso a los datos.

## Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework 4.7.2
- **Interfaz gráfica:** Windows Forms
- **Base de datos:** Microsoft SQL Server
- **Entorno de desarrollo:** Visual Studio
- **Consultas y persistencia:** SQL y procedimientos almacenados
- **Intercambio de información:** XML
- **Control de versiones:** Git y GitHub

## Arquitectura del sistema

El proyecto está organizado en cinco capas:

| Capa | Descripción |
|---|---|
| **BE — Business Entities** | Define las entidades y estructuras de datos utilizadas por el sistema. |
| **BLL — Business Logic Layer** | Contiene la lógica de negocio y coordina las operaciones de la aplicación. |
| **DAL — Data Access Layer** | Gestiona la comunicación con la base de datos. |
| **MPP — Mapper** | Se encarga de las operaciones de persistencia y mapeo de datos. |
| **UI — User Interface** | Implementa la interfaz gráfica mediante Windows Forms. |

Esta separación permite distribuir las responsabilidades del sistema y reducir el acoplamiento entre sus componentes.

## Funcionalidades

El sistema contempla la administración de:

- Empleados.
- Departamentos.
- Sucursales.
- Relaciones entre departamentos y sucursales.
- Usuarios y acceso al sistema.

Además, incorpora operaciones de alta, modificación, eliminación y consulta, junto con una funcionalidad de exportación de información de empleados a XML.

## Estructura del repositorio

```text
TP-final-en-capas/
├── backend/
│   ├── BE/
│   ├── BLL/
│   ├── DAL/
│   └── MPP/
├── frontend/
│   └── TrabajoPracticoAdminEmpleados5Capas/
├── database/
│   └── BaseDatos2_Estructura.sql
├── docs/
│   └── stored-procedures/
├── examples/
│   └── empleados.xml
├── .gitignore
├── README.md
└── TrabajoPracticoAdminEmpleados5Capas.sln
```

## Base de datos

El proyecto utiliza una base de datos SQL Server denominada `BaseDatos2`.

El archivo `database/BaseDatos2_Estructura.sql` contiene el esquema generado desde SQL Server Management Studio (SSMS), incluyendo:

- 5 tablas.
- Claves principales y relaciones.
- 18 procedimientos almacenados.

El script se generó sin los registros de la base de datos.

**Nota:** el script está orientado a SQL Server 2022. Su ejecución en una instalación nueva todavía debe validarse.

## Requisitos

Para trabajar con el proyecto se recomienda contar con:

- Windows.
- Visual Studio con soporte para desarrollo de escritorio .NET.
- .NET Framework 4.7.2 y sus herramientas de desarrollo.
- Microsoft SQL Server compatible con el script.
- SQL Server Management Studio (SSMS), para administrar la base de datos.

## Instalación y ejecución

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/ThyagoASan/TP-final-en-capas.git
   ```

2. Abrir `TrabajoPracticoAdminEmpleados5Capas.sln` en Visual Studio.

3. Crear y configurar la base de datos `BaseDatos2` en SQL Server utilizando el script disponible en `database/`.

4. Revisar la configuración de conexión a SQL Server en el proyecto y adaptarla al entorno local.

5. Restaurar las dependencias necesarias y compilar la solución.

6. Establecer el proyecto `Ui` como proyecto de inicio y ejecutar la aplicación.

**Importante:** la creación de la base de datos desde cero y la configuración de una instalación nueva requieren una validación adicional.

## Exportación XML

La aplicación permite exportar información de empleados a un archivo XML.

En `examples/empleados.xml` se incluye un ejemplo con tres empleados ficticios, destinado a mostrar el formato utilizado.

## Documentación

La carpeta `docs/` contiene documentación académica del proyecto y documentos relacionados con los procedimientos almacenados utilizados.

## Estado del proyecto

Proyecto académico funcional, reorganizado para mejorar la presentación del código y facilitar su exploración.

**Pendiente:** validar la instalación desde cero, documentar completamente la configuración de conexión y agregar capturas de la aplicación.

## Autor

**Thyago Agustín Sánchez**

Estudiante de Ingeniería en Sistemas.

[GitHub](https://github.com/ThyagoASan)