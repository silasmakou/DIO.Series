using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
		
        static void Main(string[] args)
        {
			
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
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
					case "C":
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

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			
			//Implementação by Silas: Inserido confirmação de exclusão
			Console.WriteLine($"Confirma a Exclusão da série com o id {indiceSerie}? \r\n 1 - SIM ou 0 - NÃO");
			int confirmaExclusao = int.Parse(Console.ReadLine());
			if(confirmaExclusao == 1)
			{
				repositorio.Exclui(indiceSerie);
				Console.WriteLine("A exclusão foi realizada com sucesso");
			}	
			else
			{
				Console.WriteLine("A exclusão não foi realizada");
			}
			
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			int entradaGenero;
			string entradaTitulo;
			int entradaAno;
			string entradaClassificacao;
			string entradaDescricao;

			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			//Implementação by Silas: Reutilizando o metodo ObterDadosSerieusuario
			var valoresSerieUsuario = obterDadosSerieUsuario();
			entradaGenero = valoresSerieUsuario.entradaGenero;
			entradaTitulo = valoresSerieUsuario.entradaTitulo;
			entradaAno = valoresSerieUsuario.entradaAno;
			entradaClassificacao = valoresSerieUsuario.entradaClassificacao;
			entradaDescricao = valoresSerieUsuario.entradaDescricao;

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
                                        classificacao: entradaClassificacao,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                //utilizando uma expressão ternaria para caso a variavel excluido estiver com o metodo retornaExcluido igual a true então escreve o que está do lado esquerdo dos dois pontos senão coloca o que esta do lado direito
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			int entradaGenero;
			string entradaTitulo;
			int entradaAno;
			string entradaClassificacao;
			string entradaDescricao;

			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero))) //retorna a listagem de todos os generos
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i)); //retorna o genero com o valor i
			}
			
			//Implementação by Silas: Reutilizando o metodo ObterDadosSerieusuario
			
			var valoresSerieUsuario = obterDadosSerieUsuario();
			entradaGenero = valoresSerieUsuario.entradaGenero;
			entradaTitulo = valoresSerieUsuario.entradaTitulo;
			entradaAno = valoresSerieUsuario.entradaAno;
			entradaClassificacao = valoresSerieUsuario.entradaClassificacao;
			entradaDescricao = valoresSerieUsuario.entradaDescricao;



			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
                                        classificacao: entradaClassificacao,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

		//Implementação by Silas: Criando método ObterDadosSerieusuario com Tuplas
		private static (int entradaGenero, string entradaTitulo, int entradaAno, string entradaClassificacao, string entradaDescricao) obterDadosSerieUsuario()
		{
			Console.Write("Digite o gênero entre as opções acima: ");
			var entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			var entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			var entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Classificação da Série: ");
			var entradaClassificacao = Console.ReadLine();

			Console.Write("Digite a Descrição da Série: ");
			var entradaDescricao = Console.ReadLine();
			
			return (entradaGenero, entradaTitulo, entradaAno, entradaClassificacao, entradaDescricao);

		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
