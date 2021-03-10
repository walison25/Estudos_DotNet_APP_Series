
using System.Collections.Generic;
namespace proj01Series
{
     public interface IRepositorio<T> //T é um tipo genérico (herda o tipo da classe)
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}