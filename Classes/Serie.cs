using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private string Classificacao {get; set;}
        private int Ano {get; set;}

        private bool Excluido {get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, string classificacao,int ano)
        {
            this.Id = id; // atributo herdado da classe abstrata
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Classificacao = classificacao;
            this.Ano = ano;
            this.Excluido = false; //exclusão logica por padrão false
        }

        public override string ToString()
        {
            //Environment utiliza a quebra de linha de acordo com o sistema operacional
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Classificação: " + this.Classificacao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        //Métodos utilizados para encapsulamento das variaves da classe, serve para evitar alterações
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}