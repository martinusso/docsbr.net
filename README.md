# docsbr.net

Validação e formatação de documentos do Brasi

[![Build status](https://ci.appveyor.com/api/projects/status/gba6n7ih4g2pqhso?svg=true)](https://ci.appveyor.com/project/martinusso/docsbr-net)
[![Nuget count](http://img.shields.io/nuget/v/docsbr.svg)](https://www.nuget.org/packages/docsbr/)
[![Nuget downloads](http://img.shields.io/nuget/dt/docsbr.svg)](https://www.nuget.org/packages/docsbr/)

## Formatando

```CSharp
CNPJ cnpj = "99999999000191";
cnpj.ComMascara(); // 99.999.999/0001-91

// Sem máscara
CNPJ cnpj = "99.999.999/0001-91";
cnpj.SemMascara(); // 99999999000191
cnpj.ToString(); // 99999999000191
```

```CSharp
CPF cpf = "99999999990";
cnpj.ComMascara(); // 999.999.999-90
```

Inscrição Estadual (IE) NÃO possui o método `ComMascara`!

## Validando

> Será implementado também o método `Assert`: https://github.com/martinusso/docsbr.net/issues/1

```CSharp
CNPJ cnpj = "99999999000191";
cnpj.IsValid(); // True
```

```CSharp
CPF cpf = "99999999990";
cnpj.IsValid(); // True
```

```CSharp
IE ie = new IE("395.333.85-7", "ES");
ie.IsValid(); // True
```

## Contribuindo

Crie uma issue. Envie um pull request (com testes).
