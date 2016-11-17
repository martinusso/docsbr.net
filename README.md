# docsbr.net

Validação e formatação de documentos do Brasil

## Instalação

### NuGet Package

```
Install-Package docsbr
```

## CNPJ

### Formatando

```CSharp
CNPJ cnpj = "99999999000191";
cnpj.ComMascara(); // 99.999.999/0001-91

// Sem máscara
CNPJ cnpj = "99.999.999/0001-91";
cnpj.SemMascara(); // 99999999000191
cnpj.ToString(); // 99999999000191
```

### Validando

```CSharp
CNPJ cnpj = "99999999000191";
cnpj.IsValid(); // True
```

## CPF

### Formatando

```CSharp
CPF cpf = "99999999990";
cnpj.ComMascara(); // 999.999.999-90
```

### Validando

```CSharp
CPF cpf = "99999999990";
cnpj.IsValid(); // True
```

## IE: Inscrição Estadual

> Inscrição Estadual (IE) NÃO possui o método `ComMascara`!

### Validando

```CSharp
IE ie = new IE("395.333.85-7", "ES");
ie.IsValid(); // True

IE ie = new IE("395.333.85-7", 32); // Com o código da UF
ie.IsValid(); // True
```

## CEP

> CEP NÃO possui validação!

### Formatando

```CSharp
CEP.Formatar("12345678"); // 12.345-678
```

## UF

### Nome

```CSharp
UF.ES.Nome(); // Espírito Santo
```

### Sigla

```CSharp
UF.SP.Sigla(); // "SP"
```

### Código

```CSharp
UF.DF.Codigo(); // 53
```

## Observações

> Será implementado também o método `AssertValid`: https://github.com/martinusso/docsbr.net/issues/1

## Contribuindo

Crie uma issue. Envie um pull request (com testes).
