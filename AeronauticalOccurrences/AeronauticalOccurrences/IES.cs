using ProtoBuf;

namespace AeronauticalOccurrences
{
    /// <summary>
    /// Classe contendo as informações do ies, lidas do arquivo CADASTRO_DAS_IES_2011.csv
    /// O campo chave é codigo_ies
    /// </summary>
    [ProtoContract]
    public class IES
    {
        [ProtoMember(1)]
        public int CO_ANO { get; set; }
       
        [ProtoMember(2)]
        public int CO_IES { get; set; }

        [ProtoMember(3)]
        public string NO_IES { get; set; }

        [ProtoMember(4)]
        public string SG_IES { get; set; }
              
        [ProtoMember(5)]
        public string NU_CNPJ { get; set; }
      
        [ProtoMember(6)]
        public string REGIES { get; set; }
       
        [ProtoMember(7)]
        public string REGIAOIES { get; set; }
       
        [ProtoMember(8)]
        public string COUFIES { get; set; }
     
        [ProtoMember(9)]
        public string NOMEUFIES { get; set; }
      
        [ProtoMember(10)]
        public string SIGLA { get; set; }
       
        [ProtoMember(11)]
        public string MUNICIPIOIES { get; set; }
      
        [ProtoMember(12)]
        public string COMUNICIES { get; set; }
       
        [ProtoMember(13)]
        public string COMUNICIES12 { get; set; }
      
        [ProtoMember(14)]
        public string LOCIES { get; set; }
   
        [ProtoMember(15)]
        public string LOCALIES { get; set; }
   
        [ProtoMember(16)]
        public string ORG { get; set; }
     
        [ProtoMember(17)]
        public string NOMEORG { get; set; }
       
        [ProtoMember(18)]
        public string COREDE { get; set; }
      
        [ProtoMember(19)]
        public string REDE { get; set; }
      
        [ProtoMember(20)]
        public string CO_DEP { get; set; }
       
        [ProtoMember(21)]
        public string DEPADM { get; set; }
       
        [ProtoMember(22)]
        public string DEP5 { get; set; }
      
        [ProtoMember(23)]
        public string DEPADM5 { get; set; }
     
        [ProtoMember(24)]
        public string MANT { get; set; }
        
        [ProtoMember(25)]
        public string MANTENEDORA { get; set; }
      
        [ProtoMember(26)]
        public string NU_CEP { get; set; }
  
        [ProtoMember(27)]
        public string DS_ENDERECO { get; set; }
    
        [ProtoMember(28)]
        public string DS_NUMERO_ENDERECO { get; set; }

        [ProtoMember(29)]
        public string DS_COMPLEMENTO_ENDERECO { get; set; }

        [ProtoMember(30)]
        public string NO_BAIRRO { get; set; }
        
        [ProtoMember(31)]
        public string NU_TELEFONE { get; set; }

        [ProtoMember(32)]
        public string NU_FAX { get; set; }
 
        [ProtoMember(33)]
        public string TX_EMAIL { get; set; }
  
        [ProtoMember(34)]
        public string TX_PAGINA_ELETRONICA { get; set; }

        [ProtoMember(35)]
        public string NO_PROCURADOR_INTITUCIONAL { get; set; }

        [ProtoMember(36)]
        public string NU_CPF_PROCURADOR { get; set; }

        [ProtoMember(37)]
        public string NU_TELEFONE_PROCURADOR { get; set; }

        [ProtoMember(38)]
        public string TX_EMAIL_PROCURADOR { get; set; }
 
        [ProtoMember(39)]
        public string NIES { get; set; }
    }


}