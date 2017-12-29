using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;
using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;
using System.Text;
using System.Globalization;

namespace AeronauticalOccurrences
{
    ///<summary>
    ///classe que le os dados csv, cria um dicionario e gera uma arvore B+ em um arquivo .bin.
    ///</summary>
    class FileHelper
    {
        protected static string pathBtree = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\data\\arvore.bin";

        ///<summary>
        ///Le o arquivo csv, e cria um dicionario que a chave é o código do ies CO_IES,
        ///após gera uma arvore B+ e a salva em disco para usos futuros.
        ///</summary>
        /// <param name="caminho_csv_dados">O caminho do CSV.</param>
        public static void LerCSV(string caminho_csv_dados)                  
        {  
            var dicionario = new Dictionary<int, DadosIES>();
            DadosIES dado_existente;

            using (StreamReader ies_stream = new StreamReader(caminho_csv_dados, Encoding.UTF8, true))
            {
                try
                {
                    CsvReader leitor = new CsvReader(ies_stream);

                    leitor.Configuration.BadDataFound = null;
                    leitor.Configuration.MissingFieldFound = null;
                    leitor.Read();
                    leitor.ReadHeader();

                    var dados = leitor.GetRecords<IES>().ToList();

                    //lidos os registros, itera todos e os adiciona no dicionário,
                    //conforme necessário
                    foreach (IES dado in dados)
                    {
                        if (dicionario.TryGetValue(dado.CO_IES, out dado_existente))
                            dado_existente.ies = dado;
                        else
                            dicionario.Add(dado.CO_IES, new DadosIES(dado.CO_IES, dado));
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());

                }
            }

            //Cria a árvore B+ a ser utilizada no programa com os dados lidos dos arquivos CSV
            CriaArvore(dicionario);
        }


        /// <summary>
        /// Cria a árvore à partir dos dados lidos do CSV
        /// </summary>
        /// <param name="dicionario">Dados lidos do CSV</param>
        /// <returns>Indica se houve erro (false) ou não (true) no processo</returns>
        public static bool CriaArvore(Dictionary<int, DadosIES> dicionario) 
        {
            //Cria o componente responsável por serializar os dados a serem escritos na árvore
            ProtoNetSerializer<DadosIES> serializer = new ProtoNetSerializer<DadosIES>();
            //Prepara as opções da árvore
            var tree_options = new BPlusTree<int, DadosIES>.OptionsV2(PrimitiveSerializer.Int32, serializer);

            tree_options.CalcBTreeOrder(8, 30);
            tree_options.CreateFile = CreatePolicy.IfNeeded;
            tree_options.FileName = pathBtree;

            //Checa se o arquivo já existe
            if (!File.Exists(pathBtree))
            {
                using (var tree = new BPlusTree<int, DadosIES>(tree_options))
                {
                    foreach (KeyValuePair<int, DadosIES> entry in dicionario)
                    {
                        //Percorre o dicionário e adiciona na árvore
                        tree.Add(entry.Key, entry.Value);
             
                    }
                }
            }
            
            else
                return false;

            return true;
        }

