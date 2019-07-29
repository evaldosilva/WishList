## Wish List Api por Evaldo Silva

## Sobre o Projeto 

Api de "Lista de Desejos" que associa usuários a produtos desejados.

## Recursos Utilizados

.NET Framework 4.6 com ASP.NET WEB API;<br>
Conceitos Domain-Driven Design (DDD);<br>
Testes Unitarios;

## Endpoints

Criar Usuarios, Produtos e Desejos;<br>
Listar (com paginação) Usuarios, Produtos e Desejos; <br>
Atualizar Desejos;<br>
Remover Desejos;

## Problemas com o roslyn (csc.exe)?

Se aparecer o erro abaixo no momento da execução do projeto no browser, instale o pacote nuget abaixo:

### Erro: 
Erro de Servidor no Aplicativo '/'. <br>
Não foi possível localizar uma parte do caminho 'C:\caminho\WishList-master\WishListWebApi\bin\roslyn\csc.exe'.

### Solução:
`Install-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform.BinFix`
