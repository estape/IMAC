@echo off

rem Define a cor de fundo para azul
color 1F

rem Cria a pasta IMACtemp na raiz do Disco local C:
mkdir C:\IMACtemp

rem Verifica se a pasta foi criada com sucesso
if exist C:\IMACtemp (
    echo A pasta IMACtemp foi criada com sucesso.
) else (
    echo Falha ao criar a pasta IMACtemp.
)

rem Definir URLs dos instaladores do .NET 6 e do WebView2 Runtime
set DOTNET_INSTALLER_URL=https://download.visualstudio.microsoft.com/download/pr/1146f414-17c7-4184-8b10-1addfa5315e4/39db5573efb029130add485566320d74/windowsdesktop-runtime-6.0.20-win-x64.exe
set WEBVIEW2_INSTALLER_URL=https://go.microsoft.com/fwlink/p/?LinkId=2124703

rem Definir caminhos de destino para os instaladores
set DOTNET_INSTALLER_PATH=C:\IMACtemp\windowsdesktop-runtime-6.0.20-win-x64.exe
set WEBVIEW2_INSTALLER_PATH=C:\IMACtemp\webview2runtime.exe

rem Criar uma barra de progresso vazia
echo [..........] 0%% concluido...

rem Fazer download do instalador do .NET 6
echo Fazendo download do instalador do .NET 6...
bitsadmin /transfer "Baixando .NET 6.0" %DOTNET_INSTALLER_URL% "%DOTNET_INSTALLER_PATH%"

rem Exibir a barra de progresso atualizada
echo [#####.....] 50%% concluido...

rem Verificar se houve erro no download do .NET 6
if %errorlevel% neq 0 (
    echo Error: Ocorreu um erro no download do .NET 6.
    pause
    exit /b
)

rem Executar o instalador do .NET 6
echo Instalando o .NET 6...
"%DOTNET_INSTALLER_PATH%" --quiet

rem Exibir a barra de progresso atualizada
echo [##########] 100%% concluido...

rem Fazer download do instalador do WebView2 Runtime
echo Fazendo download do instalador do WebView2 Runtime...
bitsadmin /transfer "Baixando " %WEBVIEW2_INSTALLER_URL% "%WEBVIEW2_INSTALLER_PATH%"

rem Exibir a barra de progresso atualizada
echo [..........] 0%% concluido...

rem Verificar se houve erro no download do WebView2 Runtime
if %errorlevel% neq 0 (
    echo Error: Ocorreu um erro no download do WebView2 Runtime.
    pause
    exit /b
)

rem Executar o instalador do WebView2 Runtime
echo Instalando o WebView2 Runtime...
"%WEBVIEW2_INSTALLER_PATH%" --quiet

rem Exibir a barra de progresso atualizada
echo [##########] 100%% concluido...

rem Limpar os instaladores após a instalação
del "%DOTNET_INSTALLER_PATH%"
del "%WEBVIEW2_INSTALLER_PATH%"

rem Verifica se a pasta IMACtemp existe
if exist C:\IMACtemp (
    rem Exclui a pasta IMACtemp
    rmdir /s /q C:\IMACtemp
    echo A pasta IMACtemp foi excluida com sucesso.
) else (
    echo A pasta IMACtemp nao existe.
)

echo .NET 6.0 e WebView2 Runtime foram instalados com sucesso!.
pause
