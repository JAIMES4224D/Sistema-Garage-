<div align="center">
   
#  🚗 SISTEMA GARAGE
###  Sistema Integral de Gestión para Garajes y Estacionamientos

</div>

<div align="center">

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![License MIT](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)
[![Status](https://img.shields.io/badge/Estado-Activo-brightgreen?style=for-the-badge)]()

</div>

---

## 📌 Descripción

**SistemaGarage** es una solución de escritorio desarrollada en **C# con Windows Forms**, diseñada para optimizar y automatizar la gestión completa de operaciones en garajes y estacionamientos.

> 🎯 **Objetivo:** Proporcionar una herramienta robusta que permita a pequeños y medianos negocios digitalizar sus procesos de cobro, control de vehículos y generación de reportes financieros.

---

## ✨ Características

| | Característica | Descripción |
|:---:|---|---|
| 📝 | **Registro Automático** | Captura de placa y hora de entrada con timestamp |
| 🚪 | **Control de Salida** | Cálculo automático de permanencia y tarifa |
| ⏱️ | **Tiempo Real** | Visualización instantánea de vehículos activos |
| 💾 | **Base de Datos** | Historial completo integrado con SQL Server |
| 💰 | **Reportes Financieros** | Resumen de ingresos por jornada y período |
| 📊 | **Exportación Excel** | Generación de reportes en formato `.xlsx` |
| 🎨 | **Interfaz Intuitiva** | Diseño limpio y fácil de usar |

---

## 🏗️ Arquitectura del Proyecto
```
SistemaGarage/
├── 📁 Forms/
│   ├── Form1.cs              # Interfaz principal
│   ├── Form1.Designer.cs     # Diseño de controles
│   └── Form1.resx            # Recursos visuales
├── 📁 Models/
│   └── Vehiculo.cs           # Modelo de datos
├── 📁 Database/
│   └── Conexion.cs           # Gestión de BD
├── 📄 Program.cs             # Punto de entrada
└── 📁 Properties/            # Configuración del proyecto
```

---

## 🛠️ Stack Tecnológico

| Componente | Tecnología |
|---|---|
| 💻 Lenguaje | C# (.NET Framework 4.5+) |
| 🖼️ Interfaz | Windows Forms |
| 🗄️ Base de Datos | SQL Server 2019+ |
| 🔌 ORM | ADO.NET |
| 🧰 IDE | Visual Studio 2015+ |
| 📈 Reportes | Excel Interop |

---

## ⚙️ Requisitos del Sistema

| Requisito | Mínimo |
|---|---|
| 🖥️ Sistema Operativo | Windows 7 o superior |
| 🧠 Memoria RAM | 2 GB |
| ⚡ .NET Framework | 4.5 o superior |
| 🗄️ SQL Server | 2012 o posterior |
| 🧰 IDE | Visual Studio 2015+ |

---

## 📥 Instalación

**1. Clonar el repositorio**
```bash
git clone https://github.com/JAIMES4224D/Sistema-Garage-.git
cd Sistema-Garage-
```

**2. Abrir la solución en Visual Studio**
```
Archivo → Abrir → Proyecto o Solución → seleccionar archivo .sln
```

**3. Configurar la cadena de conexión**

Editar `App.config` con los datos de tu servidor SQL:
```xml
<connectionStrings>
  <add name="GarageDB"
       connectionString="Server=TU_SERVIDOR;Database=SistemaGarage;Integrated Security=True;"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

**4. Compilar la solución**
```
Compilación → Compilar Solución   (Ctrl + Shift + B)
```

**5. Ejecutar la aplicación**
```
Presionar F5  →  modo depuración
Presionar Ctrl + F5  →  sin depuración
```

---

## 🚀 Guía de Uso

### Panel Principal
```
┌──────────────────────────────────────────┐
│          🚗  SISTEMA GARAGE              │
├──────────────────────────────────────────┤
│                                          │
│  📝  INGRESO DE VEHÍCULO                │
│  ┌────────────────────────────────────┐  │
│  │  Placa: [ ___________________ ]   │  │
│  │         [  REGISTRAR ENTRADA  ]   │  │
│  └────────────────────────────────────┘  │
│                                          │
│  🚪  SALIDA DE VEHÍCULO                 │
│  ┌────────────────────────────────────┐  │
│  │  Seleccionar: [ ▼ ABC-123       ] │  │
│  │              [  REGISTRAR SALIDA ] │  │
│  └────────────────────────────────────┘  │
│                                          │
│  📊  REGISTROS ACTIVOS                  │
│  ┌────────────────────────────────────┐  │
│  │ ID │ Placa  │ Entrada │ Salida │ $ │  │
│  │  1 │ ABC123 │  09:30  │ 11:45  │2.50│ │
│  │  2 │ XYZ789 │  10:15  │   —    │ — │  │
│  └────────────────────────────────────┘  │
│                                          │
│  💰  TOTAL RECAUDADO HOY:  $  2.50      │
│                                          │
│      [ 📊 Exportar Excel ]  [ 🗑️ Limpiar ]│
└──────────────────────────────────────────┘
```

### Flujo de Trabajo
```
  🚗 Vehículo llega
        │
        ▼
  📝 Ingresar placa  ──→  💾 Se guarda en BD con timestamp
        │
        ▼
  ⏱️  Vehículo en tabla de activos
        │
        ▼
  🚪 Registrar salida  ──→  💰 Cálculo automático de tarifa
        │
        ▼
  📊 Exportar reporte Excel (opcional)
```

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Si deseas mejorar el proyecto:

1. Haz un **fork** del repositorio
2. Crea una rama para tu feature: `git checkout -b feature/nueva-funcionalidad`
3. Realiza tus cambios y haz commit: `git commit -m "feat: descripción del cambio"`
4. Sube los cambios: `git push origin feature/nueva-funcionalidad`
5. Abre un **Pull Request**

---

## 📄 Licencia

Este proyecto está bajo la licencia **MIT**. Consulta el archivo [LICENSE](LICENSE) para más detalles.

---

<div align="center">

Desarrollado con ❤️ por **JAIMES4224D**

⭐ Si este proyecto te fue útil, considera darle una estrella en GitHub ⭐

</div>
