using System.Text.RegularExpressions;
using DocumentCtrl.Domain.Base;
using DocumentCtrl.Domain.Enums;

namespace DocumentCtrl.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number)
    {
        Number = number;
        Type = isCPFCNPJ(number);
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
    
    // validação "isCPFCNPJ" baseada no método disponível no github
    // https://gist.github.com/heliomarpm/0e3704c4637c2a38a3c88d8f702b2fde#file-iscpforcnpj-md
    private static EDocumentType isCPFCNPJ(string cpfcnpj)
    {
        int[] d = new int[14];
        int[] v = new int[2];
        int j, i, soma;
        string Sequencia, SoNumero;

        SoNumero = Regex.Replace(cpfcnpj, "[^0-9]", string.Empty);

        //verificando se todos os numeros são iguais
        if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return EDocumentType.ERRO;

        // se a quantidade de dígitos numérios for igual a 11
        // iremos verificar como CPF
        if (SoNumero.Length == 11)
        {
            for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
            for (i = 0; i <= 1; i++)
            {
                soma = 0;
                for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                v[i] = (soma * 10) % 11;
                if (v[i] == 10) v[i] = 0;
            }

            return (v[0] == d[9] & v[1] == d[10]) ? EDocumentType.CPF : EDocumentType.ERRO;
            
        }
        
        // se a quantidade de dígitos numérios for igual a 14
        // iremos verificar como CNPJ
        if (SoNumero.Length == 14)
        {
            Sequencia = "6543298765432";
            for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
            for (i = 0; i <= 1; i++)
            {
                soma = 0;
                for (j = 0; j <= 11 + i; j++)
                    soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

                v[i] = (soma * 10) % 11;
                if (v[i] == 10) v[i] = 0;
            }

            return (v[0] == d[12] & v[1] == d[13]) ? EDocumentType.CNPJ : EDocumentType.ERRO;
        }
        
        // CPF ou CNPJ inválido se
        // a quantidade de dígitos numérios for diferente de 11 e 14
        return EDocumentType.ERRO;
    }

}

