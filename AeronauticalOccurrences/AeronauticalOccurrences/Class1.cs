using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;


namespace AeronauticalOccurrences
{    
    class Class1
    {
        public static void LerCSV(string caminho_csv_dados)
                                                        
        {   ///<summary>
            ///classe que le os dados csv e cria um dicionario
            ///</summary>
            var dicionario = new Dictionary<int, DadosIES>();
            DadosIES dado_existente;
            
            // leitura do arquivo de dados
            using (var ies_stream = new StreamReader(caminho_csv_dados))
            {
                //tenta abrir o CSV e ler todos os registros de uma vez só
                try
                {
                    
                    var leitor = new CsvReader(ies_stream);
                    
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
                //se há qualquer problema na leitura, mostra caixa de exception
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    
                }
            }

        
        
        } //lerCSV()
    }
}