        public static List<DadosIES> Search(string valor, string criterio)
        {
            //Cria uma nova lista para retornar
            List<DadosIES> lista = new List<DadosIES>();

            //Cria o componente responsável por desserializar os dados a serem lidos da árvore
            ProtoNetSerializer<DadosIES> serializer = new ProtoNetSerializer<DadosIES>();

            //Prepara as opções da árvore
            var tree_options = new BPlusTree<int, DadosIES>.OptionsV2(PrimitiveSerializer.Int32, serializer);

            tree_options.CalcBTreeOrder(8, 30);
            tree_options.CreateFile = CreatePolicy.IfNeeded;
            tree_options.FileName = pathBtree;

            //Checa se o arquivo já existe
            if (File.Exists(pathBtree))
            {
                using (var tree = new BPlusTree<int, DadosIES>(tree_options))
                {
                    //Varre a árvore buscando o dado
                    foreach (KeyValuePair<int, DadosIES> par in tree)
                    { 
                        switch(criterio)
                        {
                            case "NO_IES":
                                if (par.Value.ies.NO_IES.IndexOf(valor, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    lista.Add(par.Value);
                                } break;
                            case "REGIAOIES":
                                if (par.Value.ies.REGIAOIES.IndexOf(valor, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    lista.Add(par.Value);
                                }
                                break;
                            case "NOMEUFIES":
                                if (par.Value.ies.NOMEUFIES.IndexOf(valor, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    lista.Add(par.Value);
                                }
                                break;
                            case "MUNICIPIOIES":
                                if (par.Value.ies.MUNICIPIOIES.IndexOf(valor, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    lista.Add(par.Value);
                                }
                                break;



                        }
                      
                    }
                }
            }

            //Retorna a lista lida
            return lista;
        }

        /// <summary>
        /// Atualiza a arvore dado a chave que quer mudar e o novo valor
        /// </summary
        /// <param name="new_value">novo valor para atualizar a chave</param>
        /// <returns>Returna true se a chave foi encontrada e atulizada</returns
        public static bool Atualiza(DadosIES new_value)
        {
            
            bool output = false;

            //Cria o componente responsável por desserializar os dados a serem lidos da árvore
            ProtoNetSerializer<DadosIES> serializer = new ProtoNetSerializer<DadosIES>();

            //Prepara as opções da árvore
            var tree_options = new BPlusTree<int, DadosIES>.OptionsV2(PrimitiveSerializer.Int32, serializer);

            tree_options.CalcBTreeOrder(8, 30);
            tree_options.CreateFile = CreatePolicy.IfNeeded;
            tree_options.FileName = pathBtree;

            //Checa se o arquivo já existe
            if (File.Exists(pathBtree))
            {
                using (var tree = new BPlusTree<int, DadosIES>(tree_options))
                {
                    //encontra a chave e atualiza o valor
                    output = tree.TryUpdate(new_value.CO_IES, new_value);
                }
            }
            return output;
        }


        /// <summary>
        /// Adiciona uma chave e seu valor a arvore se ela nao existir ainda.
        /// </summary>
        /// <param name="new_value">novo valor para adicionar na arvore</param>
        /// <returns>Returna true se a chave foi nao existir ainda e for adicionada (eu acho)</returns
        public static bool Adiciona(DadosIES new_value)
        {

            bool output = false;

            //Cria o componente responsável por desserializar os dados a serem lidos da árvore
            ProtoNetSerializer<DadosIES> serializer = new ProtoNetSerializer<DadosIES>();

            //Prepara as opções da árvore
            var tree_options = new BPlusTree<int, DadosIES>.OptionsV2(PrimitiveSerializer.Int32, serializer);

            tree_options.CalcBTreeOrder(8, 30);
            tree_options.CreateFile = CreatePolicy.IfNeeded;
            tree_options.FileName = pathBtree;

            //Checa se o arquivo já existe
            if (File.Exists(pathBtree))
            {
                using (var tree = new BPlusTree<int, DadosIES>(tree_options))
                {
                    //encontra a chave e atualiza o valor
                    output = tree.TryAdd(new_value.CO_IES, new_value);
                }
            }
            return output;
        }

        /// <summary>
        /// remove uma chave e seu valor da arvore se existir.
        /// </summary>
        /// <param name="key">chave para excluir</param>
        /// <returns>Returna true se a chave existir e for excluida (eu acho)</returns
        public static bool Remove(int key )
        {

            bool output = false;

            //Cria o componente responsável por desserializar os dados a serem lidos da árvore
            ProtoNetSerializer<DadosIES> serializer = new ProtoNetSerializer<DadosIES>();

            //Prepara as opções da árvore
            var tree_options = new BPlusTree<int, DadosIES>.OptionsV2(PrimitiveSerializer.Int32, serializer);

            tree_options.CalcBTreeOrder(8, 30);
            tree_options.CreateFile = CreatePolicy.IfNeeded;
            tree_options.FileName = pathBtree;

            //Checa se o arquivo já existe
            if (File.Exists(pathBtree))
            {
                using (var tree = new BPlusTree<int, DadosIES>(tree_options))
                {
                    //encontra a chave e atualiza o valor
                    output = tree.Remove(key);
                }
            }

                return output;
        }
    }//class
}//namespcae
