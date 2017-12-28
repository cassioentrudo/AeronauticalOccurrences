using System;
using ProtoBuf;


namespace AeronauticalOccurrences
{
    class DadosIES
    {

        /// <summary>
        /// Código ies
        /// </summary>
        /// <value>
        /// valor inteiro
        /// </value>
        [ProtoMember(1)]
        public int CO_IES { get; set; }


        /// <summary>
        /// Objeto contendo os dados lidos do arquivo CADASTRO_DAS_IES_2011.csv, com o codigo_ies acima
        /// </summary>
        /// <value>
        /// Objeto do tipo IES
        /// </value>
        [ProtoMember(2)]
        public IES ies { get; set; }

        /// <summary>
        /// Construtor que inicializa uma nova instância de DadosIES.
        /// </summary>
        /// <param name="codigo_ies">Código do ies, para identificação.</param>
        /// <param name="ies">Informações sobre o ies.</param> 
        public DadosIES(int codigo_ies, IES ies)
        {
            this.CO_IES = codigo_ies;
            this.ies = ies;
        }

        /// <summary>
        /// Construtor vazio.
        /// </summary>
        public DadosIES()
        {
            this.CO_IES = 0;
            this.ies = null;
        }
    }



}

