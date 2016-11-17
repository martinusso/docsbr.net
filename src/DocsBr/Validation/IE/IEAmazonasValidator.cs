using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocsBr.Utils;

namespace DocsBr.Validation.IE
{
    /// <summary>
    /// Validação da IE do Amazonas
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_AM.html
    /// Máscara de edição: 
    ///   99.999.999-9
    ///   |             h
    ///   .|            g
    ///   ...|          f
    ///   ....|         e
    ///   .....|        d
    ///   .......|      c
    ///   ........|     b
    ///   .........|    a
    ///   ...........|  digito verificador
    /// Cálculo do dígito verificador:
    ///   Soma = (Hx9)+(Gx8)+(Fx7)+(Ex6)+(Dx5)+(Cx4)+(Bx3)+(Ax2)
    ///   Se Soma menor 11
    ///   Então
    ///     Dígito = 11 - Soma
    ///   Senão
    ///     Quociente = Soma / 11
    ///     Se Resto menor ou = 1
    ///     Então
    ///       Dígito = 0
    ///     Senão
    ///       Dígito = 11 - Resto 
    /// </remarks>
    public class IEAmazonasValidator : IIEValidator
    {
        private string inscEstadual;

        public IEAmazonasValidator(string inscEstadual)
        {
            this.inscEstadual = new OnlyNumbers(inscEstadual).ToString(); 
        }

        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 9;
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                        .Substituindo("0", 0, 1);
            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }
    }
}
