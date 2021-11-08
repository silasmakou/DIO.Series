using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie> //implementa uma interface repositorio de serie
    {
        private List<Serie> listaSerie = new List<Serie>(); //Variavel list do tipo serie

        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
            //TO DO: Implementar envio de email ou registrar log quando novo intem for atualizado
        }

        public void Exclui(int id)
        {
            //listaSerie.RemoveAt(id); não é recomendavel utilizar porque reclassifica o id da lista
            listaSerie[id].Excluir(); 
            //TO DO: Implementar envio de email ou registrar log quando novo intem for excluido
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
            //TO DO: Implementar envio de email ou registrar log quando novo intem for inserido
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
           return listaSerie[id];
        }
    }
}