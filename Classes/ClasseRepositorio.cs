using System;
using System.Collections.Generic;
using proj01Series;

namespace proj01Series
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();
        //lista que contem todas as séries
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}//retorna a quantidade de itens o indice é 0 ele retona + 1

		public Serie RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}