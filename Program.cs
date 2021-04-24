﻿using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "x"){

               switch (opcaoUsuario){

                   case "1":
                   ListarSeries();
                   break;

                   case "2":
                   InserirSerie();
                   break;
                   
                   case "3":
                   AtualizarSerie();
                   break;
                   
                   case "4":
                   ExcluirSerie();
                   break;
                   
                   case "5":
                   VisualizarSerie();
                   break;
                   
                   case "c":
                   Console.Clear();
                   break;

                   default:
                   throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
           
           Console.WriteLine("Obrigado por utilizar nossos serviços.");
           Console.ReadLine();

        }
        private static void ListarSeries(){

            Console.WriteLine("Listar séries ");
            var lista = repositorio.Lista();

            if(lista.Count == 0){

                Console.WriteLine("Nenhuma série cadrastrada. ");
                return;
            }

            foreach (var serie in lista){

                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*":""));
            }
        }
        private static void InserirSerie(){
            Console.WriteLine("Inserir nova série ");

            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("#{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie(){

            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))){
               Console.WriteLine("#{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);  
            }

        private static void ExcluirSerie(){
            Console.WriteLine(" Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine(" Tem certeza que deja excluir o id: " + indiceSerie + " ? (Digite 'true' para Sim e 'false' para Não] ");
            Boolean resposta = bool.Parse(Console.ReadLine());

            if (resposta == true){
                repositorio.Excluir(indiceSerie);
                Console.WriteLine(" A série " + indiceSerie + " foi excluida! ");
            }

            else{
                
                Console.WriteLine("Ação cancelada ");
                return;
            }

        }
        private static void VisualizarSerie(){
            Console.WriteLine("Digite o id da sére: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario(){

            Console.WriteLine();
            Console.WriteLine("Dio Séries ao seu dispor! ");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries ");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série ");
            Console.WriteLine("4 - Excluir série ");
            Console.WriteLine("5 - Visualizar série ");
            Console.WriteLine("c - Limpar tela ");
            Console.WriteLine("X - Sair ");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
