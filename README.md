## DESCRIÇÃO DO PROJETO
O programa permite gerenciar pedidos em um sistema de produtos que inclui funcionalidades como adicionar produtos ao pedido, visualizar o resumo do pedido, calcular o valor total com desconto e condições especiais.
 
### Funcionalidades:
Listagem de Produtos: Exibe a lista de produtos disponíveis com seus preços e quantidades.
 
Adicionar Produto ao Pedido: Permite adicionar um produto ao pedido, reduzindo a quantidade no estoque.
 
Remover Produto do Pedido: Remove um item do pedido e restaura a quantidade ao estoque.
 
Visualizar Pedido: Mostra o resumo do pedido atual, incluindo os itens, quantidades, e valor total por item.
 
Calcular Valor Final: Realiza cálculos do valor bruto, aplica descontos e exibe o valor final do pedido.
 
Condições Especiais: Aplica um desconto de 10% para pedidos acima de R$100 ou benefícios como frete grátis para mais de 5 itens.
 
O programa apresenta um menu com as seguintes opções:
(1) Listar produtos
(2) Adicionar produto ao pedido
(3) Remover produto do pedido
(4) Visualizar pedido
(5) Finalizar
 
Selecione uma opção digitando o número correspondente.
 
Adicionar Produtos: Escolha o número do produto e a quantidade desejada.
 
Remover Produtos: Indique a linha do produto no pedido que deseja remover. A quantidade será retornada ao estoque.
 
Finalização do Pedido: Após finalizar, o programa exibirá um resumo completo, incluindo a Quantidade total de itens, Valor bruto do pedido, Aplicação de descontos, se aplicável, Valor final do pedido.
 
O programa é composto por três classes principais:
Produto: Representa os produtos disponíveis para compra. Contém propriedades como nome, preço e quantidade.
Pedido: Gerencia os itens adicionados ao pedido, cálculo de valores e exibição de resumos.
 
Métodos principais:
AdicionarProduto: Adiciona itens ao pedido e atualiza o estoque.
RemoverPorLinha: Remove itens do pedido com base na posição.
VisualizarPedido: Mostra os detalhes do pedido atual.
ExibirResumoFinal: Aplica descontos, calcula o valor total e exibe as condições especiais.
Program: Contém a lógica principal do programa e o menu de interação com o usuário.
 
 
## PASSO A PASSO DA EXECUÇÃO
1) Clone este repositório ou copie o código-fonte.
2) Abra o projeto em seu editor de código.
3) Compile e execute o programa.
4) Siga as instruções exibidas no menu.
 
 
## INTEGRANTES  
Cassio Valezzi - 551059 |
Gabriel Antony Cadima Ciziks - 98215 |
Lucca Sabatini Tambellini - 98169 |
 
 
## VERSÃO UTILIZADA
Visual Studio 2022 |
Language Vs 12.0   |
.NET 8.0           |
