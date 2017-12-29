using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeronauticalOccurrences
{

    /// <summary>
    /// Classe que ordena os DadosIES utilizando o quicksort em uma lista.
    /// Pode ordenar pelo codigo do ies ou pelo nome do ies.
    /// É possivel ordenar em forma crescente ou decrescente
    /// </summary>
    class OrdenaDados
    {
        /// <summary>
        /// Utiliza Quick Sort.
        /// A chave é o código do ies
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosIES> QSRM_CodIes(List<DadosIES> listaDesordenada, bool crescente)
        {
            List<DadosIES> listaOrdenada = new List<DadosIES>();
            listaOrdenada = listaDesordenada;
            RandomizedQuickSortCodIes(listaOrdenada, 0, listaOrdenada.Count - 1, crescente);
            return listaOrdenada;
        }

        /// <summary>
        /// Utiliza Quick Sort.
        /// A chave é o nome do ies
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosIES> QSRM_Nome(List<DadosIES> listaDesordenada, bool crescente)
        {
            List<DadosIES> listaOrdenada = new List<DadosIES>();
            listaOrdenada = listaDesordenada;
            RandomizedQuickSortNome(listaOrdenada, 0, listaOrdenada.Count - 1, crescente);
            return listaOrdenada;
        }

        /// <summary>
        /// Função auxiliar com chamada recursiva, que representa a "visão geral" do procedimento.
        /// É feita uma partição inicial, posteriormente refinada até chegar-se a uma lista ordenada.
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        public static void RandomizedQuickSortCodIes(List<DadosIES> input, int left, int right, bool crescente)
        {
            if (left < right)
            {
                int q = RandomizedPartitionCodIes(input, left, right, crescente);
                RandomizedQuickSortCodIes(input, left, q - 1, crescente);
                RandomizedQuickSortCodIes(input, q + 1, right, crescente);
            }
        }

        /// <summary>
        /// Função auxiliar com chamada recursiva, que representa a "visão geral" do procedimento.
        /// É feita uma partição inicial, posteriormente refinada até chegar-se a uma lista ordenada.
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        public static void RandomizedQuickSortNome(List<DadosIES> input, int left, int right, bool crescente)
        {
            if (left < right)
            {
                int q = RandomizedPartitionNome(input, left, right, crescente);
                RandomizedQuickSortNome(input, left, q - 1, crescente);
                RandomizedQuickSortNome(input, q + 1, right, crescente);
            }
        }

        /// <summary>
        /// Randomiza o pivô para posterior partição da lista.
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna um inteiro a ser utilizado como pivô nas chamadas recursivas.</returns>
        private static int RandomizedPartitionCodIes(List<DadosIES> input, int left, int right, bool crescente)
        {
            Random random = new Random();
            int i = random.Next(left, right);

            DadosIES pivot = input[i];
            input[i] = input[right];
            input[right] = pivot;

            return PartitionCodIes(input, left, right, crescente);
        }

        /// <summary>
        /// Randomiza o pivô para posterior partição da lista.
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna um inteiro a ser utilizado como pivô nas chamadas recursivas.</returns>
        private static int RandomizedPartitionNome(List<DadosIES> input, int left, int right, bool crescente)
        {
            Random random = new Random();
            int i = random.Next(left, right);

            DadosIES pivot = input[i];
            input[i] = input[right];
            input[right] = pivot;

            return PartitionNome(input, left, right, crescente);
        }

        /// <summary>
        /// Efetivamente particiona a lista, para que o algoritmo funcione.
        /// Utiliza como chave o código do ies
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna um inteiro a ser utilizado como pivô nas chamadas recursivas.</returns>
        private static int PartitionCodIes(List<DadosIES> input, int left, int right, bool crescente)
        {
            DadosIES pivot = input[right];
            DadosIES temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (crescente)
                {
                    if (input[j].CO_IES <= pivot.CO_IES)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }
                else
                {
                    if (input[j].CO_IES >= pivot.CO_IES)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }

            }

            input[right] = input[i];
            input[i] = pivot;

            return i;
        }

        /// <summary>
        /// Efetivamente particiona a lista, para que o algoritmo funcione.
        /// Utiliza como chave o nome do ies
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna um inteiro a ser utilizado como pivô nas chamadas recursivas.</returns>
        private static int PartitionNome(List<DadosIES> input, int left, int right, bool crescente)
        {
            DadosIES pivot = input[right];
            DadosIES temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (crescente)
                {
                    if (pivot.ies.NO_IES.CompareTo(input[j].ies.NO_IES) >= 0)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }
                else
                {
                    if (input[j].ies.NO_IES.CompareTo(pivot.ies.NO_IES) >= 0)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }

            }

            input[right] = input[i];
            input[i] = pivot;

            return i;
        }


    }//OrdenaDados
}//namespace
