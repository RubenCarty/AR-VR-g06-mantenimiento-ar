# AR Maintenance Assistant

## Repositorio del Proyecto — PSISP08075 Realidad Virtual y Aumentada
### Universidad Autónoma del Perú | Ingeniería de Sistemas | 2026-1

---

# Descripción del Proyecto

AR Maintenance Assistant es una aplicación de Realidad Aumentada para dispositivos Android desarrollada en Unity, cuyo propósito es asistir al usuario durante el mantenimiento preventivo de computadoras de escritorio.

La aplicación utiliza la PC real como elemento principal de interacción y emplea Realidad Aumentada para mostrar instrucciones paso a paso, paneles holográficos, overlays contextuales, indicadores visuales y modelos 3D de apoyo durante todo el procedimiento de mantenimiento.

Su arquitectura modular permite administrar los procedimientos mediante archivos JSON externos, facilitando la actualización y ampliación de los contenidos sin necesidad de recompilar la aplicación.

| Campo | Detalle |
|-------|---------|
| **Tipo XR** | Realidad Aumentada (AR) |
| **Motor** | Unity 2022.3.62f1 LTS |
| **Lenguaje** | C# |
| **Tecnologías principales** | AR Foundation · ARCore XR Plugin |
| **Plataforma objetivo** | Android |
| **Curso** | PSISP08075 — Realidad Virtual y Aumentada |
| **Semestre** | 2026-1 |

---

# Objetivo

Desarrollar un asistente de mantenimiento preventivo basado en Realidad Aumentada que guíe al usuario mediante recursos visuales interactivos durante cada etapa del procedimiento, mejorando la comprensión, reduciendo errores y ofreciendo una experiencia de aprendizaje moderna y accesible.

---

# Integrantes del Grupo

| Nombre | Código | Rol |
|--------|--------|-----|
| | | Líder del proyecto |
| | | Desarrollo AR |
| | | Desarrollo Unity |
| | | Modelado 3D y UI |
| | | Documentación y pruebas |

---

# Instalación y Uso

## Requisitos

- Unity 2022.3.62f1 LTS
- Android 7.0 o superior (API 24+)
- Dispositivo compatible con ARCore
- AR Foundation
- ARCore XR Plugin

## Clonar el repositorio

```bash
git clone https://github.com/RubenCarty/rva-g06-mantenimiento-ar.git
cd rva-g06-mantenimiento-ar
```

## Abrir en Unity

1. Abrir Unity Hub.
2. Seleccionar **Add**.
3. Elegir la carpeta del proyecto.
4. Abrir con Unity 2022.3.62f1 LTS.
5. Esperar la importación automática de paquetes.
6. Compilar para Android mediante **Build Settings → Android → Build and Run**.

---

# Estado del Proyecto

🚧 En desarrollo

---

# Progreso del Proyecto

| Semanas | Hito | Estado |
|---------|------|--------|
| S01-S02 | Investigación del problema, definición de la propuesta y planificación inicial del proyecto | ✅ Completado |
| S03-S04 | Configuración del entorno de desarrollo, creación del proyecto en Unity y definición de la arquitectura base | ✅ Completado |
| S05-S06 | Desarrollo del primer prototipo funcional: panel principal, modelos 3D de prueba y scripts iniciales en C# | ✅ Completado |
| S07-S08 | Implementación del flujo básico del procedimiento, navegación entre pasos y validación del funcionamiento general del prototipo | ✅ Completado |
| S09-S10 | Refactorización de la arquitectura, implementación del Procedure Manager y sistema de procedimientos basado en archivos JSON | 🚧 En progreso |
| S11-S12 | Desarrollo de la interfaz AR definitiva, overlays contextuales, indicadores visuales y recursos 3D de apoyo | ⏳ Pendiente |
| S13-S14 | Integración completa del procedimiento de mantenimiento, optimización, pruebas funcionales y validación de usabilidad | ⏳ Pendiente |
| S15-S16 | Generación del APK final, documentación técnica, video demostrativo y presentación del proyecto | ⏳ Pendiente |
---

# Estructura del Repositorio

```text
rva-g06-mantenimiento-ar/
├── Assets/
│   ├── Scenes/              ← Escenas del proyecto
│   ├── Scripts/             ← Scripts C#
│   ├── Prefabs/             ← Prefabs reutilizables
│   ├── Models/              ← Modelos 3D
│   ├── Materials/           ← Materiales y shaders
│   ├── UI/                  ← Recursos de interfaz
│   ├── Resources/           ← Recursos cargados dinámicamente
│   └── StreamingAssets/     ← Procedimientos JSON y datos externos
├── docs/
│   ├── arquitectura.md      ← Arquitectura técnica
│   ├── procedimientos.md    ← Diseño del procedimiento de mantenimiento
│   ├── usabilidad.md        ← Resultados de pruebas
│   └── capturas/            ← Capturas y material multimedia
├── Packages/                ← Dependencias del proyecto
├── ProjectSettings/         ← Configuración de Unity
├── .gitignore               ← Exclusiones de Git
└── README.md
```

---

# Arquitectura General

La aplicación sigue una arquitectura modular basada en componentes desacoplados para facilitar el mantenimiento y la escalabilidad del proyecto.

Los procedimientos de mantenimiento serán administrados mediante archivos JSON externos, permitiendo modificar áreas, pasos, advertencias y recursos visuales sin recompilar la aplicación.

Los módulos principales del sistema son:

- Gestión del procedimiento (Procedure Manager)
- Gestión de datos (JSON)
- Sistema de Realidad Aumentada
- Interfaz holográfica
- Overlays contextuales
- Recursos visuales
- Gestión del progreso del usuario

---

# Documentación

La documentación técnica se desarrollará progresivamente durante el proyecto e incluirá:

- Arquitectura del sistema
- Diseño del procedimiento de mantenimiento
- Manual de usuario
- Resultados de pruebas y validación
- Capturas del desarrollo

---

# Video Demo

El enlace al video demostrativo será agregado al finalizar el desarrollo del proyecto.

---

# Licencia

Proyecto académico desarrollado para el curso **PSISP08075 — Realidad Virtual y Aumentada** de la **Universidad Autónoma del Perú**, correspondiente al semestre **2026-1**.