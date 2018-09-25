# BoletoNetCore
BoletoNetCore é um componente desenvolvido em C# e .NET Core para Emissão e Impressão de Boletos Bancários, Geração de Arquivo de Remessa e Leitura do Arquivo de Retorno.

# Créditos 
Essa é uma conversão direta do [boleto2net](https://github.com/BoletoNet/boleto2net) para funcionar em .NET Core 2 ou superior, e está frequentemente sendo atualizado com as atualizações feitas no [boleto2net](https://github.com/BoletoNet/boleto2net).

# Atenção
Atualmente não é possível gerar PDF devido a uma limitação de licença do [NReco.PdfGenerator.LT](https://www.nrecosite.com/pdf_generator_net.aspx).

### Carteiras Homologadas
* Banrisul - Carteira 1
* Bradesco - Carteira 09
* Brasil - Carteira 17 (Variações 019 027)
* Caixa Econômica Federal - Carteira SIG14
* Itau - Carteira 109, 112
* Santander - Carteira 101
* Sicoob - Carteira 1-01

### Carteiras Implementadas (Não foi homologada. Falta teste unitário)
* Banco do Brasil Carteira 11 (Variação 019)

> Atenção: Para manter a ordem do projeto, qualquer solicitação de Pull Request de um novo banco ou carteira implementada, deverá seguir o formato dos bancos/carteiras já implementados e vir acompanhado de teste unitário da geração do boleto (PDF), arquivo remessa e geração de 9 boletos, com dígitos da linha digitável variando de 1 a 9, checando além do próprio dígito verificador, o cálculo do nosso número, linha digitável e código de barras.
