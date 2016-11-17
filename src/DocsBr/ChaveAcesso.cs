using DocsBr.Utils;
using System;
using System.Linq;

namespace DocsBr
{
    public class ChaveAcesso
    {
        public const string ChaveAcessoInvalida = "Chave de Acesso inválida.";
        public const string UFInvalida = "UF inválida.";
        public const string AnoInvalido = "Ano inválido.";
        public const string MesInvalido = "Mês inválido.";
        public const string ModeloInvalido = "Modelo inválido.";
        public const string SerieInvalida = "Série inválida.";
        public const string CnpjInvalido = "CNPJ inválido.";
        public const string NumeroInvalido = "Número inválido.";
        public const string FormaEmissaoInvalida = "Forma de Emissão inválida.";
        public const string CodigoNumericoInvalido = "Código Numérico inválido.";
        public const string DigitoVerificadorInvalido = "Dígito Verificador inválido.";

        private int _uf;
        public int UF
        {
            get { return _uf; }
            set
            {
                if (!Utils.UF.Codigos.Contains(value))
                    throw new ArgumentException(UFInvalida);

                _uf = value;
            }
        }

        private string _ano;
        public string Ano
        {
            get { return _ano; }
            set
            {
                if (value.Length == 1 || value.Length == 2)
                {
                    _ano = value.PadLeft(2, '0');
                }
                else if (value.Length == 4)
                {
                    _ano = value.Substring(2);
                }
                else
                    throw new ArgumentException(AnoInvalido);
            }
        }

        private string _mes;
        public string Mes
        {
            get { return _mes; }
            set
            {
                var mes = int.Parse(value);
                if (!new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }.Contains(mes))
                    throw new ArgumentException(MesInvalido);

                _mes = value.PadLeft(2, '0'); ;
            }
        }

        private string _cnpj;
        public string CNPJ
        {
            get { return _cnpj; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(CnpjInvalido);

                CNPJ cnpj = value;
                if (!cnpj.IsValid())
                    throw new ArgumentException(CnpjInvalido);

                _cnpj = cnpj.SemMascara();
            }
        }

        private string _modelo;
        public string Modelo
        {
            get { return _modelo; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(ModeloInvalido);

                if (value.Length > 2)
                    throw new ArgumentException(ModeloInvalido);

                if (new OnlyNumbers(value).ToString() != value)
                    throw new ArgumentException(ModeloInvalido);

                _modelo = value.PadLeft(2, '0');
            }
        }

        private string _serie;
        public string Serie
        {
            get { return _serie; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(SerieInvalida);

                if (value.Length > 3)
                    throw new ArgumentException(SerieInvalida);

                if (new OnlyNumbers(value).ToString() != value)
                    throw new ArgumentException(SerieInvalida);

                _serie = value.PadLeft(3, '0');
            }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(NumeroInvalido);

                if (value.Length > 9)
                    throw new ArgumentException(NumeroInvalido);

                if (new OnlyNumbers(value).ToString() != value)
                    throw new ArgumentException(NumeroInvalido);

                _numero = value.PadLeft(9, '0');
            }
        }

        private string _formaEmissao;
        public string FormaEmissao
        {
            get { return _formaEmissao; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(FormaEmissaoInvalida);

                if (value.Length != 1)
                    throw new ArgumentException(FormaEmissaoInvalida);

                if (new OnlyNumbers(value).ToString() != value)
                    throw new ArgumentException(FormaEmissaoInvalida);

                _formaEmissao = value;
            }
        }

        private string _codigoNumerico;
        public string CodigoNumerico
        {
            get { return _codigoNumerico; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(CodigoNumericoInvalido);

                if (value.Length > 8)
                    throw new ArgumentException(CodigoNumericoInvalido);

                if (new OnlyNumbers(value).ToString() != value)
                    throw new ArgumentException(CodigoNumericoInvalido);

                _codigoNumerico = value.PadLeft(8, '0');
            }
        }

        public string DigitoVerificador
        {
            get
            {
                var numero = String.Concat(UF.ToString(), Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico);

                var dv = new DigitoVerificador(numero)
                                        .ComMultiplicadoresDeAte(2, 9)
                                        .Substituindo("0", 10, 11);

                return dv.CalculaDigito();
            }
        }

        public ChaveAcesso(string chaveAcesso)
        {
            if (chaveAcesso == null)
                throw new ArgumentNullException(ChaveAcessoInvalida);

            UF = int.Parse(chaveAcesso.Substring(0, 2));
            Ano = chaveAcesso.Substring(2, 2);
            Mes = chaveAcesso.Substring(4, 2);
            CNPJ = chaveAcesso.Substring(6, 14);
            Modelo = chaveAcesso.Substring(20, 2);
            Serie = chaveAcesso.Substring(22, 3);
            Numero = chaveAcesso.Substring(25, 9);
            FormaEmissao = chaveAcesso.Substring(34, 1);
            CodigoNumerico = chaveAcesso.Substring(35, 8);

            if (chaveAcesso.Substring(43, 1) != DigitoVerificador)
                throw new ArgumentException(DigitoVerificadorInvalido);
        }

        public ChaveAcesso(string uf, int ano, int mes, string cnpj, string modelo, string serie, string numero, string formaEmissao, string codigoNumerico)
        {
            UF ufAsEnum;
            try
            {
                ufAsEnum = Utils.UF.ToEnum(uf);
            }
            catch
            {
                throw new ArgumentException(UFInvalida);
            }

            Setup((int)ufAsEnum, ano, mes, cnpj, modelo, serie, numero, formaEmissao, codigoNumerico);
            
        }

        public ChaveAcesso(int uf, int ano, int mes, string cnpj, string modelo, string serie, string numero, string formaEmissao, string codigoNumerico)
        {
            Setup(uf, ano, mes, cnpj, modelo, serie, numero, formaEmissao, codigoNumerico);
        }

        private void Setup(int uf, int ano, int mes, string cnpj, string modelo, string serie, string numero, string formaEmissao, string codigoNumerico)
        {
            UF = uf;
            Ano = ano.ToString();
            Mes = mes.ToString();
            CNPJ = cnpj;
            Modelo = modelo;
            Serie = serie;
            Numero = numero;
            FormaEmissao = formaEmissao;
            CodigoNumerico = codigoNumerico;
        }

        public override string ToString()
        {
            return String.Concat(UF.ToString(), Ano, Mes, CNPJ, Modelo, Serie, Numero, FormaEmissao, CodigoNumerico, DigitoVerificador);
        }
    }
}