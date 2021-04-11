using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo
{
    class Program
    {
        static void Main(string[] args)
        {
            int robo1PosicaoX = 0;
            int robo1PosicaoY = 0;
            int robo2PosicaoX = 0;
            int robo2PosicaoY = 0;
            int posicaoLimiteX = 0;
            int posicaoLimiteY = 0;
            int robo1OlhandoX = 0;
            int robo1OlhandoY = 0;
            int robo2OlhandoX = 0;
            int robo2OlhandoY = 0;
            bool erroArea = false; //se for diferente de false, significa que houve erros nas definicao da area
            bool erroPosicaoRobo1 = false; //se for diferente de false, significa que houve erros na posicao do robo 1
            bool erroPosicaoRobo2 = false; //se for diferente de false, significa que houve erros na posicao do robo 2
            bool erroInstrucao = false; //se for diferente de false, significa que houve erros nas instrucoes dadas
            char[] vetorInstrucoes1;
            char[] vetorInstrucoes2;
            string dadosArea = "";
            string dadosRobo1 = "";
            string dadosRobo2 = "";
            string direcao1 = "";
            string direcao2 = "";
            string instrucoesRobo1 = "";
            string instrucoesRobo2 = "";
            int contadorPalavrasArea = 0;
            int contadorPalavrasRobo1 = 0;
            int contadorPalavrasRobo2 = 0;
            //int robo2PosicaoX = 0;
            //int robo2PosicaoY = 0;

            //Console.WriteLine("Valores acima de 26 quebram a visualização em formato de matriz 'X/Y')");
            //Console.WriteLine("ExemploLimite: 6 8, o campo X irá de 0->6, o campo Y irá de 0->8\n\n");



            //enquanto não digitar corretamente as coordenadas da area XY
            do
            {
                Console.WriteLine("Digite as coordenadas X e Y do canto superior direito da área(ex:X Y)");
                dadosArea = Console.ReadLine();
                erroArea = verificaArea(dadosArea);
            } while (erroArea==true);
            //define a area XY
            string[] vetorPalavras = dadosArea.Split(' ');
            foreach (var pedaco in vetorPalavras)
            {
                contadorPalavrasArea++;
                if (contadorPalavrasArea == 1)
                {
                    posicaoLimiteX = Convert.ToInt32(pedaco);
                }
                else if (contadorPalavrasArea == 2)
                {
                    posicaoLimiteY = Convert.ToInt32(pedaco);
                }
                else
                {
                    //tecnicamente não deve cair aqui, apenas se "verificaArea" estiver errado
                    Console.WriteLine("Exceção de argumentos");
                    Console.ReadLine();
                    Console.Clear();
                }
            }



            //enquanto não digitar corretamente as coordenadas iniciais do robo 1
            do
            {
                Console.WriteLine("Digite as coordenadas X, Y e a direção do Robo1(N - Norte, L - Leste, S - Sul, O - Oeste)");
                dadosRobo1 = Console.ReadLine();
                erroPosicaoRobo1 = verificaPosicaoInicialRobo(dadosRobo1,posicaoLimiteX,posicaoLimiteY);
            } while (erroPosicaoRobo1 == true);
            //define posicao inicial e direcao do robo1
            string[] vetorPalavrasRobo1 = dadosRobo1.Split(' ');
            foreach (var pedaco in vetorPalavrasRobo1)
            {
                contadorPalavrasRobo1++;
                if (contadorPalavrasRobo1 == 1)
                {
                    robo1PosicaoX = Convert.ToInt32(pedaco);
                }
                else if (contadorPalavrasRobo1 == 2)
                {
                    robo1PosicaoY = Convert.ToInt32(pedaco);
                }
                else if (contadorPalavrasRobo1 == 3)
                {
                    direcao1 = Convert.ToString(pedaco);
                }
                else
                {
                    Console.WriteLine("Excesso de argumentos");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            //enquanto não digitar corretamente as instruções do robo 1
            do
            {
                Console.WriteLine("Digite a instruções do Robo1");
                instrucoesRobo1 = Console.ReadLine();
                vetorInstrucoes1 = instrucoesRobo1.ToCharArray();

                //verifica se tem erros nas instrucoes digitadas
                erroInstrucao = verificaInstrucao(vetorInstrucoes1, direcao1, robo1PosicaoX, robo1PosicaoY, posicaoLimiteX, posicaoLimiteY);
                    
            } while (erroInstrucao == true);
            //para cada (letra) instrucao, faz a magia do robo 1
            foreach (char instrucao in vetorInstrucoes1)
            {
                if ((instrucao.ToString() == "E") || (instrucao.ToString() == "e") || (instrucao.ToString() == "D") || (instrucao.ToString() == "d") || (instrucao.ToString() == "M") || (instrucao.ToString() == "m"))
                {

                    if ((instrucao.ToString() == "E") || (instrucao.ToString() == "e"))
                    {
                        //fazer E
                        switch (direcao1)
                        {
                            case "N": direcao1 = "O"; break;
                            case "O": direcao1 = "S"; break;
                            case "S": direcao1 = "L"; break;
                            case "L": direcao1 = "N"; break;
                            case "n": direcao1 = "o"; break;
                            case "o": direcao1 = "s"; break;
                            case "s": direcao1 = "l"; break;
                            case "l": direcao1 = "n"; break;
                        }
                    }
                    else if ((instrucao.ToString() == "D") || (instrucao.ToString() == "d"))
                    {
                        //fazer D
                        switch (direcao1)
                        {
                            case "N": direcao1 = "L"; break;
                            case "L": direcao1 = "S"; break;
                            case "S": direcao1 = "O"; break;
                            case "O": direcao1 = "N"; break;
                            case "n": direcao1 = "l"; break;
                            case "l": direcao1 = "s"; break;
                            case "s": direcao1 = "o"; break;
                            case "o": direcao1 = "n"; break;
                        }
                    }
                    else if ((instrucao.ToString() == "M") || (instrucao.ToString() == "m"))
                    {
                        //fazer o movimento e atualizar o usuário
                        if ((direcao1 == "N") || (direcao1 == "n"))
                        {
                            robo1PosicaoY++;
                        }
                        else if ((direcao1 == "L") || (direcao1 == "l"))
                        {
                            robo1PosicaoX++;
                        }
                        else if ((direcao1 == "S") || (direcao1 == "s"))
                        {
                            robo1PosicaoY--;
                        }
                        else if ((direcao1 == "O") || (direcao1 == "o"))
                        {
                            robo1PosicaoX--;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Instrução Inválida (aperte enter para voltar ao programa)");
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.Clear();

                robo1OlhandoX = robo1PosicaoX;
                robo1OlhandoY = robo1PosicaoY;
                if ((direcao1 == "N") || (direcao1 == "n"))
                {
                    robo1OlhandoY = robo1PosicaoY + 1;
                }
                else if ((direcao1 == "L") || (direcao1 == "l"))
                {
                    robo1OlhandoX = robo1PosicaoX + 1;//é -1 por causa do formato do FOR a seguir
                }
                else if ((direcao1 == "S") || (direcao1 == "s"))
                {
                    robo1OlhandoY = robo1PosicaoY - 1;
                }
                else if ((direcao1 == "O") || (direcao1 == "o"))
                {
                    robo1OlhandoX = robo1PosicaoX - 1;//é +1 por causa do formato do FOR a seguir
                }
            }



            //enquanto não digitar corretamente as coordenadas iniciais do robo 2
            do
            {
                Console.WriteLine("Digite as coordenadas X, Y e a direção do Robo2(N - Norte, L - Leste, S - Sul, O - Oeste)");
                dadosRobo2 = Console.ReadLine();
                erroPosicaoRobo2 = verificaPosicaoInicialRobo(dadosRobo2, posicaoLimiteX, posicaoLimiteY);
            } while (erroPosicaoRobo2 == true);
            //define posicao inicial e direcao do robo2
            string[] vetorPalavrasRobo2 = dadosRobo2.Split(' ');
            foreach (var pedaco in vetorPalavrasRobo2)
            {
                contadorPalavrasRobo2++;
                if (contadorPalavrasRobo2 == 1)
                {
                    robo2PosicaoX = Convert.ToInt32(pedaco);
                }
                else if (contadorPalavrasRobo2 == 2)
                {
                    robo2PosicaoY = Convert.ToInt32(pedaco);
                }
                else if (contadorPalavrasRobo2 == 3)
                {
                    direcao2 = Convert.ToString(pedaco);
                }
                else
                {
                    Console.WriteLine("Excesso de argumentos");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            //enquanto não digitar corretamente as instruções do robo 2
            do
            {
                Console.WriteLine("Digite a instruções do Robo2");
                instrucoesRobo2 = Console.ReadLine();
                vetorInstrucoes2 = instrucoesRobo2.ToCharArray();

                //verifica se tem erros nas instrucoes digitadas
                erroInstrucao = verificaInstrucao(vetorInstrucoes2, direcao2, robo2PosicaoX, robo2PosicaoY, posicaoLimiteX, posicaoLimiteY);

            } while (erroInstrucao == true);
            //para cada (letra) instrucao, faz a magia do robo 2
            foreach (char instrucao in vetorInstrucoes2)
            {
                if ((instrucao.ToString() == "E") || (instrucao.ToString() == "e") || (instrucao.ToString() == "D") || (instrucao.ToString() == "d") || (instrucao.ToString() == "M") || (instrucao.ToString() == "m"))
                {

                    if ((instrucao.ToString() == "E") || (instrucao.ToString() == "e"))
                    {
                        //fazer E
                        switch (direcao2)
                        {
                            case "N": direcao2 = "O"; break;
                            case "O": direcao2 = "S"; break;
                            case "S": direcao2 = "L"; break;
                            case "L": direcao2 = "N"; break;
                            case "n": direcao2 = "o"; break;
                            case "o": direcao2 = "s"; break;
                            case "s": direcao2 = "l"; break;
                            case "l": direcao2 = "n"; break;
                        }
                    }
                    else if ((instrucao.ToString() == "D") || (instrucao.ToString() == "d"))
                    {
                        //fazer D
                        switch (direcao2)
                        {
                            case "N": direcao2 = "L"; break;
                            case "L": direcao2 = "S"; break;
                            case "S": direcao2 = "O"; break;
                            case "O": direcao2 = "N"; break;
                            case "n": direcao2 = "l"; break;
                            case "l": direcao2 = "s"; break;
                            case "s": direcao2 = "o"; break;
                            case "o": direcao2 = "n"; break;
                        }
                    }
                    else if ((instrucao.ToString() == "M") || (instrucao.ToString() == "m"))
                    {
                        //fazer o movimento e atualizar o usuário
                        if ((direcao2 == "N") || (direcao2 == "n"))
                        {
                            robo2PosicaoY++;
                        }
                        else if ((direcao2 == "L") || (direcao2 == "l"))
                        {
                            robo2PosicaoX++;
                        }
                        else if ((direcao2 == "S") || (direcao2 == "s"))
                        {
                            robo2PosicaoY--;
                        }
                        else if ((direcao2 == "O") || (direcao2 == "o"))
                        {
                            robo2PosicaoX--;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Instrução Inválida (aperte enter para voltar ao programa)");
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.Clear();

                robo2OlhandoX = robo2PosicaoX;
                robo2OlhandoY = robo2PosicaoY;
                if ((direcao2 == "N") || (direcao2 == "n"))
                {
                    robo2OlhandoY = robo2PosicaoY + 1;
                }
                else if ((direcao2 == "L") || (direcao2 == "l"))
                {
                    robo2OlhandoX = robo2PosicaoX + 1;//é -1 por causa do formato do FOR a seguir
                }
                else if ((direcao2 == "S") || (direcao2 == "s"))
                {
                    robo2OlhandoY = robo2PosicaoY - 1;
                }
                else if ((direcao2 == "O") || (direcao2 == "o"))
                {
                    robo2OlhandoX = robo2PosicaoX - 1;//é +1 por causa do formato do FOR a seguir
                }
            }


            //exibe resultados na tela
            int i = 0;
            int j = 0;
            for (j = posicaoLimiteY; j >= 0; j--)
            {
                for (i = 0; i <= posicaoLimiteX; i++)
                {
                    if ((i == robo1PosicaoX) && (i == robo2PosicaoX) && (j == robo1PosicaoY) && (j == robo2PosicaoY))
                    {
                        Console.Write("[OX]");
                    }
                    else if ((i == robo1PosicaoX) && (j == robo1PosicaoY) && (i == robo2PosicaoX) && (j == robo2PosicaoY))
                    {
                        Console.Write("[Ox]");
                    }
                    else if ((i == robo2PosicaoX) && (j == robo2PosicaoY) && (i == robo1OlhandoX) && (j == robo1OlhandoY))
                    {
                        Console.Write("[Xo]");
                    }
                    else if ((i == robo1OlhandoX) && (j == robo1OlhandoY) && (i == robo2OlhandoX) && (j == robo2OlhandoY))
                    {
                        //mostrar aonde está olhando
                        Console.Write("[ox]");
                    }
                    else if ((i == robo1PosicaoX) && (j == robo1PosicaoY))
                    {
                        Console.Write("[O]");
                        Console.Write(" ");
                    }
                    else if ((i == robo2PosicaoX) && (j == robo2PosicaoY))
                    {
                        Console.Write("[X]");
                        Console.Write(" ");
                    }
                    else if ((i == robo1OlhandoX) && (j == robo1OlhandoY))
                    {
                        //mostrar aonde está olhando
                        Console.Write("[o]");
                        Console.Write(" ");
                    }
                    else if ((i == robo2OlhandoX) && (j == robo2OlhandoY))
                    {
                        //mostrar aonde está olhando
                        Console.Write("[x]");
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("[ ]");
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("Legenda:");
            Console.WriteLine("'O' é a posição do robo 1");
            Console.WriteLine("'o' é a para onde o robo 1 está olhando");
            Console.WriteLine("'X' é a posição do robo 2");
            Console.WriteLine("'x' é a para onde o robo 2 está olhando\n");

            Console.WriteLine($"Robo1 Posicao Final: X[{robo1PosicaoX}] Y[{robo1PosicaoY}] Direção:{direcao1.ToUpper()}");
            Console.WriteLine($"Robo2 Posicao Final: X[{robo2PosicaoX}] Y[{robo2PosicaoY}] Direção:{direcao2.ToUpper()}");
            Console.ReadLine();
            Console.Clear();
            

        }

        private static bool verificaArea(string dadosArea)
        {
            bool erroArea = false;
            string[] vetorPalavras = dadosArea.Split(' ');
            int qtdPedaco = 0;
            int pedacoInt = 0;

            try
            {
                foreach (string pedaco in vetorPalavras)
                {
                
                    pedacoInt = Convert.ToInt32(pedaco);
                    if (qtdPedaco < 2)
                    {
                        qtdPedaco++;
                    }
                    else
                    {
                        //Digitou mais que 2 argumentos
                        Console.WriteLine("ErroArea: Digite 2 argumentos");
                        Console.ReadLine();
                        Console.Clear();
                        erroArea = true;
                    }
                }
                if (qtdPedaco < 2)
                {
                    //Digitou menos que 2 argumentos
                    Console.WriteLine("ErroArea: Digite 2 argumentos");
                    Console.ReadLine();
                    Console.Clear();
                    erroArea = true;
                }

            }
            catch //(IOException e)
            {
                Console.WriteLine("ErroArea: Digite apenas numeros");
                Console.ReadLine();
                Console.Clear();
                erroArea = true;
            }
            return erroArea;
        }

        private static bool verificaPosicaoInicialRobo(string dadosArea, int posicaoLimiteX, int posicaoLimiteY)
        {
            bool erroPosicaoInicialRobo = false;
            string[] vetorPalavras = dadosArea.Split(' ');
            int qtdPedaco = 0;

            foreach (string pedaco in vetorPalavras)
            {
                if (qtdPedaco == 2)
                {
                    if ((pedaco.ToString() == "N") || (pedaco.ToString() == "n") || (pedaco.ToString() == "L") || (pedaco.ToString() == "l") || (pedaco.ToString() == "S") || (pedaco.ToString() == "s") || (pedaco.ToString() == "O") || (pedaco.ToString() == "o"))
                    {
                        qtdPedaco++;
                    }
                    else 
                    {
                        Console.WriteLine("ErroPosicaoInicialRobo: Digite um valor valido para a Direção Inicial do Robo");
                        Console.ReadLine();
                        Console.Clear();
                        erroPosicaoInicialRobo = true;
                        break;
                    }
                    
                    qtdPedaco++;
                }
                else if(qtdPedaco == 1)
                {
                    try 
                    {
                        if (Convert.ToInt32(pedaco) <= posicaoLimiteY)
                        qtdPedaco++;
                    }
                    catch 
                    {
                        Console.WriteLine("ErroPosicaoInicialRobo: Digite um valor valido para Y");
                        Console.ReadLine();
                        Console.Clear();
                        erroPosicaoInicialRobo = true;
                        break;
                    }
                }
                else if (qtdPedaco == 0)
                {
                    try
                    {
                        if (Convert.ToInt32(pedaco) <= posicaoLimiteX)
                        qtdPedaco++;
                    }
                    catch 
                    {
                        Console.WriteLine("ErroPosicaoInicialRobo: Digite um valor valido para X");
                        Console.ReadLine();
                        Console.Clear();
                        erroPosicaoInicialRobo = true;
                        break;
                    }
                }
                else
                {                    
                    if ((Convert.ToInt32(pedaco) > posicaoLimiteY) && (qtdPedaco == 1))
                    {
                        Console.WriteLine("ErroPosicaoInicialRobo: Digite um valor valido para Y");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if ((Convert.ToInt32(pedaco) > posicaoLimiteX) && (qtdPedaco == 0))
                    {
                        Console.WriteLine("ErroPosicaoInicialRobo: Digite um valor valido para X");
                        Console.ReadLine();
                        Console.Clear();
                    } //Foi digitado mais do que 3 argumentos
                    else if (qtdPedaco > 3)
                    {
                        Console.WriteLine("ErroPosicaoInicialRobo: Digite 3 argumentos");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    erroPosicaoInicialRobo = true;
                    break;
                }
            }
            if ((qtdPedaco < 3)&&(erroPosicaoInicialRobo == false))
            {
                //Digitou menos que 3 argumentos
                Console.WriteLine("ErroPosicaoInicialRobo: Digite 3 argumentos");
                Console.ReadLine();
                Console.Clear();
                erroPosicaoInicialRobo = true;
            }
            return erroPosicaoInicialRobo;
        }

        private static bool verificaInstrucao(char[] vetorInstrucoes, string direcao, int robo1PosicaoX, int robo1PosicaoY, int posicaoLimiteX, int posicaoLimiteY)
        {
            bool erroInstrucao = false;
            foreach (char instrucao in vetorInstrucoes)
            {
                if ((instrucao.ToString() == "M") || (instrucao.ToString() == "m") || (instrucao.ToString() == "E") || (instrucao.ToString() == "e") || (instrucao.ToString() == "D") || (instrucao.ToString() == "d"))
                {
                    //checar se o robo vai ficar "out of bounds"
                    if ((instrucao.ToString() == "E") || (instrucao.ToString() == "e"))
                    {
                        //fazer E
                        switch (direcao)
                        {
                            case "N": direcao = "O"; break;
                            case "O": direcao = "S"; break;
                            case "S": direcao = "L"; break;
                            case "L": direcao = "N"; break;
                            case "n": direcao = "o"; break;
                            case "o": direcao = "s"; break;
                            case "s": direcao = "l"; break;
                            case "l": direcao = "n"; break;
                        }
                    }
                    else if ((instrucao.ToString() == "D") || (instrucao.ToString() == "d"))
                    {
                        //fazer D
                        switch (direcao)
                        {
                            case "N": direcao = "L"; break;
                            case "L": direcao = "S"; break;
                            case "S": direcao = "O"; break;
                            case "O": direcao = "N"; break;
                            case "n": direcao = "l"; break;
                            case "l": direcao = "s"; break;
                            case "s": direcao = "o"; break;
                            case "o": direcao = "n"; break;
                        }
                    }
                    else if ((instrucao.ToString() == "M") || (instrucao.ToString() == "m"))
                    {
                        if (((robo1PosicaoX == posicaoLimiteX) && ((direcao == "L") || (direcao == "l"))) || ((robo1PosicaoX == 0) && ((direcao == "O") || (direcao == "o"))))
                        {
                            //checar erros de ir para fora do mapa
                            Console.WriteLine("O robo não pode sair da área determinada Exception X");
                            Console.ReadLine();
                            Console.Clear();
                            erroInstrucao = true;
                            break;
                        }
                        else if (((robo1PosicaoY == posicaoLimiteY) && ((direcao == "N") || (direcao == "n"))) || ((robo1PosicaoY == 0) && ((direcao == "S") || (direcao == "s"))))
                        {
                            //checar erros de ir para fora do mapa
                            Console.WriteLine("O robo não pode sair da área determinada Exception Y");
                            Console.ReadLine();
                            Console.Clear();
                            erroInstrucao = true;
                            break;
                        }
                        else //fazer o movimento do robo
                        {
                            if ((direcao == "N") || (direcao == "n"))
                            {
                                robo1PosicaoY++;
                            }
                            else if ((direcao == "L") || (direcao == "l"))
                            {
                                robo1PosicaoX++;
                            }
                            else if ((direcao == "S") || (direcao == "s"))
                            {
                                robo1PosicaoY--;
                            }
                            else if ((direcao == "O") || (direcao == "o"))
                            {
                                robo1PosicaoX--;
                            }
                        }
                    }
                }
                else
                {
                    //checar instrucao
                    Console.WriteLine("Digite Apenas Instruções Válidas(M, E, D)");
                    Console.ReadLine();
                    Console.Clear();
                    erroInstrucao = true;
                    break;
                }
            }
            return erroInstrucao;
        }

        
    }
}
