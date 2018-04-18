using System;
using BoletoNetCore.Util;

namespace BoletoNetCore
{
    public class CodigoBarra
    {
        /// <summary>
        /// Representa??o num?rica do C?digo de Barras, composto por 44 posi??es
        ///    01 a 03 - 3 - Identifica??o  do  Banco
        ///    04 a 04 - 1 - C?digo da Moeda
        ///    05 a 05 ? 1 - D?gito verificador do C?digo de Barras
        ///    06 a 09 - 4 - Fator de vencimento
        ///    10 a 19 - 10 - Valor
        ///    20 a 44 ? 25 - Campo Livre
        /// </summary>
        public string CodigoDeBarras
        {
            get
            {
                string codigoSemDv = string.Format("{0}{1}{2}{3}{4}",
                                                      CodigoBanco,
                                                      Moeda,
                                                      FatorVencimento,
                                                      ValorDocumento,
                                                      CampoLivre);
                return string.Format("{0}{1}{2}",
                                        codigoSemDv.Left(4),
                                        DigitoVerificador,
                                        codigoSemDv.Right(39));
            }
        }

        /// <summary>
        /// A linha digit?vel ? composta por cinco campos:
        ///      1? campo
        ///          composto pelo c?digo de Banco, c?digo da moeda, as cinco primeiras posi??es do campo 
        ///          livre e o d?gito verificador deste campo;
        ///      2? campo
        ///          composto pelas posi??es 6? a 15? do campo livre e o d?gito verificador deste campo;
        ///      3? campo
        ///          composto pelas posi??es 16? a 25? do campo livre e o d?gito verificador deste campo;
        ///      4? campo
        ///          composto pelo d?gito verificador do c?digo de barras, ou seja, a 5? posi??o do c?digo de 
        ///          barras;
        ///      5? campo
        ///          Composto pelo fator de vencimento com 4(quatro) caracteres e o valor do documento com 10(dez) caracteres, sem separadores e sem edi??o.
        /// </summary>
        public string LinhaDigitavel { get; set; } = String.Empty;

        /// <summary>
        /// C?digo do Banco (3 d?gitos)
        /// </summary>
        public string CodigoBanco { get; set; } = String.Empty;

        /// <summary>
        /// C?digo da Moeda (9 = Real)
        /// </summary>
        public int Moeda { get; set; } = 9;

        /// <summary>
        /// Campo Livre - Implementado por cada banco.
        /// </summary>
        public string CampoLivre { get; set; } = String.Empty;

        public long FatorVencimento { get; set; } = 0;

        public string ValorDocumento { get; set; } = String.Empty;

        public string DigitoVerificador
        {
            get
            {
                string codigoSemDv = string.Format("{0}{1}{2}{3}{4}",
                                      CodigoBanco,
                                      Moeda,
                                      FatorVencimento,
                                      ValorDocumento,
                                      CampoLivre);

                // Calcula D?gito Verificador do C?digo de Barras
                int pesoMaximo = 9, soma = 0, peso = 2;
                for (int i = (codigoSemDv.Length - 1); i >= 0; i--)
                {
                    soma = soma + (Convert.ToInt32(codigoSemDv.Substring(i, 1)) * peso);
                    if (peso == pesoMaximo)
                        peso = 2;
                    else
                        peso = peso + 1;
                }
                var resto = (soma % 11);

                if (resto <= 1 || resto > 9)
                    return "1";
                
                return (11 - resto).ToString();

            }
        }
    }
}