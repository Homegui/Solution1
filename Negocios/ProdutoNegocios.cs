using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBanco;
using Objetotransferencia;
using System.Data;

namespace Negocios
{
    public class ProdutoNegocios
    {
        AcessoBanco.AcessoBanco acessoBanco = new AcessoBanco.AcessoBanco();


        public string Inserir(Produto produto)
        {

            try
            {
                string sql = "INSERT INTO PRODUTO VALUES ( ? , ? , ?, ?, ?, ? , ? ,?  )";

                acessoBanco.AdicionarParametros("@nomeProduto", produto.nomeProduto);
                acessoBanco.AdicionarParametros("@descProduto", produto.descProduto);
                acessoBanco.AdicionarParametros("@precProduto", produto.precProduto);
                acessoBanco.AdicionarParametros("@descontoPromocao", produto.descontoPromocao);
                acessoBanco.AdicionarParametros("@idCategoria", produto.idCategoria);
                acessoBanco.AdicionarParametros("@produto.ativoProduto", produto.ativoProduto);
                acessoBanco.AdicionarParametros("@idUsuario", produto.idUsuario);
                acessoBanco.AdicionarParametros("@qtdMinEstoque", produto.qtdMinEstoque);



                acessoBanco.ExecutarManipulacao(CommandType.Text, sql);


                return "Cliente Inserido com sucesso!";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }


        }

        public string Alterar(Produto produto)
        {

            try
            {
                acessoBanco.LimparParametros();

                string sql = "UPDATE PRODUTO SET ( ? , ? , ?, ?, ?, ? , ? , ? , ? , ?  )";

                acessoBanco.AdicionarParametros("@idProduto", produto.idProduto);
                acessoBanco.AdicionarParametros("@nomeProduto", produto.nomeProduto);
                acessoBanco.AdicionarParametros("@descProduto", produto.descProduto);
                acessoBanco.AdicionarParametros("@precProduto", produto.precProduto);
                acessoBanco.AdicionarParametros("@descProduto", produto.descProduto);
                acessoBanco.AdicionarParametros("@idCategoria", produto.idCategoria);
                acessoBanco.AdicionarParametros("@ativoProduto", produto.ativoProduto);
                acessoBanco.AdicionarParametros("@idUsuario", produto.idUsuario);
                acessoBanco.AdicionarParametros("@qtdMinEstoque", produto.qtdMinEstoque);
                acessoBanco.AdicionarParametros("@imagem", produto.imagem);

                acessoBanco.ExecutarManipulacao(CommandType.Text, sql);
                return "Cliente alterado com sucesso!";

            }

            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string Excluir(Produto produto)
        {
            try
            {
                acessoBanco.LimparParametros();

                string sql = "DELETE FROM PRODUTO ( ? )";

                acessoBanco.AdicionarParametros("@idProduto", produto.idProduto);
                acessoBanco.ExecutarManipulacao(CommandType.Text, sql);

                return "Cliente Deletado com sucesso!";

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public ProdutoLista ConsultarProdutoNome(string nome)
        {
            try
            { //Consultar por Nome
                ProdutoLista produtoLista = new ProdutoLista();
                string sql = @"Select 
                               @idProduto
                              ,@nomeProduto
                              ,@descProduto
                              ,@precProduto
                              ,@descontoPromocao
                              ,@idCategoria
                              ,@ativoProduto
                              ,@idUsuario
                              ,@qtdMinEstoque
                              ,@imagem

                        FROM PRODUTO WHERE nomeProduto LIKE '%' + @nomeProduto +'%' ";

                acessoBanco.LimparParametros();
                acessoBanco.AdicionarParametros("@nomeProduto", nome);

                DataTable dataTableProduto =  acessoBanco.ExecutarConsulta(CommandType.Text, sql);

                //Percorrer Tabela
                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    //Cria o produto
                    Produto produto = new Produto();

                    //Pega as informações da linha no banco
                    produto.idProduto = Convert.ToInt32(linha["idProduto"]);
                    produto.nomeProduto =Convert.ToString (linha["nomeProduto"]);
                    produto.descProduto = Convert.ToString(linha["descProduto"]);
                    produto.precProduto = Convert.ToDouble(linha["precProduto"]);
                    produto.descontoPromocao = Convert.ToDouble(linha["descontoPromocao"]);
                    produto.idCategoria = Convert.ToInt32(linha["idCategoria"]);
                    produto.ativoProduto = Convert.ToBoolean(linha["ativoProduto"]);
                    produto.idUsuario = Convert.ToInt32(linha["idUsuario"]);
                    produto.qtdMinEstoque = Convert.ToInt32 (linha["qtdMinEstoque"]);
                    produto.imagem = Convert.ToString(linha["imagem"]);

                    //Adiciona o produto na lista de produto
                    produtoLista.Add(produto);
                    
                }

                return produtoLista;
            }


            catch (Exception exception)
            {
                throw new Exception("Cliente não existe " + exception.Message);
            }
        }

        public ProdutoLista ConsutarProdutoIdProduto(int idProduto)
        {
            try
            {
                ProdutoLista produtoLista = new ProdutoLista();
                string sql = @"Select 
                               @idProduto
                              ,@nomeProduto
                              ,@descProduto
                              ,@precProduto
                              ,@descontoPromocao
                              ,@idCategoria
                              ,@ativoProduto
                              ,@idUsuario
                              ,@qtdMinEstoque
                              ,@imagem

                        FROM PRODUTO WHERE idProduto = @idProduto";


                acessoBanco.LimparParametros();
                acessoBanco.AdicionarParametros("@idProduto", idProduto);

                DataTable dataTableProduto = acessoBanco.ExecutarConsulta(CommandType.Text, sql);

                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    //Cria o produto
                    Produto produto = new Produto();

                    //Pega as informações da linha no banco
                    produto.idProduto = Convert.ToInt32(linha["idProduto"]);
                    produto.nomeProduto = Convert.ToString(linha["nomeProduto"]);
                    produto.descProduto = Convert.ToString(linha["descProduto"]);
                    produto.precProduto = Convert.ToDouble(linha["precProduto"]);
                    produto.descontoPromocao = Convert.ToDouble(linha["descontoPromocao"]);
                    produto.idCategoria = Convert.ToInt32(linha["idCategoria"]);
                    produto.ativoProduto = Convert.ToBoolean(linha["ativoProduto"]);
                    produto.idUsuario = Convert.ToInt32(linha["idUsuario"]);
                    produto.qtdMinEstoque = Convert.ToInt32(linha["qtdMinEstoque"]);
                    produto.imagem = Convert.ToString(linha["imagem"]);

                    //Adiciona o produto na lista de produto
                    produtoLista.Add(produto);

                }


                return produtoLista;
            }

            catch(Exception exception)
            {
                throw new Exception ("Id não existe, digite um ID válido! " + exception.Message);
            }
        }
    }


}
