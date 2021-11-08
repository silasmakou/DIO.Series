using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>  //tipo T significa tipo generico
    {
        List<T> Lista(); //retorna uma lista de T
        T RetornaPorId(int id); //passa um id como parametro e retorna um T como parametro
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}