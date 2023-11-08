using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

namespace IMAC.BackEnd
{
    internal class Updater
    {
        public static void CallUpdate()
        {
            string MainUpdatePath = "@\\\\serverip\\f\\Servidor\\Rodrigo\\Programas\\IMAC";
            string RuntimesUpdatePath = "@\\\\serverip\\f\\Servidor\\Rodrigo\\Programas\\IMAC\\runtimes\\win-x64\\native";
            string MainPath = AppDomain.CurrentDomain.BaseDirectory;
            string RuntimesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runtimes", "win-x64", "native");


            string[] MainFiles = { "IMAC.exe", "IMAC.pdb", "WebView2Loader.dll" };
            string[] RuntimesFiles = { "WebView2Loader.dll" };

            int UpdateFlag = 0; //0 = Null, 1 = No Update, 2 = Parcial Update, 3 = Full Update
            bool MainUpdateFlag = false;
            bool RuntimesUpdateFlag = false;

            if (Directory.Exists(MainUpdatePath) && Directory.Exists(RuntimesUpdatePath))
            {
                foreach (string file in MainFiles)
                {
                    //Faz a validação dos arquivos do programa.
                    if (File.Exists(Path.Combine(MainUpdatePath, file)))
                    {
                        DateTime MainUpdateLast = File.GetLastWriteTime(Path.Combine(MainUpdatePath, file));
                        DateTime MainLast = File.GetLastWriteTime(Path.Combine(MainPath, file));
                        if (MainUpdateLast < MainLast)
                        {
                            MainUpdateFlag = true;
                            //call Program Updater...
                            Process UpdateBat = Process.Start(MainPath + "UpdateBatch.bat");
                            Thread.Sleep(1000);
                            Environment.Exit(1);
                        }

                        else
                        {
                            MainUpdateFlag = false;
                        }
                    }
                    else
                    {
                        MainUpdateFlag = false;
                        MessageBox.Show("Os arquivos não são validos, por favor refaça a instalação. Código: Flag 1", "Atualização", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }

                foreach (string file in RuntimesFiles)
                {
                    if (File.Exists(Path.Combine(RuntimesUpdatePath, file)))
                    {
                        DateTime RUpdateLastEdit = File.GetLastWriteTime(Path.Combine(RuntimesUpdatePath, file));
                        DateTime RuntimesLastEdit = File.GetLastWriteTime(Path.Combine(RuntimesPath, file));
                        if (RUpdateLastEdit < RuntimesLastEdit)
                        {
                            RuntimesUpdateFlag = true;
                            //call Program Updater
                        }

                        else
                        {
                            RuntimesUpdateFlag = false;
                        }
                    }
                    else
                    {
                        RuntimesUpdateFlag = false;
                        MessageBox.Show("Os arquivos não são validos, por favor refaça a instalação. Código: Flag 2", "Atualização", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }

                if (MainUpdateFlag && RuntimesUpdateFlag)
                {
                    // Atualização completa (ambos os componentes foram atualizados)
                    UpdateFlag = 3;
                }
                else if (MainUpdateFlag || RuntimesUpdateFlag)
                {
                    // Atualização parcial (apenas um dos componentes foi atualizado)
                    UpdateFlag = 2;
                }
                else
                {
                    // Nenhuma atualização encontrada
                    UpdateFlag = 1;
                }

                switch (UpdateFlag)
                {
                    case 0:
                        MessageBox.Show("Erro fatal na atualização. Código: Flag 0", "Atualização", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;

                    case 1:
                        MessageBox.Show("Nenhuma atualização foi encontrada.", "Atualização", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;

                    case 2:
                        MessageBox.Show("Atualização básica concluída.", "Atualização", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                    case 3:
                        MessageBox.Show("Atualização completa concluída.", "Atualização", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                    default:
                        MessageBox.Show("Erro desconhecido na atualização. Código: Flag FF", "Atualização", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }

            else
            {
                MessageBox.Show("Não foi possivel localizar as pastas de destino", "Atualização", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}