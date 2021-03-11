using System;

namespace proj01Series
{
    class Program
    { 
        static SerieRepositorio repositorio = new SerieRepositorio();
        //intancio um novo objeto de repositorio
		
        static void Main(string[] args)
        {
			
           ObterOpcaoUsuario();

		
        }

		

        private static void ExcluirSerie()
		{//colocar uma confirmação de exclusão 
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}//melhoria: colocar qual série ta excluída e qual não está

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}//sobrescreve as informações daquele ID
        
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
			{//joga todos os elementos da lista navariavel serie
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			int qtdGenero = 0;
			Console.WriteLine("Inserir nova série");
			try{
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{//trás todas as opções de genero
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				qtdGenero = (qtdGenero +1);
				
			}//imprime todas as opções de gênero

				
					Console.WriteLine("Digite o gênero entre as opções acima: ");
					int entradaGenero = int.Parse(Console.ReadLine());

					if (entradaGenero <= qtdGenero)
					{
						Console.WriteLine("Digite o Título da Série: ");
						string entradaTitulo = Console.ReadLine();

						Console.WriteLine("Digite o Ano de Início da Série: ");
						int entradaAno = int.Parse(Console.ReadLine());

						Console.WriteLine("Digite a Descrição da Série: ");
						string entradaDescricao = Console.ReadLine();
				
           	 //Proximo id vai pegar o count (que começa em 1)
				Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

				repositorio.Insere(novaSerie);

			} else
			{				
				Console.WriteLine();
				Console.WriteLine( "O número " + entradaGenero + " não é um gênero conhecido.");
				Console.WriteLine("Por favor, digite apenas uma das opções abaixo:");
				Console.WriteLine();
				InserirSerie();
			}

		}catch(FormatException e){
			Console.WriteLine(" ");
			Console.WriteLine("Você digitou algo inválido. Para data e id, use apenas números. Erro: "+e);
			Console.WriteLine(" ");
			Console.WriteLine("Tente novamente: ");
			Console.WriteLine(" ");
			InserirSerie();
		}

			
		}//insere no repositorio

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
			return MenuEscolhido(opcaoUsuario);
		}

		public static string MenuEscolhido(string opcaoUsuario)
		{

		

			try{

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
		}catch{
			
			Console.WriteLine("Você digitou uma opção inválida.");
			Console.WriteLine("Por favor, escolha apenas uma das opções abaixo:");
			opcaoUsuario = ObterOpcaoUsuario();
			MenuEscolhido(opcaoUsuario);

			}

			finally
			{
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
					
			}
			return opcaoUsuario = ObterOpcaoUsuario();
		}

	
    }
}
