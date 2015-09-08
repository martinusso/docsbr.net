using DocsBr.Validation.IE;

namespace DocsBr.Validation
{
    public class IEValidator
    {
        private static string isento = "ISENTO";
        private string ie;
        private UF uf;

        public IEValidator(string ie, UF uf)
        {
            this.ie = ie;
            this.uf = uf;
        }

        public IEValidator(string ie, int codigoUF)
        {
            this.ie = ie;
            this.uf = (UF)codigoUF;
        }

        public bool IsValid()
        {
            if (ie == isento) return true;
            return IsValidByUF();
        }

        private bool IsValidByUF()
        {
            IIEValidator ieValidator = null;
            switch (this.uf)
            {
                case UF.AC:
                    ieValidator = new IEAcreValidator(this.ie);
                    break;
                case UF.AL:
                    ieValidator = new IEAlagoasValidator(this.ie);
                    break;
                case UF.AM:
                    ieValidator = new IEAmazonasValidator(this.ie);
                    break;
                case UF.AP:
                    ieValidator = new IEAmapaValidator(this.ie);
                    break;
                case UF.BA:
                    ieValidator = new IEBahiaValidator(this.ie);
                    break;
                case UF.CE:
                    ieValidator = new IECearaValidator(this.ie);
                    break;
                case UF.DF:
                    ieValidator = new IEDistritoFederalValidator(this.ie);
                    break;
                case UF.ES:
                    ieValidator = new IEEspiritoSantoValidator(this.ie);
                    break;
                case UF.GO:
                    ieValidator = new IEGoiasValidator(this.ie);
                    break;
                case UF.MA:
                    ieValidator = new IEMaranhaoValidator(this.ie);
                    break;
                case UF.MG:
                    ieValidator = new IEMinasGeraisValidator(this.ie);
                    break;
                case UF.MS:
                    ieValidator = new IEMatoGrossoDoSulValidator(this.ie);
                    break;
                case UF.MT:
                    ieValidator = new IEMatoGrossoValidator(this.ie);
                    break;
                case UF.PA:
                    ieValidator = new IEParaValidator(this.ie);
                    break;
                case UF.PB:
                    ieValidator = new IEParaibaValidator(this.ie);
                    break;
                case UF.PE:
                    ieValidator = new IEPernambucoValidator(this.ie);
                    break;
                case UF.PI:
                    ieValidator = new IEPiauiValidator(this.ie);
                    break;
                case UF.PR:
                    ieValidator = new IEParanaValidator(this.ie);
                    break;
                case UF.RJ:
                    ieValidator = new IERioDeJaneiroValidator(this.ie);
                    break;
                case UF.RN:
                    ieValidator = new IERioGrandeDoNorteValidator(this.ie);
                    break;
                case UF.RO:
                    ieValidator = new IERondoniaValidator(this.ie);
                    break;
                case UF.RR:
                    ieValidator = new IERoraimaValidator(this.ie);
                    break;
                case UF.RS:
                    ieValidator = new IERioGrandeDoSulValidator(this.ie);
                    break;
                case UF.SC:
                    ieValidator = new IESantaCatarinaValidator(this.ie);
                    break;
                case UF.SE:
                    ieValidator = new IESergipeValidator(this.ie);
                    break;
                case UF.SP:
                    ieValidator = new IESaoPauloValidator(this.ie);
                    break;
                case UF.TO:
                    ieValidator = new IETocantinsValidator(this.ie);
                    break;
            }
            if (ieValidator == null) return false;

            return ieValidator.IsValid();
        }
    }
}