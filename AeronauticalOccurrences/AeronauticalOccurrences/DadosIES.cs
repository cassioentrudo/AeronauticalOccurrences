using System;
using ProtoBuf;

/// <summary>
/// Classe contendo as informações do ies, lidas do arquivo CADASTRO_DAS_IES_2011.csv
/// O campo chave é codigo_ies
/// </summary>
[ProtoContract]
public class DadosUniversidade
{



    /// <summary>
    /// Código ies
    /// </summary>
    /// <value>
    /// valor inteiro
    /// </value>
    [ProtoMember(1)]
    public int codigo_ies { get; set; }

    /// <summary>
    /// Nome do ies
    /// </summary>
    /// <value>
    /// nome do ies por extenso
    /// </value>
    [ProtoMember(2)]
    public string no_ies { get; set; }

    /// <summary>
    /// Sigla do ies
    /// </summary>
    /// <value>
    ///  sigla
    /// </value>
    [ProtoMember(3)]
    public string sg_ies { get; set; }

    /// <summary>
    /// Regiao que esta localizado o ies
    /// </summary>
    /// <value>
    /// nome da regiao
    /// </value>
    [ProtoMember(4)]
    public string regiaoies { get; set; }

    /// <summary>
    /// Código da uf que esta localizado o ies
    /// </summary>
    /// <value>
    /// valor inteiro
    /// </value>
    [ProtoMember(5)]
    public int coufies { get; set; }

    /// <summary>
    /// Nome da uf que esta localizado o ies
    /// </summary>
    /// <value>
    /// nome por extenso da uf
    /// </value>
    [ProtoMember(6)]
    public string nomeufies { get; set; }

    /// <summary>
    /// Sigla da uf que esta localizado o ies
    /// </summary>
    /// <value>
    /// Sigla da uf
    /// </value>
    [ProtoMember(7)]
    public string sigla { get; set; }

    /// <summary>
    /// Nome do municipio que esta localizado o ies
    /// </summary>
    /// <value>
    /// nome por extenso do municipio
    /// </value>
    [ProtoMember(8)]
    public string municipioies { get; set; }

    /// <summary>
    /// localizaçao do ies(capital ou interior)
    /// </summary>
    /// <value>
    /// CAPITAL ou INTERIOR
    /// </value>
    [ProtoMember(9)]
    public string localies { get; set; }

    /// <summary>
    /// Nome da organizaçao academica do ies
    /// </summary>
    /// <value>
    /// nome por extenso da organizaçao
    /// </value>
    [ProtoMember(10)]
    public string nomeorg { get; set; }

    /// <summary>
    /// rede do ies
    /// </summary>
    /// <value>
    /// PUBLICA ou PRIVADA
    /// </value>
    [ProtoMember(11)]
    public string rede { get; set; }

    /// <summary>
    /// Categoria administrativa da ies
    /// </summary>
    /// <value>
    /// nome da categora.(federal, estadual, privada, etc.)
    /// </value>
    [ProtoMember(12)]
    public string depadm { get; set; }

    /// <summary>
    /// Nome da mantenedora do ies
    /// </summary>
    /// <value>
    /// nome por extenso da mantenedora
    /// </value>
    [ProtoMember(13)]
    public string matenedora { get; set; }
    /// <summary>
    /// CEP do ies
    /// </summary>
    /// <value>
    /// numero inteiro
    /// </value>
    [ProtoMember(14)]
    public int nu_cep { get; set; }

    /// <summary>
    /// Endereço do ies
    /// </summary>
    /// <value>
    /// Nome da rua ou avenida etc.
    /// </value>
    [ProtoMember(15)]
    public string ds_endereço { get; set; }

    /// <summary>
    /// Numero do endereço do ies
    /// </summary>
    /// <value>
    /// numero ou kilometragem.
    /// </value>
    [ProtoMember(16)]
    public string ds_numero { get; set; }

    /// <summary>
    /// Complemento do endereço do ies
    /// </summary>
    /// <value>
    /// complemento.
    /// </value>
    [ProtoMember(17)]
    public string ds_complemento { get; set; }

    /// <summary>
    /// Bairro do ies
    /// </summary>
    /// <value>
    /// Nome do bairro
    /// </value>
    [ProtoMember(18)]
    public string no_bairro { get; set; }

    /// <summary>
    /// numero de telefone do ies
    /// </summary>
    /// <value>
    /// numero com o ddd entre ()
    /// </value>
    [ProtoMember(19)]
    public string nu_telefone { get; set; }

    /// <summary>
    /// numero do fax do ies
    /// </summary>
    /// <value>
    /// Nome do fax.
    /// </value>
    [ProtoMember(20)]
    public string nu_fax { get; set; }

    /// <summary>
    /// Email do ies
    /// </summary>
    /// <value>
    /// email
    /// </value>
    [ProtoMember(21)]
    public string tx_email { get; set; }

    /// <summary>
    /// Site do ies
    /// </summary>
    /// <value>
    /// URL do site
    /// </value>
    [ProtoMember(22)]
    public string tx_pagina { get; set; }

    /// <summary>
    /// Nome do Procurador do ies
    /// </summary>
    /// <value>
    /// Nome 
    /// </value>
    [ProtoMember(23)]
    public string no_procurador { get; set; }

    /// <summary>
    /// Numero do cpf do Procurador do ies
    /// </summary>
    /// <value>
    /// valor inteiro
    /// </value>
    [ProtoMember(24)]
    public int nu_cpf_procurador { get; set; }
   
    /// <summary>
    /// Numero do telefone do Procurador do ies
    /// </summary>
    /// <value>
    /// numero de telefone com ddd entre ()
    /// </value>
    [ProtoMember(25)]
    public string nu_telefone_procurador { get; set; }

    /// <summary>
    /// Email do Procurador do ies
    /// </summary>
    /// <value>
    /// email
    /// </value>
    [ProtoMember(26)]
    public string tx_email_procurador { get; set; }

}
