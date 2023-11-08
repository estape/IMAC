@echo off

rem Define os caminhos dos diretórios
set MainUpdatePath=\\serverip\F\Servidor\Rodrigo\Programas\IMAC
set RuntimesUpdatePath=\\serverip\F\Servidor\Rodrigo\Programas\IMAC\runtimes
set MainPath= %~dp0
set RuntimesPath= %MainPath%/RuntimesPath

rem Itera pelos arquivos nos diretórios de atualização
for %%f in (%MainUpdatePath%\*.*) do (

    rem Copia o arquivo de atualização para o diretório de instalação do programa
    copy /y %%f %MainPath%

)

for %%f in (%RuntimesUpdatePath%\*.*) do (

    rem Copia o arquivo de atualização para o diretório de instalação do programa
    copy /y %%f %RuntimesPath%

)

rem Executa o programa para verificar se as atualizações foram aplicadas com sucesso
%MainPath%/IMAC.exe
