# Esto va a crear la imagen del SDK de Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
# Esto va a copiar el archivo csproj e instala/restaura las dependencias (Via gestor de paquetes NUGET)
COPY *.csproj ./
RUN dotnet restore
# Esto copia los archivos del proyecto y crea el lanzamiento (release)
COPY . ./
RUN dotnet publish -c Release -o out
# Si este último comando se ejecuta directamente desde la consola, creará una carpeta con el nombre out y en esta carpeta se alojará la versión de producción
# Genera nuestra imagen
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "MiPrimeraApi.dll" ]